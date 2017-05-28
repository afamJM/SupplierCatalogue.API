// <copyright file="MockDatastore.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API.Tests.Mocks
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using SupplierCatalogue.API.Datastore;
    using SupplierCatalogue.Models;

    /// <summary>
    /// An <see cref="IDatastore"/> implementation for testing
    /// </summary>
    /// <seealso cref="SupplierCatalogue.API.Datastore.IDatastore" />
    internal class MockDatastore : IDatastore
    {
        /// <summary>
        /// Gets or sets the test values.
        /// </summary>
        /// <value>
        /// The values.
        /// </value>
        public IList Values { get; set; }

        /// <inheritdoc/>
        public HealthCheckResult CheckHealth()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public long Count<T>(Expression<Func<T, bool>> filter)
        {
            return this.Values.Cast<T>().AsQueryable().Where(filter).Count();
        }

        /// <inheritdoc/>
        public IQueryable<T> Get<T>()
        {
            return this.Values
                .Cast<T>()
                .AsQueryable();
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <typeparam name="T">THe type of object to get the collection for</typeparam>
        /// <returns>
        /// The Mongo Collection
        /// </returns>
        /// <exception cref="System.NotImplementedException">This method is not yet implemented</exception>
        public IMongoCollection<T> GetCollection<T>()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<T> InsertAsync<T>(T entity)
        {
            return await Task.Run(() =>
            {
                this.Values.Add(entity);
                return entity;
            });
        }

        /// <inheritdoc/>
        public async Task RemoveAsync<T>(Expression<Func<T, bool>> filter)
        {
            await Task.Run(() => this.Values.Remove(((IQueryable<T>)this.Values).Where(filter)));
        }

        /// <inheritdoc/>
        public async Task<T> UpdateAsync<T>(Expression<Func<T, bool>> filter, T entity)
        {
            await Task.Run(() => { });
            throw new NotImplementedException();
        }
    }
}
