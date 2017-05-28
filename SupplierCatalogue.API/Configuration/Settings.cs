// <copyright file="Settings.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API.Configuration
{
    /// <summary>
    /// The application settings
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Gets or sets the datastore settings.
        /// </summary>
        /// <value>
        /// The setting string for the datastore.
        /// </value>
        public DatastoreSettings Datastore { get; set; }

        /// <summary>
        /// Gets or sets the location of the XML Documentation.
        /// </summary>
        /// <value>
        /// The path to the documentation file.
        /// </value>
        public string DocumentationPath { get; set; }

        /// <summary>
        /// Gets or sets the allowed client urls.
        /// </summary>
        /// <value>
        /// The client urls.
        /// </value>
        public string[] ClientUrls { get; set; }
    }
}
