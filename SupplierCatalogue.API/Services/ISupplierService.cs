// <copyright file="ISupplierService.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SupplierCatalogue.Models;

    /// <summary>
    /// The supllier business logic
    /// </summary>
    public interface ISupplierService
    {
        /// <summary>
        /// Gets the suppliers.
        /// </summary>
        /// <param name="category">The suplier category to filter by</param>
        /// <param name="location">The suplier location to filter by</param>
        /// <param name="listingType">The suplier lisitng type to filter by</param>
        /// <param name="total">The variable to recieve the count of records in the dataset</param>
        /// <param name="offset">The offset within the recordset of the first document to return</param>
        /// <param name="limit">The maximum number of documents to return</param>
        /// <returns>The suppliers</returns>
        IEnumerable<SupplierDetail> GetSuppliers(string category, string location, string listingType, out int total, int offset, int limit);

        /// <summary>
        /// Gets a supplier.
        /// </summary>
        /// <param name="identifier">The identifier of the requried supplier.</param>
        /// <returns>The supplier</returns>
        SupplierDetail GetSupplier(string identifier);

        /// <summary>
        /// Saves a supplier.
        /// </summary>
        /// <param name="supplier">The supplier.</param>
        /// <returns>The resulting supplier</returns>
        Task<SupplierDetail> SaveSupplierAsync(SupplierDetail supplier);

        /// <summary>
        /// Deletes a supplier.
        /// </summary>
        /// <param name="identifier">The identifier of the supplier to be deleted.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task DeleteSupplierAsync(string identifier);

        /// <summary>
        /// Gets the supplier identity by it's legacy identifier.
        /// </summary>
        /// <param name="legacyIdentifier">The legacy identifier.</param>
        /// <returns>The identifier</returns>
        string GetSupplierIdFromLegacyId(int legacyIdentifier);
    }
}
