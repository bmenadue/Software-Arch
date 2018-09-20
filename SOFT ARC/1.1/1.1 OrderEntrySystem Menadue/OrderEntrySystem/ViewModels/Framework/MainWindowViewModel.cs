using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using OrderEntryEngine.Models;

namespace OrderEntrySystem
{
    /// <summary>
    /// Represents a MainWindowViewModel which is a ViewModel.
    /// </summary>
    public class MainWindowViewModel : ViewModel
    {
        /// <summary>
        /// The viewModels field, that is a ObservableCollection.
        /// </summary>
        private ObservableCollection<ViewModel> viewModels;

        /// <summary>
        /// Initializes a new instance of the MainWindowViewModel class.
        /// </summary>
        public MainWindowViewModel()
            : base("Order Entry System - Menadue")
        {
        }

        /// <summary>
        /// Gets The viewModels field, that is a ObservableCollection.
        /// </summary>
        public ObservableCollection<ViewModel> ViewModels
        {
            get
            {
                if (this.viewModels == null)
                {
                    this.viewModels = new ObservableCollection<ViewModel>();
                }

                return this.viewModels;
            }
        }

        /// <summary>
        /// This method creates a new view model.
        /// </summary>
        public void CreateNewProduct()
        {
            Product product = new Product { Location = "Main Warehouse" };
            ProductViewModel pvm = new ProductViewModel(product);
            this.viewModels.Add(pvm);
            this.ActivateViewModel(pvm);
        }

        /// <summary>
        /// This method activates the ViewModel.
        /// </summary>
        /// <param name="viewModel">The view model you are activating.</param>
        private void ActivateViewModel(ViewModel viewModel)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.viewModels);

            if (collectionView != null)
            {
                collectionView.MoveCurrentTo(viewModel);
            }
        }
    }
}
