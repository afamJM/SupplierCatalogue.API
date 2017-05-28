// <copyright file="Event.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// An event
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        /// <value>
        /// The contact.
        /// </value>
        public Person Contact { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>
        /// The short description.
        /// </value>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the admission cost.
        /// </summary>
        /// <value>
        /// The admission cost.
        /// </value>
        public double AdmissionCost { get; set; }

        /// <summary>
        /// Gets or sets the start date and time.
        /// </summary>
        /// <value>
        /// The start date and time.
        /// </value>
        public DateTime Starts { get; set; }

        /// <summary>
        /// Gets or sets the end date and time.
        /// </summary>
        /// <value>
        /// The end date and time.
        /// </value>
        public DateTime Ends { get; set; }
    }
}
