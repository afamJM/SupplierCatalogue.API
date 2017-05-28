// <copyright file="UriExtensions.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for the Uri class
    /// </summary>
    public static class UriExtensions
    {
        /// <summary>
        /// Ensure a URI is absolute.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>The absolute URI</returns>
        public static Uri AsAbsoluteUri(this Uri uri)
        {
            return uri != null ? uri.IsAbsoluteUri ? uri : new UriBuilder(uri.OriginalString).Uri : null;
        }
    }
}
