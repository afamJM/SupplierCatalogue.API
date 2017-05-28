// <copyright file="SupplierController.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API.API
{
    using System;
    using System.Linq;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using SupplierCatalogue.API.Services;
    using SupplierCatalogue.Models;
    using SupplierCatalogue.Models.Requests;
    using SupplierCatalogue.Models.Responses;

    /// <summary>
    /// The supplier API controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/v1/suppliers")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService supplierService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierController"/> class.
        /// </summary>
        /// <param name="supplierService">The supplier service.</param>
        public SupplierController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        /// <summary>
        /// Gets the suppliers.
        /// </summary>
        /// <param name="category">The category (Default: No category filter).</param>
        /// <param name="location">The location (Default: No location filter).</param>
        /// <param name="listingType">The lisitng type (Default: No lisitng type filter).</param>
        /// <param name="offset">The offset (Default: 0).</param>
        /// <param name="limit">The limit (Default: 20).</param>
        /// <returns>
        /// A list of the suppliers
        /// </returns>
        [HttpGet]
        [ProducesResponseType(typeof(SuppliersResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotAcceptable)]
        public IActionResult GetSuppliers([FromQuery] string category = null, [FromQuery] string location = null, [FromQuery] string listingType = null, [FromQuery] int offset = 0, [FromQuery] int limit = 20)
        {
            IActionResult result;
            if (!string.IsNullOrEmpty(category) && !new CategoryResponse().Data.Categories.Any(x => x.Code.Equals(category)))
            {
                result = this.StatusCode((int)HttpStatusCode.NotAcceptable, new ErrorResponse { Message = "Invalid category." });
            }
            else if (!string.IsNullOrEmpty(location) && !new LocationResponse().Data.Locations.Any(x => x.Code.Equals(location)))
            {
                result = this.StatusCode((int)HttpStatusCode.NotAcceptable, new ErrorResponse { Message = "Invalid location." });
            }
            else if (!string.IsNullOrEmpty(listingType) && !Constants.ListingTypes.Any(x => x.Code.Equals(listingType)))
            {
                result = this.StatusCode((int)HttpStatusCode.NotAcceptable, new ErrorResponse { Message = "Invalid listing type." });
            }
            else if ((offset < 0) || (limit < 1))
            {
                result = this.StatusCode((int)HttpStatusCode.NotAcceptable, new ErrorResponse { Message = "Limit and/or offset contain invalid values." });
            }
            else
            {
                result = this.Ok(new SuppliersResponse(
                    this.supplierService.GetSuppliers(
                        category,
                        location,
                        listingType,
                        out int total,
                        offset,
                        limit).AsEnumerable().Select(x => x.AsOverview(this.Url)),
                    total,
                    offset,
                    limit));
            }

            return result;
        }

        /// <summary>
        /// Gets a supplier.
        /// </summary>
        /// <param name="identifier">The identifier of the required supplier.</param>
        /// <returns>The supplier</returns>
        [HttpGet]
        [Route("{identifier}")]
        [ProducesResponseType(typeof(SupplierResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NotFound)]
        public IActionResult GetSupplier(string identifier)
        {
            var supplier = this.supplierService.GetSupplier(identifier);
            return supplier != null ?
                   (IActionResult)this.Ok(new SupplierResponse(supplier)) :
                   (IActionResult)this.NotFound();
        }

        /// <summary>
        /// Add a supplier.
        /// </summary>
        /// <param name="supplier">The supplier.</param>
        /// <returns>The updated supplier</returns>
        [HttpPost]
        [ProducesResponseType(typeof(SupplierResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotAcceptable)]
        public async System.Threading.Tasks.Task<IActionResult> PostSupplierAsync([FromBody] GenericSupplier supplier)
        {
            IActionResult result;
            if (supplier != null)
            {
                string updateId = null;
                if (supplier.LegacyIdentifier.HasValue)
                {
                    updateId = this.supplierService.GetSupplierIdFromLegacyId(supplier.LegacyIdentifier.Value);
                }

                var created = await this.supplierService.SaveSupplierAsync(supplier.AsSpecialised().IdentifiedBy(string.IsNullOrEmpty(updateId) ? null : updateId));
                if (created != null)
                {
                    if (string.IsNullOrEmpty(updateId))
                    {
                        result = this.Created(this.Url.Action("getSupplier", null, new { identifier = created.Identifier }, this.Request.Scheme), new SupplierResponse(created));
                    }
                    else
                    {
                        result = this.Ok(new SupplierResponse(created));
                    }
                }
                else
                {
                    result = this.StatusCode((int)HttpStatusCode.NotAcceptable, new ErrorResponse { Message = "Unable to create the requsted supplier." });
                }
            }
            else
            {
                result = this.StatusCode((int)HttpStatusCode.NotAcceptable, new ErrorResponse { Message = "The supplied supplier was invalid." });
            }

            return result;
        }

        /// <summary>
        /// Update a supplier.
        /// </summary>
        /// <param name="supplier">The supplier.</param>
        /// <param name="identifier">The identifier of the supplier to update</param>
        /// <returns>The updated supplier</returns>
        [HttpPut]
        [Route("{identifier}")]
        [ProducesResponseType(typeof(SupplierResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotAcceptable)]
        public async System.Threading.Tasks.Task<IActionResult> PutSupplierAsync([FromBody] GenericSupplier supplier, string identifier)
        {
            IActionResult result = null;
            if (supplier != null)
            {
                string updateId = null;
                if (supplier.LegacyIdentifier.HasValue)
                {
                    updateId = this.supplierService.GetSupplierIdFromLegacyId(supplier.LegacyIdentifier.Value);
                    if (!identifier.Equals(updateId))
                    {
                        result = this.StatusCode((int)HttpStatusCode.NotAcceptable, new ErrorResponse { Message = "The supplied legacy ID was for a different supplier." });
                    }
                }

                if (result == null)
                {
                    var updated = await this.supplierService.SaveSupplierAsync(supplier.AsSpecialised().IdentifiedBy(identifier));
                    result = this.Ok(new SupplierResponse(updated));
                }
            }
            else
            {
                result = this.StatusCode((int)HttpStatusCode.NotAcceptable, new ErrorResponse { Message = "The supplied supplier was invalid." });
            }

            return result;
        }

        /// <summary>
        /// Deletes a supplier.
        /// </summary>
        /// <param name="identifier">The identifier of the required supplier.</param>
        /// <returns>The supplier</returns>
        [HttpDelete]
        [Route("{identifier}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
        public async System.Threading.Tasks.Task<IActionResult> DeleteSupplierAsync(string identifier)
        {
            await this.supplierService.DeleteSupplierAsync(identifier);
            return this.NoContent();
        }
    }
}
