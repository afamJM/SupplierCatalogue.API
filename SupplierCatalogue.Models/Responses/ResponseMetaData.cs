// <copyright file="ResponseMetaData.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models.Responses
{
    /// <summary>
    /// The standard response metadata
    /// </summary>
    /// <remarks>
    /// The standard response metadata is used to describe the partial dataset returned by a call
    /// in relation to the complete dataset.
    /// </remarks>
    public class ResponseMetaData
    {
        /// <summary>
        /// Gets or sets the requested maximum number of items in the partial dataset.
        /// </summary>
        /// <value>
        /// The limit.
        /// </value>
        public int? Limit { get; set; }

        /// <summary>
        /// Gets or sets the offset withing the full dataset of the returned partial dataset.
        /// </summary>
        /// <value>
        /// The offset.
        /// </value>
        public int? Offset { get; set; }

        /// <summary>
        /// Gets or sets the number of items in the partial dataset.
        /// </summary>
        /// <value>
        /// The returned.
        /// </value>
        public int Returned { get; set; }

        /// <summary>
        /// Gets or sets the total number of items available in the full dataset.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public int Total { get; set; }
    }
}