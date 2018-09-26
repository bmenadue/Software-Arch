using System;
using System.Collections.Generic;
using System.Windows.Input;
using OrderEntryDataAccess;
using OrderEntryEngine;
using OrderEntryEngine.Models;

namespace OrderEntrySystem
{
    /// <summary>
    /// Represents a ProductViewModel, which is a view model.
    /// </summary>
    public class ProductViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// Is the ProductViewModel Product.
        /// </summary>
        private Product product;

        /// <summary>
        /// Private repo for the product view model.
        /// </summary>
        private Repository repo;

        /// <summary>
        /// Private save command.
        /// </summary>
        private ICommand saveCommand;

        /// <summary>
        /// Either is selected or isn't.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// Initializes a new instance of the ProductViewModel class.
        /// </summary>
        /// <param name="product">The product being assigned.</param>
        /// <param name="repo">The repository.</param>
        public ProductViewModel(Product product, Repository repo)
        : base("Product")
        {
            this.repo = repo;
            this.product = product;
        }

        public Condition Condition
        {
            get
            {
                return product.Condition;
            }
            set
            {
                product.Condition = value;
                this.OnPropertyChanged("Condition");
            }
        }

        public IEnumerable<Condition> Conditions { get { return Enum.GetValues(typeof(Condition)) as IEnumerable<Condition>; } }


        /// <summary>
        /// Gets or sets a value indicating whether the IsSelected is true or false.
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
        /// Gets or sets the Location property.
        /// </summary>
        public Location Location
        {
            get
            {
                return this.product.Location;
            }

            set
            {
                this.product.Location = value;
                this.OnPropertyChanged("Location");
            }
        }

        public Category Category
        {
            get
            {
                return this.product.Category;
            }
            set
            {
                this.product.Category = value;
                this.OnPropertyChanged("Category");
            }
        }

        public IEnumerable<Location> Locations { get { return this.repo.GetLocations(); } }

        public IEnumerable<Category> Categories { get { return this.repo.GetCategories(); } }


        /// <summary>
        /// Gets or sets the Name property.
        /// </summary>
        public string Name
        {
            get
            {
                return this.product.Name;
            }

            set
            {
                this.product.Name = value;
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
                return this.product.Description;
            }

            set
            {
                this.product.Description = value;
                this.OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets or sets the Price property.
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.product.Price;
            }

            set
            {
                this.product.Price = value;
                this.OnPropertyChanged("Price");
            }
        }

        /// <summary>
        /// Saves products to the repo.
        /// </summary>
        public void Save()
        {
            this.repo.AddProducts(this.product);

            this.repo.SaveToDatabase();
        }

        /// <summary>
        /// This method creates commands.
        /// </summary>
        protected override void CreateCommands()
        {
            this.Commands.Add(new CommandViewModel("OK", new DelegateCommand(p => this.OkExecute())));
            this.Commands.Add(new CommandViewModel("Cancel", new DelegateCommand(p => this.CancelExecute())));
        }

        private void OkExecute()
        {
            this.Save();
            this.CloseAction(true);
        }
  
        private void CancelExecute()
        {
            this.CloseAction(false);
        }
    }
}