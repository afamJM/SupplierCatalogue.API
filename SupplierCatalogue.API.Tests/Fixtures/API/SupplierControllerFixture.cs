namespace SupplierCatalogue.API.Tests.Fixtures.API
{
    using Moq;
    using SupplierCatalogue.API.API;
    using SupplierCatalogue.API.Services;

    /// <summary>
    /// A test fixture for <see cref="SupplierController"/>
    /// </summary>
    public class SupplierControllerFixture
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierControllerFixture"/> class.
        /// </summary>
        public SupplierControllerFixture()
        {
            this.MockSupplierService = new Mock<ISupplierService>();
            this.SupplierController = new SupplierController(this.MockSupplierService.Object);
        }

        /// <summary>
        /// Gets the mocked supplier service.
        /// </summary>
        /// <value>
        /// The mock supplier service.
        /// </value>
        public Mock<ISupplierService> MockSupplierService { get; private set; }

        /// <summary>
        /// Gets the supplier controller.
        /// </summary>
        /// <value>
        /// The supplier controller.
        /// </value>
        public SupplierController SupplierController { get; private set; }
    }
}
