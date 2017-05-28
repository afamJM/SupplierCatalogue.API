namespace SupplierCatalogue.Models
{
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
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int Priority { get; set; }
    }
}
