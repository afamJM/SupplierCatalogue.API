// <copyright file="ListingTypeResponse.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models.Responses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A standard response containing the valid listing types
    /// </summary>
    /// <seealso cref="SupplierCatalogue.Models.Responses.StandardResponse" />
    public class ListingTypeResponse : StandardResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListingTypeResponse"/> class.
        /// </summary>
        public ListingTypeResponse()
        {
            this.Pagination.Limit = 0;
            this.Pagination.Offset = 0;
            this.Pagination.Total = this.Data.ListingTypes.Count();
            this.Pagination.Returned = this.Data.ListingTypes.Count();
        }

        /// <summary>
        /// Gets or sets the listing types
        /// </summary>
        public new ListingTypesCollection Data { get; set; } = new ListingTypesCollection();

        /// <summary>
        /// A collection of listing types
        /// </summary>
        public class ListingTypesCollection
        {
            /// <summary>
            /// Gets or sets the listing types.
            /// </summary>
            /// <value>
            /// The listing types.
            /// </value>
            public IEnumerable<string> ListingTypes { get; set; } = Constants.ListingTypes.Select(x => x.Code);
        }

        /// <summary>
        /// A listing type
        /// </summary>
        public class ListingType
        {
            /// <summary>
            /// Gets or sets the code.
            /// </summary>
            /// <value>
            /// The code.
            /// </value>
            public int Code { get; set; }

            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            /// <value>
            /// The description.
            /// </value>
            public string Description { get; set; }
        }
    }
}
