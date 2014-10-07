using System;
using Android.App;
using Android.Content;
using Android.Views;
using Android.OS;

using Salesforce;
using Xamarin.Auth;
using System.Linq;

namespace SalesforceSample.Droid
{
	[Activity (Label = "Accounts", MainLauncher = true), IntentFilter(new String[]{"com.sample.salesforce"})]
	public class RootActivity : ListActivity
	{
		public static SalesforceClient Client { get; private set; }

		ISalesforceUser Account { get; set; }

		const string consumerKey = "YOUR_CONSUMER_KEY";
		const string consumerSecret = "YOUR_CONSUMER_SECRET";
		Uri callbackUrl = new Uri (@"com.sample.salesforce:/oauth2Callback");

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Client = new SalesforceClient (consumerKey, consumerSecret, callbackUrl);
			Client.AuthenticationComplete += (sender, e) => OnAuthenticationCompleted (e);

			var users = Client.LoadUsers ();

			if (!users.Any()) {
				var intent = Client.GetLoginInterface () as Intent;
				StartActivityForResult (intent, 42);
			} else {
				LoadAccounts ();
			}

			ListView.ItemClick += (sender,e) => {
				var t = ((DataAdapter)ListAdapter)[e.Position];

				System.Diagnostics.Debug.WriteLine("Clicked on " + t.ToString());

				var intent = new Intent();
				intent.SetClass(this, typeof(DetailActivity));
				intent.PutExtra("JsonItem", "{\"attributes\": {\"type\": \"Account\", \"url\": \"/services/data/v28.0/sobjects/Account/\"}, " + 
					string.Format ("\"Id\": \"{0}\", \"Name\": \"{1}\", \"AccountNumber\": \"{2}\", \"Phone\": \"{3}\", \"Website\": \"{4}\", \"Industry\": \"{5}\"", t.Id, t.Name, t.AccountNumber, t.Phone, t.Website, t.Industry) + "}");

				StartActivity(intent);
			};
		}

		void OnAuthenticationCompleted (AuthenticatorCompletedEventArgs e)
		{
			if (!e.IsAuthenticated) {
				// TODO: Handle failed login scenario by re-presenting login form with error
				throw new Exception ("Login failed and we don't handle that.");
			}

			LoadAccounts ();

			Account = e.Account;
			Client.Save (Account);
		}

		async void LoadAccounts ()
		{
			var results = await Client.QueryAsync ("SELECT Id, Name, AccountNumber, Phone, Website, Industry FROM Account");
			var resultRecords = results.Select (s => s.As<AccountObject> ()).ToList ();

			System.Diagnostics.Debug.WriteLine ("records: {0}", resultRecords.Count);
			ListAdapter = new DataAdapter (this, resultRecords);
		}

		/// <summary>shortcut back to the main screen</summary>
		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.Add, menu);
			return true;
		}

		/// <summary>shortcut back to the main screen</summary>
		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			if (item.ItemId == Resource.Id.add) {
				// Populate blank fields with blank JSON
				const string extra = @"{""attributes"": {""type"": ""Account"", ""url"": ""/services/data/v28.0/sobjects/Account/""}, ""Id"": """", ""Name"": """", ""AccountNumber"": """", ""Phone"": """", ""Website"": """", ""Industry"": """"}";

				var intent = new Intent();
				intent.SetClass(this, typeof(EditActivity));
				intent.PutExtra("JsonItem", extra);

				StartActivity(intent);
			}
			return true;
		}
	}
}
