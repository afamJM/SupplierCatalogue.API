// <copyright file="SupplierServiceTest.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SupplierCatalogue.API.Services;
    using SupplierCatalogue.API.Tests.Mocks;
    using SupplierCatalogue.Models;
    using Xunit;

    /// <summary>
    /// Tests for <see cref="SupplierService"/>
    /// </summary>
    public class SupplierServiceTest
    {
        private readonly MockDatastore datastore;
        private readonly ISupplierService supplierService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierServiceTest"/> class.
        /// </summary>
        public SupplierServiceTest()
        {
            this.datastore = new MockDatastore();
            this.supplierService = new SupplierService(this.datastore);
        }

#pragma warning disable xUnit1004

        /// <summary>
        /// Shoulds get all.
        /// </summary>
        [Fact(Skip="Changed from Linq to Mongo Aggregate Pipeline")]
        public void ShouldGetAll()
        {
            this.datastore.Values = new List<SupplierDetail>()
            {
                new BasicSupplier
                {
                    Identifier = "A",
                    Category = "test1",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
                new BasicSupplier
                {
                    Identifier = "B",
                    Category = "test2",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
                new BasicSupplier
                {
                    Identifier = "C",
                    Category = "test1",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
            };
            var suppliers = this.supplierService.GetSuppliers(null, null, null, out int total, 0, int.MaxValue);
            Assert.Equal(3, total);
            Assert.Equal(3, suppliers.Count());
        }

        /// <summary>
        /// Should filter by category.
        /// </summary>
        [Fact(Skip="Changed from Linq to Mongo Aggregate Pipeline")]
        public void ShouldFilterByCategory()
        {
            this.datastore.Values = new List<SupplierDetail>()
            {
                new BasicSupplier
                {
                    Identifier = "A",
                    Category = "test1",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
                new BasicSupplier
                {
                    Identifier = "B",
                    Category = "test2",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
                new BasicSupplier
                {
                    Identifier = "C",
                    Category = "test1",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
            };
            var suppliers = this.supplierService.GetSuppliers("test1", null, null, out int total, 0, int.MaxValue);
            Assert.Equal(2, total);
            Assert.Equal(2, suppliers.Count());
            Assert.True(suppliers.All(x => x.Category.Equals("test1")));
        }

        /// <summary>
        /// Should limit the number of results.
        /// </summary>
        [Fact(Skip="Changed from Linq to Mongo Aggregate Pipeline")]
        public void ShouldLimitNumberOfResults()
        {
            this.datastore.Values = new List<SupplierDetail>()
            {
                new BasicSupplier
                {
                    Identifier = "A",
                    Category = "test1",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
                new BasicSupplier
                {
                    Identifier = "B",
                    Category = "test2",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
                new BasicSupplier
                {
                    Identifier = "C",
                    Category = "test1",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
            };
            var suppliers = this.supplierService.GetSuppliers(null, null, null, out int total, 0, 2);
            Assert.Equal(3, total);
            Assert.Equal(2, suppliers.Count());
            Assert.Equal(2, suppliers.Where(x => x.Identifier.Equals("A") || x.Identifier.Equals("B")).Count());
        }

        /// <summary>
        /// Should respect the offset.
        /// </summary>
        [Fact(Skip="Changed from Linq to Mongo Aggregate Pipeline")]
        public void ShouldRespectOffset()
        {
            this.datastore.Values = new List<SupplierDetail>()
            {
                new BasicSupplier
                {
                    Identifier = "A",
                    Category = "test1",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
                new BasicSupplier
                {
                    Identifier = "B",
                    Category = "test2",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
                new BasicSupplier
                {
                    Identifier = "C",
                    Category = "test1",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
            };
            var suppliers = this.supplierService.GetSuppliers(null, null, null, out int total, 2, int.MaxValue);
            Assert.Equal(3, total);
            Assert.Equal(1, suppliers.Count());
            Assert.True(suppliers.Select(x => x.Identifier).First().Equals("C"));
        }

        /// <summary>
        /// Should respect the  combined limit and offset.
        /// </summary>
        [Fact(Skip="Changed from Linq to Mongo Aggregate Pipeline")]
        public void ShouldRespectCombinedLimitAndOffset()
        {
            this.datastore.Values = new List<SupplierDetail>()
            {
                new BasicSupplier
                {
                    Identifier = "A",
                    Category = "test1",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
                new BasicSupplier
                {
                    Identifier = "B",
                    Category = "test2",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
                new BasicSupplier
                {
                    Identifier = "C",
                    Category = "test1",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
            };
            var suppliers = this.supplierService.GetSuppliers(null, null, null, out int total, 1, 1);
            Assert.Equal(3, total);
            Assert.Equal(1, suppliers.Count());
            Assert.True(suppliers.Select(x => x.Identifier).First().Equals("B"));
        }

        /// <summary>
        /// Should respect the combine category limit and offset.
        /// </summary>
        [Fact(Skip="Changed from Linq to Mongo Aggregate Pipeline")]
        public void ShouldRespectCombineCategoryLimitAndOffset()
        {
            this.datastore.Values = new List<SupplierDetail>()
            {
                new BasicSupplier
                {
                    Identifier = "A",
                    Category = "test1",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
                new BasicSupplier
                {
                    Identifier = "B",
                    Category = "test2",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
                new BasicSupplier
                {
                    Identifier = "C",
                    Category = "test1",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
            };
            var suppliers = this.supplierService.GetSuppliers("test1", null, null, out int total, 1, 1);
            Assert.Equal(2, total);
            Assert.Equal(1, suppliers.Count());
            Assert.True(suppliers.Select(x => x.Identifier).First().Equals("C"));
        }

        /// <summary>
        /// Should succeed when the limit is greater than the total.
        /// </summary>
        [Fact(Skip="Changed from Linq to Mongo Aggregate Pipeline")]
        public void ShouldSucceedWhenLimitIsGreaterThanTotal()
        {
            this.datastore.Values = new List<SupplierDetail>()
            {
                new BasicSupplier
                {
                    Identifier = "A",
                    Category = "test1",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
                new BasicSupplier
                {
                    Identifier = "B",
                    Category = "test2",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
                new BasicSupplier
                {
                    Identifier = "C",
                    Category = "test1",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
            };
            var suppliers = this.supplierService.GetSuppliers(null, null, null, out int total, 0, 5);
            Assert.Equal(3, total);
            Assert.Equal(3, suppliers.Count());
        }

        /// <summary>
        /// Should succeed when the limit is greater than the remianing.
        /// </summary>
        [Fact(Skip="Changed from Linq to Mongo Aggregate Pipeline")]
        public void ShouldSucceedWhenLimitIsGreaterThanRemianing()
        {
            this.datastore.Values = new List<SupplierDetail>()
            {
                new BasicSupplier
                {
                    Identifier = "A",
                    Category = "test1",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
                new BasicSupplier
                {
                    Identifier = "B",
                    Category = "test2",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
                new BasicSupplier
                {
                    Identifier = "C",
                    Category = "test1",
                    Listings =
                     new Listing[]
                     {
                        new Listing
                        {
                            Location = new Location
                            {
                                Name = "Surrey",
                            },
                            ListingExpiry = DateTime.MaxValue,
                            ListingType = Constants.ListingTypes.Where(x => x.Code.Equals("enhanced")).FirstOrDefault(),
                        },
                     },
                },
            };
            var suppliers = this.supplierService.GetSuppliers(null, null, null, out int total, 1, 3);
            Assert.Equal(3, total);
            Assert.Equal(2, suppliers.Count());
            Assert.Equal(2, suppliers.Where(x => x.Identifier.Equals("B") || x.Identifier.Equals("C")).Count());
        }

#pragma warning restore xUnit1004

    }
}
