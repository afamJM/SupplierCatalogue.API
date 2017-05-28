// <copyright file="GenericSupplier.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models.Requests
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A generic supplier
    /// </summary>
    public class GenericSupplier
    {
        private Uri website;

        /// <summary>
        /// Gets or sets the identifier for the leagacy system.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int? LegacyIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the business.
        /// </summary>
        /// <value>
        /// The business.
        /// </value>
        public Business Business { get; set; }

        /// <summary>
        /// Gets or sets the supplier category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the supplier website URI.
        /// </summary>
        /// <value>
        /// The website URI.
        /// </value>
        public Uri Website
        {
            get
            {
                return this.website;
            }

            set
            {
                this.website = value.AsAbsoluteUri();
            }
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
        public IEnumerable<Listing> Listings { get; set; }

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
        public IEnumerable<Review> Reviews { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the FAQ list.
        /// </summary>
        /// <value>
        /// The faqs.
        /// </value>
        public IEnumerable<Faq> Faqs { get; set; }

        /// <summary>
        /// Gets or sets the cover image.
        /// </summary>
        /// <value>
        /// The cover image.
        /// </value>
        public Image CoverImage { get; set; }

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
        public IEnumerable<Image> Images { get; set; }

        /// <summary>
        /// Gets or sets the list of team members.
        /// </summary>
        /// <value>
        /// The team.
        /// </value>
        public IEnumerable<Person> Team { get; set; }

        /// <summary>
        /// Gets or sets the list of social media listings.
        /// </summary>
        /// <value>
        /// The social media listings.
        /// </value>
        public IEnumerable<SocialMediaPresence> SocialMediaPresence { get; set; }

        /// <summary>
        /// Gets or sets the list of special offers.
        /// </summary>
        /// <value>
        /// The special offers.
        /// </value>
        public IEnumerable<SpecialOffer> SpecialOffers { get; set; }

        /// <summary>
        /// Gets or sets the treatments offered (beauticians only).
        /// </summary>
        /// <value>
        /// The treatments.
        /// </value>
        public IEnumerable<string> Treatments { get; set; }

        /// <summary>
        /// Gets or sets the designers stocked (bridalwear suppliers only).
        /// </summary>
        /// <value>
        /// The designers.
        /// </value>
        public IEnumerable<Designer> Designers { get; set; }

        /// <summary>
        /// Gets or sets the list of styles offered (cake suppliers, musicians and videographers only).
        /// </summary>
        /// <value>
        /// The styles.
        /// </value>
        public IEnumerable<string> Styles { get; set; }
    }
}
