namespace SupplierCatalogue.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// A collection of system constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Gets the valid supplier categories
        /// </summary>
        public static IEnumerable<Category> Categories { get; } = new List<Category>
        {
                new Category { Code = "album", Description = "Album and Guest Book" },
                new Category { Code = "beauty", Description = "Beauty, Hair & Make Up" },
                new Category { Code = "bridalwear", Description = "Bridalwear Shop" },
                new Category { Code = "cake", Description = "Cakes" },
                new Category { Code = "transport", Description = "Cars and Travel" },
                new Category { Code = "caterer", Description = "Catering" },
                new Category { Code = "celebrants", Description = "Celebrants" },
                new Category { Code = "chaircover", Description = "Chair Cover" },
                new Category { Code = "decorativehire", Description = "Decorative Hire" },
                new Category { Code = "destination", Description = "Destination Wedding" },
                new Category { Code = "cleaningandstorage", Description = "Dress Cleaning and Boxes" },
                new Category { Code = "drone", Description = "Drone" },
                new Category { Code = "entertainment", Description = "Entertainment" },
                new Category { Code = "favour", Description = "Favours" },
                new Category { Code = "firework", Description = "Fireworks" },
                new Category { Code = "choreography", Description = "First Dance Choreography" },
                new Category { Code = "florist", Description = "Florist" },
                new Category { Code = "groomswear", Description = "Groom Attire" },
                new Category { Code = "party", Description = "Hen and Stag Nights" },
                new Category { Code = "honeymoon", Description = "Honeymoon" },
                new Category { Code = "marquee", Description = "Marquee Hire" },
                new Category { Code = "mobilebar", Description = "Mobile Bar Services" },
                new Category { Code = "music", Description = "Music and DJs" },
                new Category { Code = "photobooth", Description = "Photo Booths" },
                new Category { Code = "photographer", Description = "Photographers" },
                new Category { Code = "miscelaneous", Description = "Something Different" },
                new Category { Code = "speechwriter", Description = "Speechwriting" },
                new Category { Code = "stationary", Description = "Stationery" },
                new Category { Code = "confectioner", Description = "Sweets and Treats" },
                new Category { Code = "toastmaster", Description = "Toastmaster" },
                new Category { Code = "videographer", Description = "Videographer" },
                new Category { Code = "accessory", Description = "Wedding Accessories" },
                new Category { Code = "nanny", Description = "Wedding Nanny" },
                new Category { Code = "planner", Description = "Wedding Planner" },
            }.AsReadOnly();

        /// <summary>
        /// Gets the valid listing types
        /// </summary>
        public static IEnumerable<ListingType> ListingTypes { get; } = new List<ListingType>
        {
            new ListingType { Code = "national", Priority = 3 },
            new ListingType { Code = "premium", Priority = 3 },
            new ListingType { Code = "enhanced", Priority = 5 },
            new ListingType { Code = "standard", Priority = 6 },
            new ListingType { Code = "freetrial", Priority = 7 },
            new ListingType { Code = "topslot", Priority = 1 },
            new ListingType { Code = "spotlight", Priority = 2 },
        }.AsReadOnly();
    }
}
