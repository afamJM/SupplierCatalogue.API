// <copyright file="HealthCheckResults.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The results of a service health check
    /// </summary>
    public class HealthCheckResults
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckResults"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="checks">The dependancy check results.</param>
        public HealthCheckResults(string name, IEnumerable<HealthCheckResult> checks)
        {
            this.Name = name;
            this.Date = DateTime.Now;
            this.Checks = new List<HealthCheckResult>(checks).AsReadOnly();
        }

        /// <summary>
        /// Gets the name of the service.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the date and time of the check.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; }

        /// <summary>
        /// Gets the dependancy check results.
        /// </summary>
        /// <value>
        /// The check results.
        /// </value>
        public IEnumerable<HealthCheckResult> Checks { get; }
    }
}
