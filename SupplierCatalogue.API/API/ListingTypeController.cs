// <copyright file="ListingTypeController.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API.API
{
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using SupplierCatalogue.Models.Responses;

    /// <summary>
    /// The supplier listing type API controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/v1/suppliers/listingtype")]
    public class ListingTypeController : ControllerBase
    {
        /// <summary>
        /// Gets the listing types.
        /// </summary>
        /// <returns>The listing types</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ListingTypeResponse), (int)HttpStatusCode.OK)]
        public IActionResult GetLocations()
        {
            return this.Ok(new ListingTypeResponse());
        }
    }
}
