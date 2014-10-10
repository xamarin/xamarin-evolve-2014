using System.Linq;
using System.Threading.Tasks;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Xamarin.WebServicesAsync.Rest.Droid.Activities
 {
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class RestActivity : ListActivity {

		Adapters.DrugInfoAdapter adapter;

		protected override void OnCreate(Bundle bundle)
		{
		    base.OnCreate(bundle);

			SetContentView (Resource.Layout.list_with_spinner);

			adapter = new Adapters.DrugInfoAdapter(this, Enumerable.Empty<Core.Model.DrugInfo>());
			ListView.Adapter = adapter;
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			//TODO: Step 7a - Android - Make the call to load the data
//			LoadDataAsync();
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
                    //TODO: Step 7b - Android - Make the call to load the data
//				    LoadDataAsync ();
					break;
			}

			return base.OnMenuItemSelected (featureId, item);
		}
			
        private async Task LoadDataAsync(){
			//TODO: Step 6 - Android - Call the services using async and update the UI with the results
//	        var restClient = new Core.Client.RestClient ();
//	        var serverData = await restClient.GetDataAsync();
//
//	        adapter.ReloadData(serverData);
        }
	}
}
