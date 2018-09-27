using System;
using System.Windows.Input;

namespace OrderEntrySystem
{
    /// <summary>
    /// Represents a CommandViewModel, which is a ViewModel.
    /// </summary>
    public class CommandViewModel : ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the CommandViewModel class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="command">The command being performed.</param>
        public CommandViewModel(string displayName, ICommand command)
            : base(displayName)
        {
            if (command == null)
            {
                throw new Exception("Command was null.");
            }

            this.Command = command;
        }

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        public ICommand Command { get; set; }
    }
}