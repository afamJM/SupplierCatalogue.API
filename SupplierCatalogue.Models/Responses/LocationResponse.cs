// <copyright file="LocationResponse.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models.Responses
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A standard response containing the valid locations
    /// </summary>
    /// <seealso cref="SupplierCatalogue.Models.Responses.StandardResponse" />
    public class LocationResponse : StandardResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationResponse"/> class.
        /// </summary>
        public LocationResponse()
        {
            this.Pagination.Limit = 0;
            this.Pagination.Offset = 0;
            this.Pagination.Total = this.Data.Locations.Count();
            this.Pagination.Returned = this.Data.Locations.Count();
        }

        /// <summary>
        /// Gets or sets the locations
        /// </summary>
        public new LocationCollection Data { get; set; } = new LocationCollection();

        /// <summary>
        /// A collection of locations
        /// </summary>
        /// <param name="name">The name of the location</param>
        /// <returns>The location code</returns>
        public string FetchLocationCode(string name)
        {
            IEnumerable<ListingLocation> searchLocation = this.Data.Locations.Where(x => x.Name.Equals(name));
            return searchLocation.Count() > 0 ? searchLocation.First().Code : "unknown";
        }

        /// <summary>
        /// A collection of locations
        /// </summary>
        public class LocationCollection
        {
            /// <summary>
            /// Gets or sets the locations.
            /// </summary>
            /// <value>
            /// The locations.
            /// </value>
            public IEnumerable<ListingLocation> Locations { get; set; } = new List<ListingLocation>()
            {
                new ListingLocation { Code = "buckinghamshire", Name = "Buckinghamshire" },
                new ListingLocation { Code = "cambridgeshire", Name = "Cambridgeshire" },
                new ListingLocation { Code = "cheshire", Name = "Cheshire" },
                new ListingLocation { Code = "cleveland", Name = "Cleveland" },
                new ListingLocation { Code = "cornwall", Name = "Cornwall" },
                new ListingLocation { Code = "cumbria", Name = "Cumbria" },
                new ListingLocation { Code = "derbyshire", Name = "Derbyshire" },
                new ListingLocation { Code = "devon", Name = "Devon" },
                new ListingLocation { Code = "dorset", Name = "Dorset" },
                new ListingLocation { Code = "durham", Name = "Durham" },
                new ListingLocation { Code = "east-sussex", Name = "East Sussex" },
                new ListingLocation { Code = "essex", Name = "Essex" },
                new ListingLocation { Code = "gloucestershire", Name = "Gloucestershire" },
                new ListingLocation { Code = "london", Name = "London" },
                new ListingLocation { Code = "manchester", Name = "Greater Manchester" },
                new ListingLocation { Code = "hampshire", Name = "Hampshire" },
                new ListingLocation { Code = "hertfordshire", Name = "Hertfordshire" },
                new ListingLocation { Code = "kent", Name = "Kent" },
                new ListingLocation { Code = "lancashire", Name = "Lancashire" },
                new ListingLocation { Code = "leicestershire", Name = "Leicestershire" },
                new ListingLocation { Code = "lincolnshire", Name = "Lincolnshire" },
                new ListingLocation { Code = "merseyside", Name = "Merseyside" },
                new ListingLocation { Code = "norfolk", Name = "Norfolk" },
                new ListingLocation { Code = "north-yorkshire", Name = "North Yorkshire" },
                new ListingLocation { Code = "northamptonshire", Name = "Northamptonshire" },
                new ListingLocation { Code = "northumberland", Name = "Northumberland" },
                new ListingLocation { Code = "nottinghamshire", Name = "Nottinghamshire" },
                new ListingLocation { Code = "oxfordshire", Name = "Oxfordshire" },
                new ListingLocation { Code = "shropshire", Name = "Shropshire" },
                new ListingLocation { Code = "somerset", Name = "Somerset" },
                new ListingLocation { Code = "south-yorkshire", Name = "South Yorkshire" },
                new ListingLocation { Code = "staffordshire", Name = "Staffordshire" },
                new ListingLocation { Code = "suffolk", Name = "Suffolk" },
                new ListingLocation { Code = "surrey", Name = "Surrey" },
                new ListingLocation { Code = "tyne and Wear", Name = "Tyne and Wear" },
                new ListingLocation { Code = "warwickshire", Name = "Warwickshire" },
                new ListingLocation { Code = "berkshire", Name = "Berkshire" },
                new ListingLocation { Code = "west-midlands", Name = "West Midlands" },
                new ListingLocation { Code = "west-sussex", Name = "West Sussex" },
                new ListingLocation { Code = "west-yorkshire", Name = "West Yorkshire" },
                new ListingLocation { Code = "wiltshire", Name = "Wiltshire" },
                new ListingLocation { Code = "worcestershire", Name = "Worcestershire" },
                new ListingLocation { Code = "flintshire", Name = "Flintshire" },
                new ListingLocation { Code = "glamorgan", Name = "Glamorgan" },
                new ListingLocation { Code = "merionethshire", Name = "Merionethshire" },
                new ListingLocation { Code = "monmouthshire", Name = "Monmouthshire" },
                new ListingLocation { Code = "montgomeryshire", Name = "Montgomeryshire" },
                new ListingLocation { Code = "pembrokeshire", Name = "Pembrokeshire" },
                new ListingLocation { Code = "radnorshire", Name = "Radnorshire" },
                new ListingLocation { Code = "anglesey", Name = "Anglesey" },
                new ListingLocation { Code = "breconshire", Name = "Breconshire" },
                new ListingLocation { Code = "caernarvonshire", Name = "Caernarvonshire" },
                new ListingLocation { Code = "cardiganshire", Name = "Cardiganshire" },
                new ListingLocation { Code = "carmarthenshire", Name = "Carmarthenshire" },
                new ListingLocation { Code = "denbighshire", Name = "Denbighshire" },
                new ListingLocation { Code = "aberdeen_city", Name = "Aberdeen City" },
                new ListingLocation { Code = "aberdeenshire", Name = "Aberdeenshire" },
                new ListingLocation { Code = "angus", Name = "Angus" },
                new ListingLocation { Code = "argyll-bute", Name = "Argyll and Bute" },
                new ListingLocation { Code = "edinburgh", Name = "City of Edinburgh" },
                new ListingLocation { Code = "clackmannanshire", Name = "Clackmannanshire" },
                new ListingLocation { Code = "dumfries-galloway", Name = "Dumfries and Galloway" },
                new ListingLocation { Code = "dundee", Name = "Dundee City" },
                new ListingLocation { Code = "east-ayrshire", Name = "East Ayrshire" },
                new ListingLocation { Code = "east-dunbartonshire", Name = "East Dunbartonshire" },
                new ListingLocation { Code = "east-lothian", Name = "East Lothian" },
                new ListingLocation { Code = "east-renfrewshire", Name = "East Renfrewshire" },
                new ListingLocation { Code = "eilean-siar", Name = "Eilean Siar" },
                new ListingLocation { Code = "falkirk", Name = "Falkirk" },
                new ListingLocation { Code = "fife", Name = "Fife" },
                new ListingLocation { Code = "glasgow", Name = "Glasgow City" },
                new ListingLocation { Code = "highland", Name = "Highland" },
                new ListingLocation { Code = "inverclyde", Name = "Inverclyde" },
                new ListingLocation { Code = "midlothian", Name = "Midlothian" },
                new ListingLocation { Code = "moray", Name = "Moray" },
                new ListingLocation { Code = "north-ayrshire", Name = "North Ayrshire" },
                new ListingLocation { Code = "north-lanarkshire", Name = "North Lanarkshire" },
                new ListingLocation { Code = "orkney-islands", Name = "Orkney Islands" },
                new ListingLocation { Code = "perth-kinross", Name = "Perth and Kinross" },
                new ListingLocation { Code = "renfrewshire", Name = "Renfrewshire" },
                new ListingLocation { Code = "scottish-borders", Name = "Scottish Borders" },
                new ListingLocation { Code = "shetland-islands", Name = "Shetland Islands" },
                new ListingLocation { Code = "south-asyrshire", Name = "South Ayrshire" },
                new ListingLocation { Code = "south-lanarkshire", Name = "South Lanarkshire" },
                new ListingLocation { Code = "stirling", Name = "Stirling" },
                new ListingLocation { Code = "west-dunbartonshire", Name = "West Dunbartonshire" },
                new ListingLocation { Code = "west-lothian", Name = "West Lothian" },
                new ListingLocation { Code = "antrim", Name = "Antrim" },
                new ListingLocation { Code = "armagh", Name = "Armagh" },
                new ListingLocation { Code = "down", Name = "Down" },
                new ListingLocation { Code = "fermanagh", Name = "Fermanagh" },
                new ListingLocation { Code = "derry-londonderry", Name = "Derry and Londonderry" },
                new ListingLocation { Code = "tyrone", Name = "Tyrone" },
            };
        }

        /// <summary>
        /// A location
        /// </summary>
        public class ListingLocation
        {
            /// <summary>
            /// Gets or sets the code.
            /// </summary>
            /// <value>
            /// The code.
            /// </value>
            public string Code { get; set; }

            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>
            /// The name.
            /// </value>
            public string Name { get; set; }
        }
    }
}