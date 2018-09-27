using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// Represents a category event argument.
    /// </summary>
    public class CategoryEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the CategoryEventArgs class.
        /// </summary>
        /// <param name="category">THe category being created.</param>
        public CategoryEventArgs(Category category)
        {
            this.Category = category;
        }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public Category Category { get; set; }
    }
}
