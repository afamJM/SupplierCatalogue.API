// <copyright file="CakeSupplier.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// A supplier of cakes
    /// </summary>
    [SupplierCategory("cake")]
    public class CakeSupplier : SupplierDetail
    {
        /// <summary>
        /// Gets or sets the list of styles offered.
        /// </summary>
        /// <value>
        /// The styles.
        /// </value>
        public IEnumerable<string> Styles { get; set; }
    }
}
