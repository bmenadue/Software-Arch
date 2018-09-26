using OrderEntryEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
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

        public virtual ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

    }
}
