// <copyright file="Designer.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models
{
    using System;

    /// <summary>
    /// A designer
    /// </summary>
    public class Designer
    {
        private Uri website;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the logo image.
        /// </summary>
        /// <value>
        /// The logo.
        /// </value>
        public Image Logo { get; set; }

        /// <summary>
        /// Gets or sets the website URI.
        /// </summary>
        /// <value>
        /// The website URI.
        /// </value>
        public Uri Website
        {
            get
            {
                return this.website;
            }

            set
            {
                this.website = value.AsAbsoluteUri();
            }
        }
    }
}