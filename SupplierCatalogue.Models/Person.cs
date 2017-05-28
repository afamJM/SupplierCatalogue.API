// <copyright file="Person.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A Person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the title of the person.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the given name of the peson.
        /// </summary>
        /// <value>
        /// The name of the given.
        /// </value>
        public string GivenName { get; set; }

        /// <summary>
        /// Gets or sets the family name of the person.
        /// </summary>
        /// <value>
        /// The name of the family.
        /// </value>
        public string FamilyName { get; set; }

        /// <summary>
        /// Gets or sets the job title of the person.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the person's profile image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public Image ProfileImage { get; set; }

        /// <summary>
        /// Gets or sets the email address of the person.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the list of social media listings.
        /// </summary>
        /// <value>
        /// The social media listings.
        /// </value>
        public IEnumerable<SocialMediaPresence> SocialMediaPresence { get; set; }
    }
}
