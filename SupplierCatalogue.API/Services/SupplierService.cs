// <copyright file="SupplierService.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using MongoDB.Driver;
    using SupplierCatalogue.API.Datastore;
    using SupplierCatalogue.Models;

    /// <summary>
    /// The suppliers business logic
    /// </summary>
    /// <seealso cref="SupplierCatalogue.API.Services.ISupplierService" />
    public class SupplierService : ISupplierService
    {
        private readonly IDatastore datastore;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierService"/> class.
        /// </summary>
        /// <param name="datastore">The datastore.</param>
        public SupplierService(IDatastore datastore)
        {
            this.datastore = datastore;
        }

        /// <inheritdoc/>
        public SupplierDetail GetSupplier(string identifier)
        {
            return this.datastore.Get<SupplierDetail>()
                .Where(x => x.Identifier == identifier)
                .FirstOrDefault();
        }

        /// <inheritdoc/>
        public IEnumerable<SupplierDetail> GetSuppliers(string category, string location, string listingType, out int total, int offset, int limit)
        {
            var collection = this.datastore.GetCollection<SupplierDetail>();

            var pipeline = collection
                .Aggregate()
                .Unwind(x => x.Listings)
                .Match(new BsonDocument
                {
                    {
                        "Listings.ListingExpiry", new BsonDocument
                        {
                            { "$gt", DateTime.UtcNow },
                        }
                    },
                });

            if (!string.IsNullOrEmpty(category))
            {
                pipeline = pipeline.Match(new BsonDocument
                {
                    { "Category", category },
                });
            }

            if (!string.IsNullOrEmpty(location))
            {
                pipeline = pipeline.Match(new BsonDocument
                {
                    {
                        "$or", new BsonArray
                        {
                            new BsonDocument { { "Listings.ListingType.Code", "national" } },
                            new BsonDocument { { "Listings.Location.County", location } },
                        }
                    },
                });
            }

            if (!string.IsNullOrEmpty(listingType))
            {
                pipeline = pipeline.Match(new BsonDocument
                {
                    { "Listings.ListingType.Code", listingType },
                });
            }

            pipeline = pipeline.Sort(new BsonDocument
                {
                    { "Listings.ListingType.Priority", 1 },
                    { "Listings.Weight", 1 },
                })
                .Group(new BsonDocument
                {
                    { "_id", "$_id" },
                    {
                        "_t", new BsonDocument
                        {
                            { "$first", "$_t" },
                        }
                    },
                    {
                        "Name",  new BsonDocument
                        {
                            { "$first", "$Name" },
                        }
                    },
                    {
                        "Description",  new BsonDocument
                        {
                            { "$first", "$Description" },
                        }
                    },
                    {
                        "CoverImage",  new BsonDocument
                        {
                            { "$first", "$CoverImage" },
                        }
                    },
                    {
                        "Category",  new BsonDocument
                        {
                            { "$first", "$Category" },
                        }
                    },
                    {
                        "LegacyIdentifier",  new BsonDocument
                        {
                            { "$first", "$LegacyIdentifier" },
                        }
                    },
                    {
                        "Business",  new BsonDocument
                        {
                            { "$first", "$Business" },
                        }
                    },
                    {
                        "Website",  new BsonDocument
                        {
                            { "$first", "$Website" },
                        }
                    },
                    {
                        "Location",  new BsonDocument
                        {
                            { "$first", "$Location" },
                        }
                    },
                    {
                        "StarRating",  new BsonDocument
                        {
                            { "$first", "$StarRating" },
                        }
                    },
                    {
                        "Reviews",  new BsonDocument
                        {
                            { "$first", "$Reviews" },
                        }
                    },
                    {
                        "Faqs",  new BsonDocument
                        {
                            { "$first", "$Faqs" },
                        }
                    },
                    {
                        "ProfileImage",  new BsonDocument
                        {
                            { "$first", "$ProfileImage" },
                        }
                    },
                    {
                        "Images",  new BsonDocument
                        {
                            { "$first", "$Images" },
                        }
                    },
                    {
                        "Team",  new BsonDocument
                        {
                            { "$first", "$Team" },
                        }
                    },
                    {
                        "SocialMediaPresence",  new BsonDocument
                        {
                            { "$first", "$SocialMediaPresence" },
                        }
                    },
                    {
                        "SpecialOffers",  new BsonDocument
                        {
                            { "$first", "$SpecialOffers" },
                        }
                    },
                    {
                        "Listings", new BsonDocument
                        {
                            { "$push", "$Listings" },
                        }
                    },
                });

            var count = pipeline.Count().FirstOrDefault();
            total = count == null ? 0 : (int)count.Count;

            return pipeline
                .Skip(offset)
                .Limit(limit)
                .ToList()
                .Select(x => BsonSerializer.Deserialize<SupplierDetail>(x));
        }

        /// <inheritdoc/>
        public async Task<SupplierDetail> SaveSupplierAsync(SupplierDetail supplier)
        {
            SupplierDetail result = null;
            if (supplier.Identifier != null)
            {
                result = await this.datastore.UpdateAsync(x => x.Identifier == supplier.Identifier, supplier);
            }
            else
            {
                result = await this.datastore.InsertAsync(supplier);
            }

            return supplier;
        }

        /// <inheritdoc/>
        public async Task DeleteSupplierAsync(string identifier)
        {
            await this.datastore.RemoveAsync<SupplierDetail>(x => x.Identifier == identifier);
        }

        /// <inheritdoc/>
        public string GetSupplierIdFromLegacyId(int legacyIdentifier)
        {
            return this.datastore.Get<SupplierDetail>()
                .Where(x => x.LegacyIdentifier == legacyIdentifier)
                .FirstOrDefault()?.Identifier;
        }
    }
}
