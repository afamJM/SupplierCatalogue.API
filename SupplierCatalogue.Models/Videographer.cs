// <copyright file="Videographer.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// A videographer
    /// </summary>
    /// <seealso cref="SupplierCatalogue.Models.SupplierDetail" />
    [SupplierCategory("videographer")]
    public class Videographer : SupplierDetail
    {
        /// <summary>
        /// Gets or sets the list of styles offered.
        /// </summary>
        /// <value>
        /// The styles.
        /// </value>
        public IEnumerable<string> Styles { get; set; }

        /// <summary>
        /// Gets or sets the list of sample video URIs.
        /// </summary>
        /// <value>
        /// The videos.
        /// </value>
        public IEnumerable<Uri> Videos { get; set; }
    }
}
