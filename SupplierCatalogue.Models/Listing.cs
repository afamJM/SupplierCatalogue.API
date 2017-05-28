namespace SupplierCatalogue.Models
{
    using System;

    /// <summary>
    /// A listing
    /// </summary>
    public class Listing
    {
        /// <summary>
        /// Gets or sets listing types
        /// </summary>
        /// <summary>
        /// Gets or sets the other locations.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public Location Location { get; set; }

        /// <summary>
        /// Gets or sets the type of the listing.
        /// </summary>
        /// <value>
        /// The type of the listing.
        /// </value>
        public ListingType ListingType { get; set; }

        /// <summary>
        /// Gets or sets the expiry of the listing.
        /// </summary>
        /// <value>
        /// The expiry of the listing.
        /// </value>
        public DateTime ListingExpiry { get; set; }

        /// <summary>
        /// Gets or sets the weight of this listing for ordering purposes
        /// </summary>
        public int Weight { get; set; }
    }
}
