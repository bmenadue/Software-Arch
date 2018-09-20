using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntrySystem
{
    /// <summary>
    /// Represents a generic ViewModel.
    /// </summary>
    public class ViewModel
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
        /// Gets the DisplayName field. 
        /// </summary>
        public string DisplayName { get; private set; }
    }
}
