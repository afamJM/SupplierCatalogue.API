// <copyright file="Musician.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// A musician
    /// </summary>
    [SupplierCategory("music")]
    public class Musician : SupplierDetail
    {
        /// <summary>
        /// Gets or sets the musical styles offered.
        /// </summary>
        /// <value>
        /// The styles.
        /// </value>
        public IEnumerable<string> Styles { get; set; }
    }
}
