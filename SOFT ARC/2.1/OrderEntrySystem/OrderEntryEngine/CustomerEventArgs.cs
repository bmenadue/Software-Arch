namespace OrderEntryEngine
{
    /// <summary>
    /// Represents a customer event argument.
    /// </summary>
    public class CustomerEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the CustomerEventArgs class.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public CustomerEventArgs(Customer customer)
        {
            this.Customer = customer;
        }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        public Customer Customer { get; set; }
    }
}