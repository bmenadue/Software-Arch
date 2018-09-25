using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using OrderEntryDataAccess;
using OrderEntryEngine;

namespace OrderEntrySystem
{
    /// <summary>
    /// Represents a multi customer view model.
    /// </summary>
    public class MultiCustomerViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// The repository.
        /// </summary>
        private Repository repo;

        /// <summary>
        /// Initializes a new instance of the MultiCustomerViewModel class.
        /// </summary>
        /// <param name="repo">The repository.</param>
        public MultiCustomerViewModel(Repository repo)
           : base("Multi Customer")
        {
            this.repo = repo;

            List<CustomerViewModel> customers =
                (from p in this.repo.GetCustomers()
                 select new CustomerViewModel(p, this.repo)).ToList();

            customers.ForEach(pvm => pvm.PropertyChanged += this.OnCustomerViewModelPropertyChanged);

            this.AllCustomers = new ObservableCollection<CustomerViewModel>(customers);

            repo.CustomerAdded += this.OnCustomerAdded;
        }

        /// <summary>
        /// Gets the number of items selected.
        /// </summary>
        public int NumberOfItemsSelected
        {
            get
            {
                return this.AllCustomers.Count(vm => vm.IsSelected);
            }
        }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        public ObservableCollection<CustomerViewModel> AllCustomers { get; set; }

        /// <summary>
        /// This creates commands.
        /// </summary>
        protected override void CreateCommands()
        {
        }

        /// <summary>
        /// When the customer gets added.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The argument.</param>
        private void OnCustomerAdded(object sender, CustomerEventArgs e)
        {
            CustomerViewModel viewModel = new CustomerViewModel(e.Customer, this.repo);

            viewModel.PropertyChanged += this.OnCustomerViewModelPropertyChanged;

            this.AllCustomers.Add(viewModel);
        }

        /// <summary>
        /// When the property changes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The argument.</param>
        private void OnCustomerViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                this.OnPropertyChanged("NumberOfItemsSelected");
            }
        }
    }
}