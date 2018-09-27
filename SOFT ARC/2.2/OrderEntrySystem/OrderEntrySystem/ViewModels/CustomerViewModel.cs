using System.Windows.Input;
using OrderEntryDataAccess;
using OrderEntryEngine;

namespace OrderEntrySystem
{
    /// <summary>
    /// Represents a customer view model, which is a workspace view model.
    /// </summary>
    public class CustomerViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// This is a customer of type Customer.
        /// </summary>
        private Customer customer;

        /// <summary>
        /// The repository being used.
        /// </summary>
        private Repository repo;

        /// <summary>
        /// The save command.
        /// </summary>
        private ICommand saveCommand;

        /// <summary>
        /// The is selected field. 
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// Initializes a new instance of the CustomerViewModel class.
        /// </summary>
        /// <param name="customer">The customer being displayed. </param>
        /// <param name="repo">The repository.</param>
        public CustomerViewModel(Customer customer, Repository repo)
            : base("Customer")
        {
            this.repo = repo;
            this.customer = customer;
        }

        /// <summary>
        /// Gets the save command.
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                if (this.saveCommand == null)
                {
                    this.saveCommand = new DelegateCommand(p => this.Save());
                }

                return this.saveCommand;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether its selected or not.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }

            set
            {
                this.isSelected = value;
                this.OnPropertyChanged("IsSelected");
            }
        }

        /// <summary>
        /// Gets or sets the FirstName.
        /// </summary>
        public string FirstName
        {
            get
            {
                return this.customer.FirstName;
            }

            set
            {
                this.customer.FirstName = value;
                this.OnPropertyChanged("First Name");
            }
        }

        /// <summary>
        /// Gets or sets the LastName.
        /// </summary>
        public string LastName
        {
            get
            {
                return this.customer.LastName;
            }

            set
            {
                this.customer.LastName = value;
                this.OnPropertyChanged("Last Name");
            }
        }

        /// <summary>
        /// Gets or sets the Phone.
        /// </summary>
        public string Phone
        {
            get
            {
                return this.customer.Phone;
            }

            set
            {
                this.customer.Phone = value;
                this.OnPropertyChanged("Phone");
            }
        }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        public string Email
        {
            get
            {
                return this.customer.Email;
            }

            set
            {
                this.customer.Email = value;
                this.OnPropertyChanged("Email");
            }
        }

        /// <summary>
        /// Gets or sets the Address.
        /// </summary>
        public string Address
        {
            get
            {
                return this.customer.Address;
            }

            set
            {
                this.customer.Address = value;
                this.OnPropertyChanged("Address");
            }
        }

        /// <summary>
        /// Gets or sets the City.
        /// </summary>
        public string City
        {
            get
            {
                return this.customer.City;
            }

            set
            {
                this.customer.City = value;
                this.OnPropertyChanged("City");
            }
        }

        /// <summary>
        /// Gets or sets the State.
        /// </summary>
        public string State
        {
            get
            {
                return this.customer.State;
            }

            set
            {
                this.customer.State = value;
                this.OnPropertyChanged("State");
            }
        }

        /// <summary>
        /// Saves the customers.
        /// </summary>
        public void Save()
        {
            this.repo.AddCustomer(this.customer);
            this.repo.SaveToDatabase();
        }

        /// <summary>
        /// This is a protected overridden method.
        /// </summary>
        protected override void CreateCommands()
        {
            this.Commands.Add(new CommandViewModel("OK", new DelegateCommand(p => this.OkExecute())));
            this.Commands.Add(new CommandViewModel("Cancel", new DelegateCommand(p => this.CancelExecute())));
        }

        /// <summary>
        /// This is the OK execute.
        /// </summary>
        private void OkExecute()
        {
            this.Save();
            this.CloseAction(true);
        }

        /// <summary>
        /// This is the cancel execute.
        /// </summary>
        private void CancelExecute()
        {
            this.CloseAction(false);
        }
    }
}