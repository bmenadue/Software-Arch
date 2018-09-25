using System.ComponentModel;

namespace OrderEntrySystem
{
    /// <summary>
    /// Represents a generic ViewModel.
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the ViewModel class.
        /// </summary>
        /// <param name="displayName">The display name of the view model.</param>
        public ViewModel(string displayName)
        {
            this.DisplayName = displayName;
        }

        /// <summary>
        /// Event for property changing.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the DisplayName field.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// When the property changes.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}