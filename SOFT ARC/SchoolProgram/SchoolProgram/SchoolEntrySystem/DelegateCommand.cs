using System;
using System.Windows.Input;

namespace OrderEntrySystem
{
    /// <summary>
    /// Represents a delegate command, which is a ICommand.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// Readonly action of object.
        /// </summary>
        private readonly Action<object> command;

        /// <summary>
        /// Initializes a new instance of the DelegateCommand class.
        /// </summary>
        /// <param name="command">The object that is an action.</param>
        public DelegateCommand(Action<object> command)
        {
            this.command = command ?? throw new Exception("Command was null.");
        }

        /// <summary>
        /// Adds or removes the value to the CanExecuteChange field.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Method where something can be executed or not.
        /// </summary>
        /// <param name="parameter">The parameter being tried.</param>
        /// <returns>Returns and object.</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Method executing the object.
        /// </summary>
        /// <param name="parameter">The object being executed.</param>
        public void Execute(object parameter)
        {
            this.command(parameter);
        }
    }
}