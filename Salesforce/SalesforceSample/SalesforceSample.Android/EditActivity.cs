using Android.App;
using Android.OS;
using Android.Views;

using System.Json;
using Salesforce;

using Debug = System.Diagnostics.Debug;

namespace SalesforceSample.Droid
{
	
	[Activity (Label = "Add/Edit Account")]			
	public class EditActivity : ListActivity
	{
		JsonObject data;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			var extra = Intent.GetStringExtra ("JsonItem");
			Debug.WriteLine ("extra;" + extra);
			data = (JsonObject)JsonValue.Parse (extra);

			ListAdapter = new EditAdapter (this, data);
		}

		async void Save () 
		{
			var selectedObject = new SObject (data);

			await RootActivity.Client.CreateAsync (selectedObject).ContinueWith (response => {
				Debug.WriteLine ("save finished.");
				StartActivity (typeof(RootActivity));
			});
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.Save, menu);
			return true;
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			if (item.ItemId == Resource.Id.save)
				Save ();
			return true;
		}
	}
}
