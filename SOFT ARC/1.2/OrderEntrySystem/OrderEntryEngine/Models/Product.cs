namespace OrderEntryEngine.Models
{
    /// <summary>
    /// Represents a Product class.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the Location field.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the Name field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description field.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Price field.
        /// </summary>
        public decimal Price { get; set; }
    }
}