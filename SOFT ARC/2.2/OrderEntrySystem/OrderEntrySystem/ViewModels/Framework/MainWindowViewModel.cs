using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using OrderEntryDataAccess;
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
        /// This is the repository.
        /// </summary>
        private Repository repo;

        /// <summary>
        /// Initializes a new instance of the MainWindowViewModel class.
        /// </summary>
        public MainWindowViewModel()
            : base("Order Entry System - Menadue")
        {
            this.repo = new Repository();
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

        #region create
        /// <summary>
        /// This method creates a new view model.
        /// </summary>
        public void CreateNewProduct()
        {
            Product product = new Product { LocationID =1, Description = "This is a product", Name = "This is the name", Price = 0 };
            ProductViewModel pvm = new ProductViewModel(product, this.repo);
            pvm.RequestClose += this.OnWorkspaceRequestClose;
            this.ViewModels.Add(pvm);
            this.ActivateViewModel(pvm);
        }

        /// <summary>
        /// This method creates a new view model.
        /// </summary>
        public void CreateNewCategoy()
        {
            Category category = new Category { Name ="Dumb" };
            CategoryViewModel cvm = new CategoryViewModel(category, this.repo);
            cvm.RequestClose += this.OnWorkspaceRequestClose;
            this.ViewModels.Add(cvm);
            this.ActivateViewModel(cvm);
        }


        /// <summary>
        /// This method creates a new view model of customer.
        /// </summary>
        public void CreateNewCustomer()
        {
            Customer customer = new Customer { FirstName = "Anna", LastName = "Goldbach", Address = "2000 College Ave", City = "Stevens Point", Email = "anna@email.com", Phone = "911", State = "WI" };
            CustomerViewModel cvm = new CustomerViewModel(customer, this.repo);
            cvm.RequestClose += this.OnWorkspaceRequestClose;
            this.viewModels.Add(cvm);
            this.ActivateViewModel(cvm);
        }

        /// <summary>
        /// Creates a new location.
        /// </summary>
        public void CreateNewLocation()
        {
            Location location = new Location { Name = "Warehouse", City = "Stevens Point", Description = "Pretty boring", Id = 1, State = "WI" };
            LocationViewModel lvm = new LocationViewModel(location, this.repo);
            lvm.RequestClose += this.OnWorkspaceRequestClose;
            this.viewModels.Add(lvm);
            this.ActivateViewModel(lvm);
        }
        #endregion

        #region show
        /// <summary>
        /// Shows all products.
        /// </summary>
        public void ShowAllProducts()
        {
            MultiProductViewModel viewModel = this.ViewModels.FirstOrDefault(vm => vm is MultiProductViewModel) as MultiProductViewModel;

            if (viewModel == null)
            {
                MultiProductViewModel mpvm = new MultiProductViewModel(this.repo);
                mpvm.RequestClose += this.OnWorkspaceRequestClose;
                this.ViewModels.Add(mpvm);
            }

            this.ActivateViewModel(viewModel);
        }

        /// <summary>
        /// Shows all products.
        /// </summary>
        public void ShowAllCategorys()
        {
            MultiCategoryViewModel viewModel = this.ViewModels.FirstOrDefault(vm => vm is MultiCategoryViewModel) as MultiCategoryViewModel;

            if (viewModel == null)
            {
                MultiCategoryViewModel mcvm = new MultiCategoryViewModel(this.repo);
                mcvm.RequestClose += this.OnWorkspaceRequestClose;
                this.ViewModels.Add(mcvm);
            }

            this.ActivateViewModel(viewModel);
        }


        /// <summary>
        /// Shows all customers.
        /// </summary>
        public void ShowAllCustomers()
        {
            MultiCustomerViewModel viewModel = this.ViewModels.FirstOrDefault(vm => vm is MultiCustomerViewModel) as MultiCustomerViewModel;

            if (viewModel == null)
            {
                MultiCustomerViewModel mcvm = new MultiCustomerViewModel(this.repo);
                mcvm.RequestClose += this.OnWorkspaceRequestClose;
                this.ViewModels.Add(mcvm);
            }

            this.ActivateViewModel(viewModel);
        }

        /// <summary>
        /// Shows all locations.
        /// </summary>
        public void ShowAllLocations()
        {
            MultiLocationViewModel viewModel = this.ViewModels.FirstOrDefault(vm => vm is MultiLocationViewModel) as MultiLocationViewModel;

            if (viewModel == null)
            {
                MultiLocationViewModel mlvm = new MultiLocationViewModel(this.repo);
                mlvm.RequestClose += this.OnWorkspaceRequestClose;
                this.ViewModels.Add(mlvm);
            }

            this.ActivateViewModel(viewModel);
        }
        #endregion

        /// <summary>
        /// This method creates individual view models.
        /// </summary>
        protected override void CreateCommands()
        {
           
            this.Commands.Add(new CommandViewModel("View all products", new DelegateCommand(p => this.ShowAllProducts())));
            this.Commands.Add(new CommandViewModel("View all customers", new DelegateCommand(p => this.ShowAllCustomers())));
            this.Commands.Add(new CommandViewModel("View all locaitons", new DelegateCommand(p => this.ShowAllLocations())));
            this.Commands.Add(new CommandViewModel("View all categorys", new DelegateCommand(p => this.ShowAllCategorys())));

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