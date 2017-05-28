namespace SupplierCatalogue.API.Tests.Services.Fixtures
{
    using System;
    using Moq;
    using SupplierCatalogue.API.Services;

    /// <summary>
    /// A test fixture for <see cref="HealthCheckService"/>
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class HealthCheckServiceFixture : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckServiceFixture" /> class.
        /// </summary>
        public HealthCheckServiceFixture()
        {
            this.MockServiceProvider = new Mock<IServiceProvider>();
            this.HealthCheckService = new HealthCheckService(this.MockServiceProvider.Object);
        }

        /// <summary>
        /// Gets the service provider.
        /// </summary>
        /// <value>
        /// The service provider.
        /// </value>
        public Mock<IServiceProvider> MockServiceProvider { get; private set; }

        /// <summary>
        /// Gets the health check service.
        /// </summary>
        /// <value>
        /// The health check service.
        /// </value>
        public IHealthCheckService HealthCheckService { get; private set;  }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
