// <copyright file="IHealthConcern.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API.Infrastructure
{
    using SupplierCatalogue.Models;

    /// <summary>
    /// A component that should be included in the system health check
    /// </summary>
    /// <remarks>
    /// Classes implementing this interface will automatically be included in
    /// the system health check as long as the class is availbale using
    /// dependency inject, either directly or via one of its implemented
    /// interfaces, or has a default constructor
    /// </remarks>
    public interface IHealthConcern
    {
        /// <summary>
        /// Checks the health of the compnent.
        /// </summary>
        /// <returns>The result of the health check</returns>
        HealthCheckResult CheckHealth();
    }
}
