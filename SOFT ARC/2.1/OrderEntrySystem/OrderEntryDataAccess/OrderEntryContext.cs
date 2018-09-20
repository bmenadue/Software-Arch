using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderEntryEngine;
using OrderEntryEngine.Models;

namespace OrderEntryDataAccess
{
    /// <summary>
    /// This is a Order entry context class, which is a DbContext.
    /// </summary>
    public class OrderEntryContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the OrderEntryContext class.
        /// </summary>
        public OrderEntryContext()
            : base("OrderEntryContext")
        {
            Database.Initialize(true);
        }

        /// <summary>
        /// Gets or sets the Products.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the Customers.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the Locations.
        /// </summary>
        public DbSet<Location> Locations { get; set; }
    }
}
