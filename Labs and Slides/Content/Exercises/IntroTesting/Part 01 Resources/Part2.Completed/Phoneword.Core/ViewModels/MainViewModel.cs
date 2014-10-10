using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoneword.Core
{
    public class MainViewModel : ViewModel
    {
		public IDialer Dialer {
			get;
			set;
		}

		public MainViewModel(IDialer dialer)
		{
			Dialer = dialer;
		}

        ObservableCollection<string> _dialledNumbers = new ObservableCollection<string>();

        public ObservableCollection<string> DialledNumbers
        {
            get { return _dialledNumbers; }
            set
            {
                if (_dialledNumbers != value)
                {
                    _dialledNumbers = value;
                    RaisePropertyChanged("DialledNumbers");
                }
            }
        }

        public void LogPhoneNumber(string phoneNumber)
        {
            DialledNumbers.Add(phoneNumber);
        }
    }
}
