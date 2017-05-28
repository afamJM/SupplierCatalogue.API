// <copyright file="HealthCheckResult.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models
{
    /// <summary>
    /// The result of a health chack on a dependancy
    /// </summary>
    public class HealthCheckResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckResult"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="status">The status.</param>
        public HealthCheckResult(string name, decimal status)
        {
            this.Name = name;
            this.Status = status;
        }

        /// <summary>
        /// Gets the name of the health check.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public decimal Status { get; }
    }
}
