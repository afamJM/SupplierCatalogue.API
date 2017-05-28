// <copyright file="Beautician.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// A beutician
    /// </summary>
    /// <seealso cref="SupplierCatalogue.Models.SupplierDetail" />
    [SupplierCategory("beauty")]
    public class Beautician : SupplierDetail
    {
        /// <summary>
        /// Gets or sets the treatments offered.
        /// </summary>
        /// <value>
        /// The treatments.
        /// </value>
        public IEnumerable<string> Treatments { get; set; }
    }
}
