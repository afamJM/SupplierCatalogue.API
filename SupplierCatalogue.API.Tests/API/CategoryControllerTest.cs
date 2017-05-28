namespace SupplierCatalogue.API.Tests.API
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.AspNetCore.Mvc;
    using SupplierCatalogue.API.API;
    using SupplierCatalogue.Models.Responses;
    using Xunit;

    /// <summary>
    /// Tests for the category controller
    /// </summary>
    public class CategoryControllerTest
    {
        /// <summary>
        /// Should return the categories.
        /// </summary>
        [Fact]
        public void ShouldReturnTheCategories()
        {
            var controller = new CategoryController();
            var result = controller.GetCatagories();
            Assert.IsType(typeof(OkObjectResult), result);
            Assert.Equal(200, ((OkObjectResult)result).StatusCode);
            Assert.IsType(typeof(CategoryResponse), ((OkObjectResult)result).Value);
            Assert.NotEmpty(((CategoryResponse)((OkObjectResult)result).Value).Data.Categories);
        }
    }
}
