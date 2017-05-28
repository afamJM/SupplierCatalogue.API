namespace SupplierCatalogue.API.Tests.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SupplierCatalogue.API.Infrastructure;
    using SupplierCatalogue.Models;

    /// <summary>
    /// A mock health concern
    /// </summary>
    /// <seealso cref="SupplierCatalogue.API.Infrastructure.IHealthConcern" />
    public class MockHealthConcern : IHealthConcern
    {
        private readonly Func<HealthCheckResult> implementation;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockHealthConcern"/> class.
        /// </summary>
        /// <param name="implementation">The implementation of the CheckHealth method.</param>
        public MockHealthConcern(Func<HealthCheckResult> implementation)
        {
            this.implementation = implementation;
        }

        /// <inheritdoc/>
        public HealthCheckResult CheckHealth()
        {
            return this.implementation();
        }
    }
}
