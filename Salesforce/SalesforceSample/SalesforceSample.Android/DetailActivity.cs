using Android.App;
using Android.OS;
using Android.Views;

using System.Json;
using Salesforce;

using Debug = System.Diagnostics.Debug;

namespace SalesforceSample.Droid
{
	[Activity (Label = "Account Details")]			
	public class DetailActivity : ListActivity
	{
		AccountObject data;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			var extra = Intent.GetStringExtra ("JsonItem");
			Debug.WriteLine ("extra;" + extra);
			data =  new SObject ((JsonObject) JsonValue.Parse (extra)).As<AccountObject> ();

			ListAdapter = new DetailAdapter (this, data);
		}

		async void Delete () 
		{
			await RootActivity.Client.DeleteAsync (data).ContinueWith (response => {
				Debug.WriteLine ("delete finished.");
				StartActivity (typeof(RootActivity));
			});
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.Delete, menu);
			return true;
		}
		
		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			if (item.ItemId == Resource.Id.delete)
				Delete ();
			return true;
		}
	}
}

