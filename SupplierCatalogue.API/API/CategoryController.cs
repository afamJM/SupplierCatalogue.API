// <copyright file="CategoryController.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API.API
{
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using SupplierCatalogue.Models.Responses;

    /// <summary>
    /// The supplier category API controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/v1/suppliers/categories")]
    public class CategoryController : ControllerBase
    {
        /// <summary>
        /// Gets the catagories.
        /// </summary>
        /// <returns>The categories</returns>
        [HttpGet]
        [ProducesResponseType(typeof(CategoryResponse), (int)HttpStatusCode.OK)]
        public IActionResult GetCatagories()
        {
            return this.Ok(new CategoryResponse());
        }
    }
}
