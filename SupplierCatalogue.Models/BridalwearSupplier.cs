// <copyright file="BridalwearSupplier.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// A supplier of bridalwear
    /// </summary>
    /// <seealso cref="SupplierCatalogue.Models.SupplierDetail" />
    [SupplierCategory("bridalware")]
    public class BridalwearSupplier : SupplierDetail
    {
        /// <summary>
        /// Gets or sets the designers stocked.
        /// </summary>
        /// <value>
        /// The designers.
        /// </value>
        public IEnumerable<Designer> Designers { get; set; }
    }
}
