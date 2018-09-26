using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace OrderEntrySystem
{
    /// <summary>
    /// Represents a work space view model, which is a view model.
    /// </summary>
    public abstract class WorkspaceViewModel : ViewModel
    {
        /// <summary>
        /// This is an event handler that request to close.
        /// </summary>
        public EventHandler RequestClose;

        /// <summary>
        /// Delegate command field.
        /// </summary>
        private DelegateCommand closeCommand;

        /// <summary>
        /// Creates a new Observable Collection of CommandViewModels called commands.
        /// </summary>
        private ObservableCollection<CommandViewModel> commands = new ObservableCollection<CommandViewModel>();

        /// <summary>
        /// Initializes a new instance of the WorkspaceViewModel class.
        /// </summary>
        /// <param name="displayName">The display name of the view model.</param>
        public WorkspaceViewModel(string displayName)
            : base(displayName)
        {
            this.CreateCommands();
        }

        /// <summary>
        /// Gets the closeCommand field and assigns a delegate.
        /// </summary>
        public ICommand CloseCommand
        {
            get
            {
                if (this.closeCommand == null)
                {
                    this.closeCommand = new DelegateCommand(p => this.OnRequestClose());
                }

                return this.closeCommand;
            }
        }

        public Action<bool> CloseAction { get; set; }

        /// <summary>
        /// Gets the commands.
        /// </summary>
        public ObservableCollection<CommandViewModel> Commands
        {
            get
            {
                return this.commands;
            }
        }

        /// <summary>
        /// This method creates commands.
        /// </summary>
        protected abstract void CreateCommands();

        /// <summary>
        /// This method will process the request to close.
        /// </summary>
        private void OnRequestClose()
        {
            if (this.RequestClose != null)
            {
                this.RequestClose(this, EventArgs.Empty);
            }
        }
    }
}