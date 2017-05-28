// <copyright file="Review.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// A review
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Gets or sets the reviewer.
        /// </summary>
        /// <value>
        /// The reviewer.
        /// </value>
        public Person Reviewer { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        /// <remarks>
        /// Score is in half-stars with a minimum of zero and a mximum of ten
        /// </remarks>
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public string Comments { get; set; }
    }
}
