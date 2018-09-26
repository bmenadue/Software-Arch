﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using OrderEntryDataAccess;
using OrderEntryEngine;

namespace OrderEntrySystem
{
    /// <summary>
    /// Represents a multi location view model, which is a work space view model.
    /// </summary>
    public class MultiLocationViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// The repository.
        /// </summary>
        private Repository repo;

        /// <summary>
        /// Initializes a new instance of the MultiLocationViewModel class.
        /// </summary>
        /// <param name="repo">The repository associated.</param>
        public MultiLocationViewModel(Repository repo)
           : base("Multi Location")
        {
            this.repo = repo;

            List<LocationViewModel> locations =
                (from p in this.repo.GetLocations()
                 select new LocationViewModel(p, this.repo)).ToList();

            locations.ForEach(lvm => lvm.PropertyChanged += this.OnLocationViewModelPropertyChanged);

            this.AllLocations = new ObservableCollection<LocationViewModel>(locations);

            repo.LocationAdded += this.OnLocationAdded;
        }

        /// <summary>
        /// Gets or sets the All locations field.
        /// </summary>
        public ObservableCollection<LocationViewModel> AllLocations { get; set; }

        /// <summary>
        /// Gets the number of items selected.
        /// </summary>
        public int NumberOfItemsSelected
        {
            get
            {
                return this.AllLocations.Count(vm => vm.IsSelected);
            }
        }

        /// <summary>
        /// Creates commands.
        /// </summary>
        protected override void CreateCommands()
        {
        }

        /// <summary>
        /// When adding a new location.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event argument.</param>
        private void OnLocationAdded(object sender, LocationEventArgs e)
        {
            LocationViewModel viewModel = new LocationViewModel(e.Location, this.repo);

            viewModel.PropertyChanged += this.OnLocationViewModelPropertyChanged;

            this.AllLocations.Add(viewModel);
        }

        /// <summary>
        /// When the property of the Location view model changes. 
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event argument.</param>
        private void OnLocationViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                this.OnPropertyChanged("NumberOfItemsSelected");
            }
        }
    }
}