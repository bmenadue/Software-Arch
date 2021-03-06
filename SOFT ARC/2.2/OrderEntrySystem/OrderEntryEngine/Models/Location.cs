﻿using System.Collections.Generic;
using OrderEntryEngine.Models;

namespace OrderEntryEngine
{
    /// <summary>
    /// Represents a Location.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets a ICollection of products.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

        /// <summary>
        /// Overrides the to string method.
        /// </summary>
        /// <returns>The new string.</returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}