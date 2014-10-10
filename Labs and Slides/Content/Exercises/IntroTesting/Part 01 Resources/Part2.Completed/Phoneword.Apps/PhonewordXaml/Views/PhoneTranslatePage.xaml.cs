using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoneword.Core;
using Xamarin.Forms;

namespace Phoneword.UI.XamForms.Views
{
    public partial class PhoneTranslatePage : ContentPage
    {
        private PhoneTranslateViewModel _viewModel;

        public PhoneTranslatePage()
        {
            InitializeComponent();

            Title = "Phoneword";

			_viewModel = new PhoneTranslateViewModel(App.AppViewModel);

            _viewModel.CallFailed = async (phoneNumber) => 
            {
                await DisplayAlert("Could not call", "Could not call '" + phoneNumber + "'.", "Close", null);
            };

            _viewModel.ShowCallHistoryDisplay = () =>
            {
                var callHistory = new CallHistoryPage();
                this.Navigation.PushAsync(callHistory);
            };

            this.BindingContext = _viewModel;
        }
    }
}
