// <copyright file="IDatastore.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API.Datastore
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using SupplierCatalogue.API.Infrastructure;

    /// <summary>
    /// Our datastore
    /// </summary>
    public interface IDatastore : IHealthConcern
    {
        /// <summary>
        /// Get a count of the entities in a filtered collection
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <param name="filter">The filter to use</param>
        /// <returns>The entities</returns>
        long Count<T>(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Get a collection of entities from the datastore
        /// </summary>
        /// <typeparam name="T">The type of the entity required</typeparam>
        /// <returns>
        /// The entities
        /// </returns>
        IQueryable<T> Get<T>();

        /// <summary>
        /// Insert a new entity into the datastore
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <param name="entity">The entity</param>
        /// <returns>the inserted entity</returns>
        Task<T> InsertAsync<T>(T entity);

        /// <summary>
        /// Update an entity in the datastore
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <param name="filter">The filter to identify the entity to update</param>
        /// <param name="entity">The entity to replace the existing entity</param>
        /// <returns>The updated entity</returns>
        Task<T> UpdateAsync<T>(Expression<Func<T, bool>> filter, T entity);

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <param name="filter">The expression used to identify the entity to delete</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task RemoveAsync<T>(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <typeparam name="T">THe type of object to get the collection for</typeparam>
        /// <returns>The Mongo Collection</returns>
        IMongoCollection<T> GetCollection<T>();
    }
}
