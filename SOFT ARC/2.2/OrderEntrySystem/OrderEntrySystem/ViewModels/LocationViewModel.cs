using System.Windows.Input;
using OrderEntryDataAccess;
using OrderEntryEngine;

namespace OrderEntrySystem
{
    /// <summary>
    /// Represents a location view model, which is a work space view model.
    /// </summary>
    public class LocationViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// The save command.
        /// </summary>
        private ICommand saveCommand;

        /// <summary>
        /// The is selected field.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// The location field.
        /// </summary>
        private Location location;

        /// <summary>
        /// The repository field. 
        /// </summary>
        private Repository repo;

        /// <summary>
        /// Initializes a new instance of the LocationViewModel class.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="repo">The repository.</param>
        public LocationViewModel(Location location, Repository repo)
            : base("Location")
        {
            this.location = location;
            this.repo = repo;
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
        /// Gets or sets a value indicating whether its selected.
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
        /// Gets or sets the Name property.
        /// </summary>
        public string Name
        {
            get
            {
                return this.location.Name;
            }

            set
            {
                this.location.Name = value;
                this.OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the Description property.
        /// </summary>
        public string Description
        {
            get
            {
                return this.location.Description;
            }

            set
            {
                this.location.Description = value;
                this.OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets or sets the City.
        /// </summary>
        public string City
        {
            get
            {
                return this.location.City;
            }

            set
            {
                this.location.City = value;
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
                return this.location.State;
            }

            set
            {
                this.location.State = value;
                this.OnPropertyChanged("State");
            }
        }

        /// <summary>
        /// This method creates commands.
        /// </summary>
        protected override void CreateCommands()
        {
        }

        /// <summary>
        /// This saves the location.
        /// </summary>
        private void Save()
        {
            this.repo.AddLocation(this.location);

            this.repo.SaveToDatabase();
        }
    }
}