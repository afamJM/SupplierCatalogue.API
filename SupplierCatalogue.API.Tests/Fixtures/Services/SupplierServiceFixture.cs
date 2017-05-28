namespace SupplierCatalogue.API.Tests.Fixtures.Services
{
    using Moq;
    using SupplierCatalogue.API.Datastore;
    using SupplierCatalogue.API.Services;

    /// <summary>
    /// A test fixture for <see cref="SupplierService"/>
    /// </summary>
    public class SupplierServiceFixture
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierServiceFixture"/> class.
        /// </summary>
        public SupplierServiceFixture()
        {
            this.MockDataStore = new Mock<IDatastore>();
            this.SupplierService = new SupplierService(this.MockDataStore.Object);
        }

        /// <summary>
        /// Gets the mock data store.
        /// </summary>
        /// <value>
        /// The mock data store.
        /// </value>
        public Mock<IDatastore> MockDataStore { get; private set; }

        /// <summary>
        /// Gets the supplier service.
        /// </summary>
        /// <value>
        /// The supplier service.
        /// </value>
        public ISupplierService SupplierService { get; private set; }
    }
}
