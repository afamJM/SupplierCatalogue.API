// <copyright file="SupplierExtensions.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API.API
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Microsoft.AspNetCore.Mvc;
    using SupplierCatalogue.Models;
    using SupplierCatalogue.Models.Requests;
    using SupplierCatalogue.Models.Responses;

    /// <summary>
    /// Extension methods for Supplier classes
    /// </summary>
    public static class SupplierExtensions
    {
        /// <summary>
        /// Creates a specialised supplier from a generic supplier.
        /// </summary>
        /// <param name="supplierData">The generic supplier.</param>
        /// <returns>The specialised supplier</returns>
        public static SupplierDetail AsSpecialised(this GenericSupplier supplierData)
        {
            var supplierType = supplierData.GetType()
                .GetTypeInfo()
                .Assembly
                .GetTypes()
                .Where(x => typeof(SupplierDetail).IsAssignableFrom(x))
                .Select(x => x.GetTypeInfo())
                .Where(x => x.GetCustomAttribute<SupplierCategoryAttribute>() != null &&
                    x.GetCustomAttribute<SupplierCategoryAttribute>().Category.Equals(supplierData.Category, StringComparison.OrdinalIgnoreCase))
                .DefaultIfEmpty(typeof(BasicSupplier).GetTypeInfo())
                .Select(x => x.AsType())
                .First();
            var supplier = (SupplierDetail)Activator.CreateInstance(supplierType);
            foreach (var property in supplierType.GetProperties())
            {
                if (typeof(GenericSupplier).GetProperties().Select(x => x.Name).AsQueryable().Contains(property.Name))
                {
                    supplier.GetType().GetProperty(property.Name).SetValue(supplier, supplierData.GetType().GetProperty(property.Name).GetValue(supplierData));
                }
            }

            return supplier;
        }

        /// <summary>
        /// Sets the identifier of a supplier
        /// </summary>
        /// <param name="supplier">The supplier</param>
        /// <param name="identifier">The identifier</param>
        /// <returns>The updated supplier</returns>
        public static SupplierDetail IdentifiedBy(this SupplierDetail supplier, string identifier)
        {
            supplier.Identifier = identifier;
            return supplier;
        }

        /// <summary>
        /// Represent a supplier as a supplier overview.
        /// </summary>
        /// <param name="supplier">The supplier.</param>
        /// <param name="url">The <see cref="IUrlHelper"/> instance ti be used when creating links</param>
        /// <returns>The supplier overview</returns>
        public static SupplierOverview AsOverview(this SupplierDetail supplier, IUrlHelper url)
        {
            SupplierOverview result = null;
            try
            {
                result = new SupplierOverview
                {
                    Name = supplier.Business.Name,
                    StarRating = supplier.StarRating,
                    ReviewCount = supplier.Reviews != null ? supplier.Reviews.Count() : 0,
                    Description = supplier.Description,
                    CoverImage = supplier.CoverImage,
                    HasOffer = supplier.SpecialOffers != null && supplier.SpecialOffers.Count() > 0,
                    Detail = new Uri(url.Action("getSupplier", null, new { identifier = supplier.Identifier }, url.ActionContext.HttpContext.Request.Scheme)),
                    ImageCount = supplier.Images != null ? supplier.Images.Count() : 0,
                    Category = supplier.Category,
                    ListingType = supplier.Listings.First().ListingType.Code,
                };
            }
            catch
            {
            }

            return result;
        }
    }
}
