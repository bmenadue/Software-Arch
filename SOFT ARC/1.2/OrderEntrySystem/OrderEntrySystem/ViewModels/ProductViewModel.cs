using OrderEntryEngine.Models;

namespace OrderEntrySystem
{
    /// <summary>
    /// Represents a ProductViewModel, which is a view model.
    /// </summary>
    public class ProductViewModel : WorkspaceViewModel
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

        /// <summary>
        /// Gets or sets the Name property.
        /// </summary>
        public string Name
        {
            get
            {
                return this.product.Name;
            }

            set
            {
                this.product.Name = value;
            }
        }

        /// <summary>
        /// Gets or sets the Description property.
        /// </summary>
        public string Description
        {
            get
            {
                return this.product.Description;
            }

            set
            {
                this.product.Description = value;
            }
        }

        /// <summary>
        /// Gets or sets the Price property.
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.product.Price;
            }

            set
            {
                this.product.Price = value;
            }
        }

        /// <summary>
        /// This method creates commands.
        /// </summary>
        protected override void CreateCommands()
        {
        }
    }
}