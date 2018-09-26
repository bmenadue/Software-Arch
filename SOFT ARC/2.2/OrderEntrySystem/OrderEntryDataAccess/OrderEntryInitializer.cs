using System.Collections.Generic;
using System.Data.Entity;
using OrderEntryEngine;
using OrderEntryEngine.Models;

namespace OrderEntryDataAccess
{
    /// <summary>
    /// Represents a Order Entry Initializer, which is a Database.
    /// </summary>
    public class OrderEntryInitializer : DropCreateDatabaseIfModelChanges<OrderEntryContext>
    {
        /// <summary>
        /// This adds a default amount of items.
        /// </summary>
        /// <param name="context">The database.</param>
        protected override void Seed(OrderEntryContext context)
        {
            var products = new List<Product>
                {
                    new Product { Name = "Toy" },
                    new Product { Name = "Car" },
                    new Product { Name = "House" }
                 };

            context.Products.AddRange(products);

            context.SaveChanges();

            var customers = new List<Customer>
                {
                    new Customer { FirstName = "Anna" },
                    new Customer { FirstName = "Alex" },
                 };

            context.Customers.AddRange(customers);

            context.SaveChanges();

            var locations = new List<Location>
                {
                    new Location { Name = "Warehouse" },
                    new Location { Name = "Backyard" },
                 };

            context.Locations.AddRange(locations);

            context.SaveChanges();
        }
    }
}
