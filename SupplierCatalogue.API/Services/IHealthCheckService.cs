// <copyright file="IHealthCheckService.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API.Services
{
    using SupplierCatalogue.Models;

    /// <summary>
    /// A service to provide the system health check
    /// </summary>
    public interface IHealthCheckService
    {
        /// <summary>
        /// Checks the health of the system.
        /// </summary>
        /// <returns>The health check results</returns>
        HealthCheckResults CheckHealth();
    }
}
