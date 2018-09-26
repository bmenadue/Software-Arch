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

            var locations = new List<Location>
                {
                    new Location { Name = "Warehouse", City="Stevens Point", Description="Over yander", State="WI" },
                    new Location { Name = "Backyard", City="Stevens Point", Description="Over yander", State="WI" },
                 };

            context.Locations.AddRange(locations);

            context.SaveChanges();

            var products = new List<Product>
                {
                    new Product { Name = "Toy", Description="Toy boi", LocationID=1, Price=0.99m },
                    new Product { Name = "Car", Description="Toy boi", LocationID=2, Price=0.99m  },
                    new Product { Name = "House", Description="Toy boi", LocationID=1, Price=0.99m  }
                 };

            context.Products.AddRange(products);

            context.SaveChanges();

            var customers = new List<Customer>
                {
                    new Customer { FirstName = "Anna", Address="2640 Bush CT", City="Stevens Point", Email="email@email.com", LastName="Goldbach", Phone="911", State="WI" },
                    new Customer { FirstName = "Alex", Address="2640 Bush CT", City="Stevens Point", Email="email@email.com", LastName="Goldbach", Phone="911", State="WI" },
                 };

            context.Customers.AddRange(customers);

            context.SaveChanges();

        }
    }
}
