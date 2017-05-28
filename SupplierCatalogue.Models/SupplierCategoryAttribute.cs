// <copyright file="SupplierCategoryAttribute.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models
{
    using System;

    /// <summary>
    /// Used to determine the category of supplier that this class is for.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class)]
    public class SupplierCategoryAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierCategoryAttribute"/> class.
        /// </summary>
        /// <param name="category">The category.</param>
        public SupplierCategoryAttribute(string category)
        {
            this.Category = category;
        }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category { get; set; }
    }
}
