// <copyright file="MongoDatastore.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API.Datastore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;
    using SupplierCatalogue.API.Configuration;
    using SupplierCatalogue.Models;

    /// <summary>
    /// Our Mongo Database
    /// </summary>
    public class MongoDatastore : IDatastore
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDatastore"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public MongoDatastore(IOptions<Settings> settings)
        {
            this.Client = new MongoClient(settings.Value.Datastore.Connection);
            this.Database = this.Client.GetDatabase(settings.Value.Datastore.Database);
        }

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        public IMongoDatabase Database { get; set; }

        private MongoClient Client { get; set; }

        /// <inheritdoc/>
        public long Count<T>(Expression<Func<T, bool>> filter)
        {
            return this.Database.GetCollection<T>(this.GetCollectionName(typeof(T)))
                .AsQueryable().Where(filter.Compile()).Count();
        }

        /// <inheritdoc/>
        public IQueryable<T> Get<T>()
        {
            return this.Database.GetCollection<T>(this.GetCollectionName(typeof(T)))
                .AsQueryable();
        }

        /// <inheritdoc/>
        public async Task<T> InsertAsync<T>(T entity)
        {
            await this.Database.GetCollection<T>(this.GetCollectionName(typeof(T)))
                .InsertOneAsync(entity);
            return entity;
        }

        /// <inheritdoc/>
        public async Task<T> UpdateAsync<T>(Expression<Func<T, bool>> filter, T entity)
        {
            await this.Database.GetCollection<T>(this.GetCollectionName(typeof(T)))
                .ReplaceOneAsync(Builders<T>.Filter.Where(filter), entity);
            return entity;
        }

        /// <inheritdoc/>
        public async Task RemoveAsync<T>(Expression<Func<T, bool>> filter)
        {
            await this.Database.GetCollection<T>(this.GetCollectionName(typeof(T)))
                .DeleteManyAsync(Builders<T>.Filter.Where(filter));
        }

        /// <inheritdoc/>
        public HealthCheckResult CheckHealth()
        {
            var result = false;
            try
            {
                this.Database.ListCollections();
                result = true;
            }
            catch
            {
                result = false;
            }

            return new HealthCheckResult("Database is up", result ? 1 : 0);
        }

        /// <inheritdoc/>
        public IMongoCollection<T> GetCollection<T>()
        {
            return this.Database.GetCollection<T>(this.GetCollectionName(typeof(T)));
        }

        private string GetCollectionName(Type type)
        {
            var attribute = type.GetTypeInfo()
                .GetCustomAttributes<EntityAttribute>()
                .FirstOrDefault();
            return attribute != null && !string.IsNullOrEmpty(attribute.CollectionName) ? attribute.CollectionName : type.Name;
        }
    }
}
