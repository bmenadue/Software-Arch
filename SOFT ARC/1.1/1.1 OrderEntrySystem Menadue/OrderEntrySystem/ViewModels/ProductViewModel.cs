using OrderEntryEngine.Models;

namespace OrderEntrySystem
{
    /// <summary>
    /// Represents a ProductViewModel, which is a view model.
    /// </summary>
    public class ProductViewModel : ViewModel
    {
        /// <summary>
        /// Is the ProductViewModel Product.
        /// </summary>
        private Product product;

        /// <summary>
        /// Initializes a new instance of the ProductViewModel class.
        /// </summary>
        /// <param name="product">The product being assigned.</param>
        public ProductViewModel(Product product)
        : base("Product")
        {
            this.product = product;
        }

        /// <summary>
        /// Gets or sets the Location property.
        /// </summary>
        public string Location
        {
            get
            {
                return this.product.Location;
            }

            set
            {
                this.product.Location = value;
            }
        }
    }
}
