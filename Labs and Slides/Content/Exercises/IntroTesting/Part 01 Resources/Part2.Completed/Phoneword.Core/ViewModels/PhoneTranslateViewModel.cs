using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Phoneword.Core
{
    public class PhoneTranslateViewModel : ViewModel
    {
        DelegateCommand _translateCommand;

        public ICommand TranslateCommand
        {
            get { return _translateCommand; }
        }

        DelegateCommand _callCommand;

        public ICommand CallCommand
        {
            get { return _callCommand; }
        }

        private DelegateCommand _callHistoryCommand;

        public ICommand CallHistoryCommand
        {
            get { return _callHistoryCommand; }
        }

		MainViewModel _appViewModel;

		public PhoneTranslateViewModel(MainViewModel appViewModel)
        {
			_appViewModel = appViewModel;

            _translateCommand = new DelegateCommand(DoTranslate, () => !String.IsNullOrEmpty(PhoneNumberText));
            _callCommand = new DelegateCommand(DoCall, () => !String.IsNullOrEmpty(TranslatedNumber));
            _callHistoryCommand = new DelegateCommand(DoCallHistory); //, () => App.AppViewModel.DialledNumbers.Count > 0);
        }

        private string _phoneNumberText = "";

        public string PhoneNumberText
        {
            get { return _phoneNumberText; }
            set
            {
                if (_phoneNumberText != value)
                {
                    _phoneNumberText = value;
                    RaisePropertyChanged("PhoneNumberText");
                    _translateCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _translatedNumber = String.Empty;

        public string TranslatedNumber
        {
            get { return _translatedNumber; }
            set
            {
                if (_translatedNumber != value)
                {
                    _translatedNumber = value;
                    RaisePropertyChanged("TranslatedNumber");
                    RaisePropertyChanged("CallButtonDisplay");
                }
            }
        }

        public string CallButtonDisplay
        {
            get
            {
                if (String.IsNullOrEmpty(_translatedNumber))
                    return "Call";
                else
                {
                    return "Call " + _translatedNumber;
                }
            }
        }
        private void DoTranslate()
        {
            // Perform the translate option
            TranslatedNumber = PhonewordTranslator.ToNumber(_phoneNumberText);
            _callCommand.RaiseCanExecuteChanged();
        }

        public Action<string> CallFailed = delegate { };
 
        private void DoCall()
        {
            bool couldCall = false;

            try
            {
				_appViewModel.LogPhoneNumber (_translatedNumber);

				_appViewModel.Dialer.Dial(_translatedNumber);
            }
            catch (Exception)
            {
                couldCall = false;
            }

            if (!couldCall)
                CallFailed(_translatedNumber);
        }

        public Action ShowCallHistoryDisplay = delegate { };

        private void DoCallHistory()
        {
            ShowCallHistoryDisplay();
        }
    }
}
