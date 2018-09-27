using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderEntryEngine.Models;

namespace OrderEntryEngine
{
    /// <summary>
    /// Represents a category.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the FirstName.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a ICollection of the products.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

        /// <summary>
        /// Overrides the to string method.
        /// </summary>
        /// <returns>A string.</returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
