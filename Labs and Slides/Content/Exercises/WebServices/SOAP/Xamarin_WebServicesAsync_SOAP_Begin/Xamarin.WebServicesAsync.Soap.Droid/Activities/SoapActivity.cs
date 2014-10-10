using System.Linq;
using System.Threading.Tasks;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Xamarin.WebServicesAsync.Soap.Droid.Activities
 {
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class SoapActivity : ListActivity
    {
		
		Adapters.DrugInfoAdapter adapter;

		protected override void OnCreate(Bundle bundle)
		{
		    base.OnCreate(bundle);

			//Set our activity's layout
			SetContentView (Resource.Layout.list_with_spinner);

			//Assign an adapter
			adapter = new Adapters.DrugInfoAdapter(this, Enumerable.Empty<Core.Model.DrugInfo>());
			ListView.Adapter = adapter;
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			//TODO: Step 6a -Android - Make the call to load the data
//			LoadDataAsync ();
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.primary_menu, menu);
			return base.OnCreateOptionsMenu (menu);
		}

		public override bool OnMenuItemSelected (int featureId, IMenuItem item)
		{
			switch (item.ItemId) {
				case Resource.Id.action_refresh:
					//TODO: Step 6b - Android - Make the call to load the data
//					LoadDataAsync ();
					break;
			}

			return base.OnMenuItemSelected (featureId, item);
		}
		

        private async Task LoadDataAsync(){      
			//TODO: Step 5 - Android - Call the services using async and update the UI with the results
//			//Create a soap client
//			var soapClient = new Core.Client.SoapClient ();
//
//			//Query
//			var foundDrugInfo = await soapClient.GetDataAsync ();
//
//			//Assign response to our adapter and notify of updates
//			adapter.DrugInformation.Clear();
//			adapter.DrugInformation.AddRange(foundDrugInfo);
//			adapter.NotifyDataSetChanged ();
        }
    }
}
