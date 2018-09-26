using OrderEntryEngine.Models;

namespace OrderEntryEngine
{
    /// <summary>
    /// Represents a Product event argument.
    /// </summary>
    public class ProductEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the ProductEventArgs class. 
        /// </summary>
        /// <param name="product">The product.</param>
        public ProductEventArgs(Product product)
        {
            this.Product = product;
        }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public Product Product { get; set; }
    }
}