// <copyright file="Image.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// An image
    /// </summary>
    public class Image
    {
        private Uri path;

        /// <summary>
        /// Gets or sets the URI of the image file.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public Uri Path
        {
            get { return this.path; }

            set { this.path = value.AsAbsoluteUri(); }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int? Width { get; set; }
    }
}
