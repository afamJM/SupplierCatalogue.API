namespace SupplierCatalogue.API.Tests.Services
{
    using System;
    using System.Linq;
    using SupplierCatalogue.API.Tests.Mocks;
    using SupplierCatalogue.API.Tests.Services.Fixtures;
    using SupplierCatalogue.Models;
    using Xunit;

    /// <summary>
    /// Test the Health Check Service
    /// </summary>
    public class HealthCheckServiceTest
    {
        private HealthCheckServiceFixture testFixture;

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckServiceTest"/> class.
        /// </summary>
        public HealthCheckServiceTest()
        {
            this.testFixture = new HealthCheckServiceFixture();
        }

        /// <summary>
        /// Should the get heath check results.
        /// </summary>
        [Fact]
        public void ShouldGetHeathCheckResults()
        {
            this.testFixture.MockServiceProvider
                .Setup(x => x.GetService(Moq.It.IsAny<Type>())).Returns(new MockHealthConcern(() => new HealthCheckResult("Test", 1)));
            var resutl = this.testFixture.HealthCheckService.CheckHealth();
            Assert.Equal("Hitched Supplier Catalogue", resutl.Name);
            Assert.Equal(1, resutl.Checks.Count());
            Assert.Equal("Test", resutl.Checks.First().Name);
            Assert.Equal(1, resutl.Checks.First().Status);
        }
    }
}