// <copyright file="Supplier.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models
{
    using System;
    using System.Collections.Generic;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;

    /// <summary>
    /// A supplier
    /// </summary>
    [Entity("supplier")]
    [BsonKnownTypes(
        typeof(BasicSupplier),
        typeof(Beautician),
        typeof(BridalwearSupplier),
        typeof(CakeSupplier),
        typeof(Musician),
        typeof(Videographer))]
    [BsonIgnoreExtraElements(true)]
    public abstract class SupplierDetail : Supplier
    {
        private Uri website;

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the leagacy system.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [BsonDefaultValue(null)]
        public int? LegacyIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the business.
        /// </summary>
        /// <value>
        /// The business.
        /// </value>
        public Business Business { get; set; }

        /// <summary>
        /// Gets or sets the supplier website URI.
        /// </summary>
        /// <value>
        /// The website URI.
        /// </value>
        public Uri Website
        {
            get { return this.website; }

            set { this.website = value.AsAbsoluteUri(); }
        }

        /// <summary>
        /// Gets or sets the home location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public Location Location { get; set; }

        /// <summary>
        /// Gets or sets the suppliers listings.
        /// </summary>
        /// <value>
        /// The listings.
        /// </value>
        public IEnumerable<Listing> Listings { get; set; } = new List<Listing>();

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
        /// Gets or sets the reviews.
        /// </summary>
        /// <value>
        /// The reviews.
        /// </value>
        public IEnumerable<Review> Reviews { get; set; } = new List<Review>();

        /// <summary>
        /// Gets or sets the FAQ list.
        /// </summary>
        /// <value>
        /// The faqs.
        /// </value>
        public IEnumerable<Faq> Faqs { get; set; } = new List<Faq>();

        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        /// <value>
        /// The profile image.
        /// </value>
        public Image ProfileImage { get; set; }

        /// <summary>
        /// Gets or sets the list of images.
        /// </summary>
        /// <value>
        /// The list of images.
        /// </value>
        public IEnumerable<Image> Images { get; set; } = new List<Image>();

        /// <summary>
        /// Gets or sets the list of team members.
        /// </summary>
        /// <value>
        /// The team.
        /// </value>
        public IEnumerable<Person> Team { get; set; } = new List<Person>();

        /// <summary>
        /// Gets or sets the list of social media listings.
        /// </summary>
        /// <value>
        /// The social media listings.
        /// </value>
        public IEnumerable<SocialMediaPresence> SocialMediaPresence { get; set; } = new List<SocialMediaPresence>();

        /// <summary>
        /// Gets or sets the list of special offers.
        /// </summary>
        /// <value>
        /// The special offers.
        /// </value>
        public IEnumerable<SpecialOffer> SpecialOffers { get; set; } = new List<SpecialOffer>();
    }
}
