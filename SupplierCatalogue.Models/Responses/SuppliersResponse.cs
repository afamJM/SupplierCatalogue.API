// <copyright file="SupplierResponse.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models.Responses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// A supplier response
    /// </summary>
    /// <seealso cref="SupplierCatalogue.Models.Responses.StandardResponse" />
    public sealed class SuppliersResponse : StandardResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuppliersResponse"/> class.
        /// </summary>
        /// <param name="supplier">The supplier.</param>
        public SuppliersResponse(Supplier supplier)
        {
            this.Initialise(supplier != null ? new List<Supplier>() { supplier } : new List<Supplier>(), 1, null, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuppliersResponse"/> class.
        /// </summary>
        /// <param name="suppliers">The suppliers.</param>
        /// <param name="total">The total.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        public SuppliersResponse(IEnumerable<Supplier> suppliers, int total, int? offset, int? limit)
        {
            this.Initialise(suppliers ?? new List<Supplier>(), total, offset, limit);
        }

        /// <summary>
        /// Gets or sets the dataset
        /// </summary>
        public new SupplierCollection Data { get; set; } = new SupplierCollection();

        /// <summary>
        /// Initialises the response with the specified suppliers.
        /// </summary>
        /// <param name="suppliers">The suppliers.</param>
        /// <param name="total">The total.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        private void Initialise(IEnumerable<Supplier> suppliers, int total, int? offset, int? limit)
        {
            this.Data.Suppliers = suppliers;
            this.Pagination.Total = total;
            this.Pagination.Offset = offset;
            this.Pagination.Limit = limit;
            this.Pagination.Returned = suppliers.Count();
        }

        /// <summary>
        /// A collection of suppliers
        /// </summary>
        public class SupplierCollection
        {
            /// <summary>
            /// Gets or sets the suppliers.
            /// </summary>
            /// <value>
            /// The suppliers.
            /// </value>
            public IEnumerable<Supplier> Suppliers { get; set; }
        }
    }
}
