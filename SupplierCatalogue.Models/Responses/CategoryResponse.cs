// <copyright file="CategoryResponse.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models.Responses
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A standard response containing the valid categories
    /// </summary>
    /// <seealso cref="SupplierCatalogue.Models.Responses.StandardResponse" />
    public class CategoryResponse : StandardResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryResponse"/> class.
        /// </summary>
        public CategoryResponse()
        {
            this.Pagination.Limit = 0;
            this.Pagination.Offset = 0;
            this.Pagination.Total = this.Data.Categories.Count();
            this.Pagination.Returned = this.Data.Categories.Count();
        }

        /// <summary>
        /// Gets or sets the categories
        /// </summary>
        public new CategoryCollection Data { get; set; } = new CategoryCollection();

        /// <summary>
        /// A collection of categories
        /// </summary>
        public class CategoryCollection
        {
            /// <summary>
            /// Gets or sets the categories.
            /// </summary>
            /// <value>
            /// The categories.
            /// </value>
            public IEnumerable<Category> Categories { get; set; } = Constants.Categories;
        }
    }
}
