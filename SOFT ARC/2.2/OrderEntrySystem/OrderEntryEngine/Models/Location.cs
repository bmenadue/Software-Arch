using OrderEntryEngine.Models;
using System.Collections.Generic;

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

        public virtual ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}