// <copyright file="SupplierResponse.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models.Responses
{
    /// <summary>
    /// A supplier response
    /// </summary>
    /// <seealso cref="SupplierCatalogue.Models.Responses.StandardResponse" />
    public class SupplierResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierResponse"/> class.
        /// </summary>
        /// <param name="supplier">The supplier.</param>
        public SupplierResponse(Supplier supplier)
        {
            this.Data = supplier;
        }

        /// <summary>
        /// Gets or sets the dataset
        /// </summary>
        public Supplier Data { get; set; }
    }
}
