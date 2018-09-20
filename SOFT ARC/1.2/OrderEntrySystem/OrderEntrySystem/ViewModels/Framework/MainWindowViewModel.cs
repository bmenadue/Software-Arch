using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using OrderEntryEngine;
using OrderEntryEngine.Models;

namespace OrderEntrySystem
{
    /// <summary>
    /// Represents a MainWindowViewModel which is a ViewModel.
    /// </summary>
    public class MainWindowViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// The viewModels field, that is a ObservableCollection.
        /// </summary>
        private ObservableCollection<WorkspaceViewModel> viewModels;

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
        public ObservableCollection<WorkspaceViewModel> ViewModels
        {
            get
            {
                if (this.viewModels == null)
                {
                    this.viewModels = new ObservableCollection<WorkspaceViewModel>();
                }

                return this.viewModels;
            }
        }

        /// <summary>
        /// This method creates a new view model.
        /// </summary>
        public void CreateNewProduct()
        {
            Product product = new Product { Location = "Main Warehouse", Description = "This is a product", Name = "This is the name", Price = 0 };
            ProductViewModel pvm = new ProductViewModel(product);
            pvm.RequestClose += this.OnWorkspaceRequestClose;
            this.ViewModels.Add(pvm);
            this.ActivateViewModel(pvm);
        }

        /// <summary>
        /// This method creates a new view model of customer.
        /// </summary>
        public void CreateNewCustomer()
        {
            Customer customer = new Customer { FirstName = "Anna", LastName = "Goldbach", Address = "2000 College Ave", City = "Stevens Point", Email = "anna@email.com", Phone = "911", State = "WI" };
            CustomerViewModel cvm = new CustomerViewModel(customer);
            cvm.RequestClose += this.OnWorkspaceRequestClose;
            this.viewModels.Add(cvm);
            this.ActivateViewModel(cvm);
        }

        /// <summary>
        /// This method creates individual view models.
        /// </summary>
        protected override void CreateCommands()
        {
            this.Commands.Add(new CommandViewModel("New product", new DelegateCommand(p => this.CreateNewProduct())));
            this.Commands.Add(new CommandViewModel("New Customer", new DelegateCommand(p => this.CreateNewCustomer())));
        }

        /// <summary>
        /// This method activates the ViewModel.
        /// </summary>
        /// <param name="viewModel">The view model you are activating.</param>
        private void ActivateViewModel(WorkspaceViewModel viewModel)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.viewModels);

            if (collectionView != null)
            {
                collectionView.MoveCurrentTo(viewModel);
            }
        }

        /// <summary>
        /// This method takes the object and removes the object from collection of view models.
        /// </summary>
        /// <param name="sender">The object being removed.</param>
        /// <param name="e">The default argument.</param>
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            this.ViewModels.Remove(sender as WorkspaceViewModel);
        }
    }
}