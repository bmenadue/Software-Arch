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
        /// Initializes a new instance of the CustomerViewModel class.
        /// </summary>
        /// <param name="customer">The customer being displayed. </param>
        public CustomerViewModel(Customer customer)
            : base("Customer")
        {
            this.customer = customer;
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
            }
        }

        /// <summary>
        /// This is a protected overridden method. 
        /// </summary>
        protected override void CreateCommands()
        {
        }
    }
}