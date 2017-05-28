// <copyright file="EntityAttribute.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models
{
    using System;

    /// <summary>
    /// Specify the persistence hints for an entity class
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class EntityAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityAttribute"/> class.
        /// </summary>
        public EntityAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityAttribute"/> class.
        /// </summary>
        /// <param name="collectionName">The collection name</param>
        public EntityAttribute(string collectionName)
        {
            this.CollectionName = collectionName;
        }

        /// <summary>
        /// Gets or sets the name of the collection to be used to store this entity
        /// </summary>
        /// <returns>The collection name</returns>
        public string CollectionName { get; set; }
    }
}
