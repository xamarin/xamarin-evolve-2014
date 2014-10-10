using System;
using System.Windows.Input;

namespace Phoneword.Core
{
    /// <summary>
    /// A simple command to delegate forwarding class
    /// </summary>
	public sealed class DelegateCommand : ICommand
    {
		readonly Action<object> command;
		readonly Func<object, bool> canExecute;

        /// <summary>
        /// Event that is raised when the current state for our command has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged = delegate { }; 

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="command">Function mapped to ICommand.Execute</param>
        public DelegateCommand(Action<object> command) : this(command, null)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="command">Function mapped to ICommand.Execute</param>
        public DelegateCommand(Action command) : this(command, null)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="command">Function mapped to ICommand.Execute</param>
        /// <param name="test">Function mapped to ICommand.CanExecute</param>
        public DelegateCommand(Action command, Func<bool> test)
        {
            if (command == null)
                throw new ArgumentNullException("command", "Command cannot be null.");

			this.command = delegate { command(); };
            if (test != null)
                this.canExecute = delegate { return test(); };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="command">Function mapped to ICommand.Execute</param>
        /// <param name="test">Function mapped to ICommand.CanExecute</param>
        public DelegateCommand(Action<object> command, Func<object, bool> test)
        {
            if (command == null)
                throw new ArgumentNullException("command", "Command cannot be null.");
            
			this.command = command;
            this.canExecute = test;;
        }

        /// <summary>
        /// This method can be used to raise the CanExecuteChanged handler.
        /// This will force WinRT to re-query the status of this command directly.
        /// This is not necessary if you use the AutoCanExecuteRequery feature.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public bool CanExecute(object parameter)
        {
            return (this.canExecute == null) || this.canExecute(parameter);
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
			this.command(parameter);
        }
    }
}