using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using OrderEntryDataAccess;
using OrderEntryEngine;

namespace OrderEntrySystem
{
    /// <summary>
    /// Represents a Multi product view model, which is a work space view model.
    /// </summary>
    public class MultiProductViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// Private repo for the multi product view model.
        /// </summary>
        private Repository repo;

        /// <summary>
        /// Initializes a new instance of the MultiProductViewModel class.
        /// </summary>
        /// <param name="repo">The repo storing data.</param>
        public MultiProductViewModel(Repository repo)
            : base("Multi Product")
        {
            this.repo = repo;

            List<ProductViewModel> products =
                (from p in this.repo.GetProducts()
                 select new ProductViewModel(p, this.repo)).ToList();

            products.ForEach(pvm => pvm.PropertyChanged += this.OnProductViewModelPropertyChanged);

            this.AllProducts = new ObservableCollection<ProductViewModel>(products);

            this.repo.ProductAdded += this.OnProductAdded;
        }

        /// <summary>
        /// Gets or sets AllProducts.
        /// </summary>
        public ObservableCollection<ProductViewModel> AllProducts { get; set; }

        /// <summary>
        /// Gets the number of items selected.
        /// </summary>
        public int NumberOfItemsSelected
        {
            get
            {
                return this.AllProducts.Count(vm => vm.IsSelected);
            }
        }

        /// <summary>
        /// This creates commands.
        /// </summary>
        protected override void CreateCommands()
        {
        }

        /// <summary>
        /// What happens when adding a product.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event argument.</param>
        private void OnProductAdded(object sender, ProductEventArgs e)
        {
            ProductViewModel viewModel = new ProductViewModel(e.Product, this.repo);

            viewModel.PropertyChanged += this.OnProductViewModelPropertyChanged;

            this.AllProducts.Add(viewModel);
        }

        /// <summary>
        /// When the property changes on the product view model.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event argument.</param>
        private void OnProductViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                this.OnPropertyChanged("NumberOfItemsSelected");
            }
        }
    }
}