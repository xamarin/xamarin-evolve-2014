using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading.Tasks;
using System.Linq;

namespace Xamarin.WebServicesAsync.Soap.iOS.ViewControllers
{
	public class SoapTableViewControllerController : UITableViewController
	{

		private ViewControllers.SoapTableViewControllerSource tableViewSource;

		public SoapTableViewControllerController () : base (UITableViewStyle.Grouped)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Title = "SOAP";

			RefreshControl = new UIRefreshControl ();
			RefreshControl.ValueChanged += async (sender, e) => {
				//TODO: Step 6b - iOS - Make the call to load the data
				await LoadDataAsync();
				RefreshControl.EndRefreshing();
			};
			
			// Register the TableView's data source
			tableViewSource = new SoapTableViewControllerSource (Enumerable.Empty<Core.Model.DrugInfo>());
			TableView.Source = tableViewSource;
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			//TODO: Step 6a - iOS - Make the call to load the data
			LoadDataAsync();
		}


		private async Task LoadDataAsync(){
			//TODO: Step 5 - iOS - Call the services using async and update the UI with the results
			//Create a soap client
			var soapClient = new Core.Client.SoapClient ();
			//Query
			var foundDrugInfo = await soapClient.GetDataAsync();

			//Assign response to our adapter and notify of updates
			tableViewSource.DrugInformation.Clear();
			tableViewSource.DrugInformation.AddRange(foundDrugInfo);
			TableView.ReloadData ();
		}
	}
}

