using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading.Tasks;
using System.Linq;

namespace Xamarin.WebServicesAsync.Rest.iOS.ViewControllers
{
	public class RestTableViewController : UITableViewController
	{

		private ViewControllers.RestTableViewControllerSource tableViewSource;

		public RestTableViewController () : base (UITableViewStyle.Grouped)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Title = "REST";

			// Register the TableView's data source
			tableViewSource = new RestTableViewControllerSource (Enumerable.Empty<Core.Model.DrugInfo>());
			this.TableView.Source = tableViewSource;

			RefreshControl = new UIRefreshControl ();
			RefreshControl.ValueChanged += async (sender, e) => {
                //TODO: Step 7b - iOS - Make the call to load the data
                await LoadDataAsync();
				RefreshControl.EndRefreshing();
			};
		}

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            //TODO: Step 7a - iOS - Make the call to load the data
            LoadDataAsync();
        }
       
		private async Task LoadDataAsync(){
			//TODO: Step 6 - iOS - Call the services using async and update the UI with the results
			var soapClient = new Core.Client.RestClient ();
		    var serverData = await soapClient.GetDataAsync();
		    tableViewSource.ReloadData(TableView, serverData);
		}
	}
}

