// <copyright file="DatastoreSettings.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API.Configuration
{
    /// <summary>
    /// The settigns for our datastore
    /// </summary>
    public class DatastoreSettings
    {
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>
        /// The connection string for the Mongo Database.
        /// </value>
        public string Connection { get; set; }

        /// <summary>
        /// Gets or sets the database name.
        /// </summary>
        /// <value>
        /// The database name.
        /// </value>
        public string Database { get; set; }
    }
}
