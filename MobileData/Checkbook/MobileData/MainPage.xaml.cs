using Xamarin.Forms;
using System;

namespace MobileData
{    
    public partial class MainPage : ContentPage
    {    
        public MainPage ()
        {
			BindingContext = new Checkbook();
            InitializeComponent ();
        }

		protected override void OnAppearing()
		{
			Checkbook checkbook = (Checkbook)BindingContext;
			checkbook.SelectedCheck = null;
		}

		async void OnCheckTapped (object sender, ItemTappedEventArgs e)
		{
			await Navigation.PushAsync(new CheckDetailsPage((Check)e.Item));
		}

		void OnShowFilePath(object sender, EventArgs e)
		{
			IDbConnection dbConnection = DependencyService.Get<IDbConnection>();

			DisplayAlert("DbFile is located at", dbConnection.Filename, "OK");
		}
    }
}

