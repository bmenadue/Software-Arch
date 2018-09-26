using System.ComponentModel.DataAnnotations;

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
        public virtual Location Location { get; set; }

        public int LocationID { get; set; }

        /// <summary>
        /// Gets or sets the Name field.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description field.
        /// </summary>
        [MaxLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Price field.
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Condition.
        /// </summary>
        public Condition Condition { get; set; }
    }
}