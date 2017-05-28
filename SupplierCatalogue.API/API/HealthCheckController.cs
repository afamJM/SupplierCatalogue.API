// <copyright file="HealthCheckController.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API.Controllers
{
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using SupplierCatalogue.API.Services;
    using SupplierCatalogue.Models;

    /// <summary>
    /// The Healtch Check API Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/healthcheck")]
    public class HealthCheckController : ControllerBase
    {
        private readonly IHealthCheckService healthCheckService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckController"/> class.
        /// </summary>
        /// <param name="healthCheckService">The health check service.</param>
        public HealthCheckController(IHealthCheckService healthCheckService)
        {
            this.healthCheckService = healthCheckService;
        }

        /// <summary>
        /// Gets the health of the system.
        /// </summary>
        /// <returns>The health check results</returns>
        [HttpGet]
        [ProducesResponseType(typeof(HealthCheckResults), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            return this.Ok(this.healthCheckService.CheckHealth());
        }
    }
}
