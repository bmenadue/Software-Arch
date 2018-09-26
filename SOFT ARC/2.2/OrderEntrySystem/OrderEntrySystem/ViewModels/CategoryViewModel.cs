using OrderEntryDataAccess;
using OrderEntryEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrderEntrySystem
{
    public class CategoryViewModel : WorkspaceViewModel
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
        private Category category;

        /// <summary>
        /// The repository field. 
        /// </summary>
        private Repository repo;

        /// <summary>
        /// Initializes a new instance of the LocationViewModel class.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="repo">The repository.</param>
        public CategoryViewModel(Category category, Repository repo)
            : base("Category")
        {
            this.category = category;
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
                return this.category.Name;
            }

            set
            {
                this.category.Name = value;
                this.OnPropertyChanged("Name");
            }
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

        /// <summary>
        /// This saves the location.
        /// </summary>
        private void Save()
        {
            this.repo.AddCategory(this.category);

            this.repo.SaveToDatabase();
        }

    }
}
