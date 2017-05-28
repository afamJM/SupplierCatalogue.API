// <copyright file="SupplierOverview.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models.Responses
{
    using System;

    /// <summary>
    /// The overview of a supplier
    /// </summary>
    public class SupplierOverview : Supplier
    {
        private Uri detail;

        /// <summary>
        /// Gets or sets the star rating.
        /// </summary>
        /// <value>
        /// The star rating.
        /// </value>
        /// <remarks>
        /// Star rating is a number of half stars out of a mximum of five stars. Valid
        /// values are thefore 0 to 10.
        /// </remarks>
        public int StarRating { get; set; }

        /// <summary>
        /// Gets or sets the number of reviews available.
        /// </summary>
        /// <value>
        /// The review count.
        /// </value>
        public int ReviewCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this suppplier has a special offer.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has offer; otherwise, <c>false</c>.
        /// </value>
        public bool HasOffer { get; set; }

        /// <summary>
        /// Gets or sets the URI of the detail record for this supplier.
        /// </summary>
        /// <value>
        /// The detail.
        /// </value>
        public Uri Detail
        {
            get
            {
                return this.detail;
            }

            set
            {
                this.detail = value.AsAbsoluteUri();
            }
        }

        /// <summary>
        /// Gets or sets the number of images available for this supplier.
        /// </summary>
        /// <value>
        /// The image count.
        /// </value>
        public int ImageCount { get; set; }

        /// <summary>
        /// Gets or sets the type of the listing.
        /// </summary>
        /// <value>
        /// The type of the listing.
        /// </value>
        public string ListingType { get; set; }
    }
}
