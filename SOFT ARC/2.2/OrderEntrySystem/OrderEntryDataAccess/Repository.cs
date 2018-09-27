using System;
using System.Collections.Generic;
using System.Linq;
using OrderEntryEngine;
using OrderEntryEngine.Models;

namespace OrderEntryDataAccess
{
    /// <summary>
    /// Represents a repository.
    /// </summary>
    public class Repository
    {
        #region events/fields

        /// <summary>
        /// Creates a new order entry context.
        /// </summary>
        public OrderEntryContext context = new OrderEntryContext();

        /// <summary>
        /// Event for product added.
        /// </summary>
        public event EventHandler<ProductEventArgs> ProductAdded;

        /// <summary>
        /// Event for customer added.
        /// </summary>
        public event EventHandler<CustomerEventArgs> CustomerAdded;

        /// <summary>
        /// Event for adding location.
        /// </summary>
        public event EventHandler<LocationEventArgs> LocationAdded;

        /// <summary>
        /// Event for adding location.
        /// </summary>
        public event EventHandler<CategoryEventArgs> CategoryAdded;

        #endregion

        /// <summary>
        /// This saves the context to the database.
        /// </summary>
        public void SaveToDatabase()
        {
            this.context.SaveChanges();
        }

        #region get lists
        /// <summary>
        /// Gets the list of customers.
        /// </summary>
        /// <returns>The list of customers.</returns>
        public List<Customer> GetCustomers()
        {
            return this.context.Customers.ToList();
        }

        /// <summary>
        /// Gets the list of products.
        /// </summary>
        /// <returns>The list of products.</returns>
        public List<Product> GetProducts()
        {
            return this.context.Products.ToList();
        }

        /// <summary>
        /// Gets the locations.
        /// </summary>
        /// <returns>The list of locations.</returns>
        public List<Location> GetLocations()
        {
            return this.context.Locations.ToList();
        }

        /// <summary>
        /// Gets the locations.
        /// </summary>
        /// <returns>The list of locations.</returns>
        public List<Category> GetCategories()
        {
            return this.context.Categorys.ToList();
        }
        #endregion

        #region add
        /// <summary>
        /// When you add products.
        /// </summary>
        /// <param name="product">The product being added.</param>
        public void AddProducts(Product product)
        {
            if (!this.ContainsProducts(product))
            {
                this.context.Products.Add(product);

                if (this.ProductAdded != null)
                {
                    this.ProductAdded(this, new ProductEventArgs(product));
                }
            }
        }

        /// <summary>
        /// Adding a customer.
        /// </summary>
        /// <param name="customer">The customer being added.</param>
        public void AddCustomer(Customer customer)
        {
            if (!this.ContainsCustomers(customer))
            {
                this.context.Customers.Add(customer);

                if (this.CustomerAdded != null)
                {
                    this.CustomerAdded(this, new CustomerEventArgs(customer));
                }
            }
        }

        /// <summary>
        /// When you add a location.
        /// </summary>
        /// <param name="location">The location being added.</param>
        public void AddLocation(Location location)
        {
            if (!this.ContainsLocation(location))
            {
                this.context.Locations.Add(location);

                if (this.LocationAdded != null)
                {
                    this.LocationAdded(this, new LocationEventArgs(location));
                }
            }
        }

        /// <summary>
        /// When you add a location.
        /// </summary>
        /// <param name="category">The location being added.</param>
        public void AddCategory(Category category)
        {
            if (!this.ContainsCategory(category))
            {
                this.context.Categorys.Add(category);

                if (this.CategoryAdded != null)
                {
                    this.CategoryAdded(this, new CategoryEventArgs(category));
                }
            }
        }

        #endregion

        #region contains
        /// <summary>
        /// Checks if contains a location.
        /// </summary>
        /// <param name="location">The location being checked.</param>
        /// <returns>True or false.</returns>
        private bool ContainsLocation(Location location)
        {
            return this.GetLocation(location.Id) != null;
        }

        /// <summary>
        /// Checks if contains a customer.
        /// </summary>
        /// <param name="customer">The customer being checked.</param>
        /// <returns>True or false.</returns>
        private bool ContainsCustomers(Customer customer)
        {
            return this.GetCustomer(customer.Id) != null;
        }

        /// <summary>
        /// Checks if it contains the product.
        /// </summary>
        /// <param name="product">The product being checked.</param>
        /// <returns>True or false.</returns>
        private bool ContainsProducts(Product product)
        {
            return this.GetProduct(product.Id) != null;
        }

        /// <summary>
        /// Checks if it contains the product.
        /// </summary>
        /// <param name="category">The product being checked.</param>
        /// <returns>True or false.</returns>
        private bool ContainsCategory(Category category)
        {
            return this.GetCategory(category.Id) != null;
        }

        #endregion

        #region get items

        /// <summary>
        /// Gets the list of customers.
        /// </summary>
        /// <returns>The list of customers.</returns>
        /// <param name="id">The id of the customer.</param>
        private Customer GetCustomer(int id)
        {
            return this.context.Customers.Find(id);
        }

        /// <summary>
        /// Gets the list of products.
        /// </summary>
        /// <returns>The list of products.</returns>
        /// <param name="id">The id of the product.</param>
        private Product GetProduct(int id)
        {
            return this.context.Products.Find(id);
        }

        /// <summary>
        /// Gets the locations.
        /// </summary>
        /// <returns>The list of locations.</returns>
        /// <param name="id">The id of the location.</param>
        private Location GetLocation(int id)
        {
            return this.context.Locations.Find(id);
        }

        /// <summary>
        /// Gets the locations.
        /// </summary>
        /// <returns>The list of locations.</returns>
        /// <param name="id">The id of the location.</param>
        private Category GetCategory(int id)
        {
            return this.context.Categorys.Find(id);
        }

        #endregion
    }
}