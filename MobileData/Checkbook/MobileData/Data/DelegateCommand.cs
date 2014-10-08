using System;
using System.Windows.Input;

namespace MobileData
{
	public class DelegateCommand : ICommand
    {
		readonly Action<object> work;
		readonly Func<object, bool> canWork;

		public bool CanExecute(object parameter)
		{
			return canWork == null || canWork(parameter);
		}

		public void Execute(object parameter)
		{
			work(parameter);
		}

		public event EventHandler CanExecuteChanged = delegate{};
		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged(this, EventArgs.Empty);
		}

		public DelegateCommand(Action<object> work, Func<object,bool> canWork = null)
        {
			this.work = work;
			this.canWork = canWork;
        }
    }
}

