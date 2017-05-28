namespace SupplierCatalogue.API.Tests.API
{
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using SupplierCatalogue.API.API;
    using SupplierCatalogue.API.Tests.Fixtures.API;
    using SupplierCatalogue.Models;
    using SupplierCatalogue.Models.Responses;
    using Xunit;

    /// <summary>
    /// Test class for <see cref="SupplierController"/>
    /// </summary>
    public class SupplierControllerTest
    {
        private SupplierControllerFixture fixture;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierControllerTest"/> class.
        /// </summary>
        public SupplierControllerTest()
        {
            this.fixture = new SupplierControllerFixture();
        }

        /// <summary>
        /// Should request the first twenty unfiltered.
        /// </summary>
        /// <remarks>
        /// The <see cref="SupplierController.GetSuppliers(string, string, string, int, int)"/> method should
        /// request the first twenty suppliers with no filter by default.
        /// </remarks>
        [Fact]
        public void ShouldRequestTheFirstTwentyUnfiltered()
        {
            var result = this.fixture.SupplierController.GetSuppliers();
            var total = 0;
            this.fixture.MockSupplierService.Verify(x => x.GetSuppliers(null, null, null, out total, 0, 20), Times.Once());
        }

        /// <summary>
        /// Should pass the supplied parameters.
        /// </summary>
        [Fact]
        public void ShouldPassTheSuppliedParameters()
        {
            var result = this.fixture.SupplierController.GetSuppliers("cake", null, null, 35, 45);
            var total = 0;
            this.fixture.MockSupplierService.Verify(x => x.GetSuppliers("cake", null, null, out total, 35, 45), Times.Once());
        }

        /// <summary>
        /// Should reject an invalid category.
        /// </summary>
        [Fact]
        public void ShouldRejectAnInvalidCategory()
        {
            var result = this.fixture.SupplierController.GetSuppliers("not-a-category", null, null, 35, 45);
            Assert.IsType(typeof(ObjectResult), result);
            Assert.Equal((int)HttpStatusCode.NotAcceptable, ((ObjectResult)result).StatusCode);
            Assert.IsType(typeof(ErrorResponse), ((ObjectResult)result).Value);
            Assert.Equal("Invalid category.", ((ErrorResponse)((ObjectResult)result).Value).Message);
        }

        /// <summary>
        /// Should reject an invalid offset.
        /// </summary>
        [Fact]
        public void ShouldRejectAnInvalidOffset()
        {
            var result = this.fixture.SupplierController.GetSuppliers(null, null, null, -1);
            Assert.IsType(typeof(ObjectResult), result);
            Assert.Equal((int)HttpStatusCode.NotAcceptable, ((ObjectResult)result).StatusCode);
            Assert.IsType(typeof(ErrorResponse), ((ObjectResult)result).Value);
            Assert.Equal("Limit and/or offset contain invalid values.", ((ErrorResponse)((ObjectResult)result).Value).Message);
        }

        /// <summary>
        /// Should reject an invalid limit.
        /// </summary>
        [Fact]
        public void ShouldRejectAnInvalidLimit()
        {
            var result = this.fixture.SupplierController.GetSuppliers(null, null, null, 0, 0);
            Assert.IsType(typeof(ObjectResult), result);
            Assert.Equal((int)HttpStatusCode.NotAcceptable, ((ObjectResult)result).StatusCode);
            Assert.IsType(typeof(ErrorResponse), ((ObjectResult)result).Value);
            Assert.Equal("Limit and/or offset contain invalid values.", ((ErrorResponse)((ObjectResult)result).Value).Message);
        }

        /// <summary>
        /// Should request the correct supplier and return it.
        /// </summary>
        [Fact]
        public void ShouldRequestTheCorrectSupplierAndReturnIt()
        {
            this.fixture.MockSupplierService.Setup(x => x.GetSupplier("id")).Returns(new BasicSupplier() { Name = "This is the supplier you're looking for" });
            var result = this.fixture.SupplierController.GetSupplier("id");
            this.fixture.MockSupplierService.Verify(x => x.GetSupplier("id"), Times.Once);
            Assert.IsType(typeof(OkObjectResult), result);
            Assert.Equal((int)HttpStatusCode.OK, ((OkObjectResult)result).StatusCode);
            Assert.IsType(typeof(SupplierResponse), ((OkObjectResult)result).Value);
            Assert.Equal("This is the supplier you're looking for", ((SupplierResponse)((ObjectResult)result).Value).Data.Name);
        }

        /// <summary>
        /// Should request the correct supplier and return not found.
        /// </summary>
        [Fact]
        public void ShouldRequestTheCorrectSupplierAndReturnNotFound()
        {
            this.fixture.MockSupplierService.Setup(x => x.GetSupplier("id")).Returns((SupplierDetail)null);
            var result = this.fixture.SupplierController.GetSupplier("id");
            this.fixture.MockSupplierService.Verify(x => x.GetSupplier("id"), Times.Once);
            Assert.IsType(typeof(NotFoundResult), result);
            Assert.Equal((int)HttpStatusCode.NotFound, ((NotFoundResult)result).StatusCode);
        }
    }
}
