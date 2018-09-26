namespace OrderEntryEngine
{
    /// <summary>
    /// Represents a location event argument.
    /// </summary>
    public class LocationEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the LocationEventArgs class.
        /// </summary>
        /// <param name="location">The location.</param>
        public LocationEventArgs(Location location)
        {
            this.Location = location;
        }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public Location Location { get; set; }
    }
}