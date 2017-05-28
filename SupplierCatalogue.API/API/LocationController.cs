// <copyright file="LocationController.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API.API
{
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using SupplierCatalogue.Models.Responses;

    /// <summary>
    /// The supplier location API controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/v1/suppliers/locations")]
    public class LocationController : ControllerBase
    {
        /// <summary>
        /// Gets the locations.
        /// </summary>
        /// <returns>The locations</returns>
        [HttpGet]
        [ProducesResponseType(typeof(LocationResponse), (int)HttpStatusCode.OK)]
        public IActionResult GetLocations()
        {
            return this.Ok(new LocationResponse());
        }
    }
}
