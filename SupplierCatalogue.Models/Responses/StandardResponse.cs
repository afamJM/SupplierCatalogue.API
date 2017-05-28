// <copyright file="StandardResponse.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models.Responses
{
    using System;

    /// <summary>
    /// A standard API response body
    /// </summary>
    public abstract class StandardResponse
    {
        /// <summary>
        /// Gets or sets the dataset
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the metadata for this dataset
        /// </summary>
        public ResponseMetaData Pagination { get; set; } = new ResponseMetaData();
    }
}
