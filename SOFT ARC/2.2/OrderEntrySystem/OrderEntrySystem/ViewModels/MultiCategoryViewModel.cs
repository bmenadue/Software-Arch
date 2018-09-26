using OrderEntryDataAccess;
using OrderEntryEngine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OrderEntrySystem
{
    public class MultiCategoryViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// The repository.
        /// </summary>
        private Repository repo;

        /// <summary>
        /// Initializes a new instance of the MultiCustomerViewModel class.
        /// </summary>
        /// <param name="repo">The repository.</param>
        public MultiCategoryViewModel(Repository repo)
           : base("Multi Category")
        {
            this.repo = repo;

            List<CategoryViewModel> categorys =
                (from p in this.repo.GetCategories()
                 select new CategoryViewModel(p, this.repo)).ToList();

            categorys.ForEach(cvm => cvm.PropertyChanged += this.OnCategoryViewModelPropertyChanged);

            this.AllCategorys = new ObservableCollection<CategoryViewModel>(categorys);

            repo.CategoryAdded += this.OnCategoryAdded;
        }

        /// <summary>
        /// Gets the number of items selected.
        /// </summary>
        public int NumberOfItemsSelected
        {
            get
            {
                return this.AllCategorys.Count(vm => vm.IsSelected);
            }
        }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        public ObservableCollection<CategoryViewModel> AllCategorys { get; set; }

        /// <summary>
        /// This creates commands.
        /// </summary>
        protected override void CreateCommands()
        {
            this.Commands.Add(new CommandViewModel("New...", new DelegateCommand(p => this.CreateNewCategoryExecute())));
            this.Commands.Add(new CommandViewModel("Edit...", new DelegateCommand(p => this.EditCategoryExecute())));

        }

        private void CreateNewCategoryExecute()
        {
            CategoryViewModel viewModel = new CategoryViewModel(new Category(), this.repo);

            ShowCategory(viewModel);
        }

        private void EditCategoryExecute()
        {
            try
            {
                CategoryViewModel viewModel = this.AllCategorys.SingleOrDefault(vm => vm.IsSelected);

                ShowCategory(viewModel);

                this.repo.SaveToDatabase();
            }
            catch
            {
                MessageBox.Show("You can only select one customer.");
            }
        }

        private static void ShowCategory(CategoryViewModel viewModel)
        {
            WorkspaceWindow window = new WorkspaceWindow();
            window.Width = 400;
            window.Title = viewModel.DisplayName;

            viewModel.CloseAction = b => window.DialogResult = b;

            CategoryView view = new CategoryView();
            view.DataContext = viewModel;

            window.Content = view;
            window.ShowDialog();
        }

        /// <summary>
        /// When the customer gets added.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The argument.</param>
        private void OnCategoryAdded(object sender, CategoryEventArgs e)
        {
            CategoryViewModel viewModel = new CategoryViewModel(e.Category, this.repo);

            viewModel.PropertyChanged += this.OnCategoryViewModelPropertyChanged;

            this.AllCategorys.Add(viewModel);
        }

        /// <summary>
        /// When the property changes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The argument.</param>
        private void OnCategoryViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                this.OnPropertyChanged("NumberOfItemsSelected");
            }
        }
    }
}
