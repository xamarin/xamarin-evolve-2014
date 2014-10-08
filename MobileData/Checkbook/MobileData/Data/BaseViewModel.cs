using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MobileData
{
	public class BaseViewModel : INotifyPropertyChanged
    {
		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged = delegate {};

		protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		protected bool SetValue<T>(ref T field, T newValue, [CallerMemberName] string propertyName = "")
		{
			if (!object.Equals(field, newValue)) {
				field = newValue;
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				return true;
			}
			return false;
		}

		#endregion
    }
}

