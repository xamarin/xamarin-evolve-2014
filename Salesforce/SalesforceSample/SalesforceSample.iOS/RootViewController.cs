using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Salesforce;
using Xamarin.Auth;
using System.Linq;
using System.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;

namespace SalesforceSample.iOS
{
	public sealed partial class RootViewController : UITableViewController
	{
		public DataSource DataSource { get; private set; }
		public SalesforceClient Client { get; private set; }
		public DetailViewController DetailViewController { get; set; }

		AddViewController AddAccountController { get; set; }

		public RootViewController () : base ("RootViewController", null)
		{
			Title = NSBundle.MainBundle.LocalizedString ("Accounts", "Accounts");
		}

		void AddNewItem ()
		{
			AddAccountController = new AddViewController ();
			AddAccountController.ItemUpdated += OnItemAdded;
			AddAccountController.Canceled += (sender, args) => AddAccountController.DismissViewController (true, () => {
				AddAccountController.Dispose();
				AddAccountController = null;
			});
			PresentViewController (AddAccountController, true, null);
		}

		async void OnItemAdded (object sender, AccountObject account)
		{
			// Create salesforce creation request from generated account object
			string newId = await Client.CreateAsync (account);
			account.Id = newId;
			FinishAddAccount (account);
		}

		void FinishAddAccount (AccountObject account)
		{
			// Reset the form for the next use.
			AddAccountController.DismissViewController(true, ()=> {
				// Insert our newly created object into the table
				DataSource.Objects.Add(account);
				TableView.ReloadData();

				AddAccountController.Dispose();
				AddAccountController = null;
			});
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			NavigationItem.RightBarButtonItem = EditButtonItem;
			NavigationItem.LeftBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.Add, (o, e) => AddNewItem ());

			TableView.Source = DataSource = new DataSource (this);

			InitializeSalesforce ();

			DetailViewController = new DetailViewController();
			DetailViewController.ItemUpdated += OnItemUpdated;
			DetailViewController.Canceled += (sender, args) => NavigationController.PopViewControllerAnimated (true);
		}

		async void OnItemUpdated (object sender, AccountObject args)
		{
			await Client.UpdateAsync (args);
			LoadAccounts ();
			NavigationController.PopViewControllerAnimated (true);
		}

		void InitializeSalesforce ()
		{
			const string consumerKey = "YOUR_CONSUMER_KEY";
			const string consumerSecret = "YOUR_CONSUMER_SECRET";
			var callbackUrl = new Uri (@"com.sample.salesforce:/oauth2Callback");

			// Creates our connection to salesforce.
			Client = new SalesforceClient (consumerKey, consumerSecret, callbackUrl);
			Client.AuthenticationComplete += (sender, e) => OnAuthenticationCompleted (e);

			// Get authenticated users from the local keystore
			var users = Client.LoadUsers ();
			if (!users.Any ()) {
				// Begin OAuth journey
				StartAuthorization (); 
			} else {
				// Immediately go to accounts screen
				LoadAccounts (); 
			}
		}

		void StartAuthorization ()
		{
			var loginController = Client.GetLoginInterface () as UIViewController;
            PresentViewController (new UINavigationController(loginController), true, null);
		}

		void OnAuthenticationCompleted (AuthenticatorCompletedEventArgs e)
		{
			if (!e.IsAuthenticated) {
				// TODO: Handle failed login scenario by re-presenting login form with error
                Client.CurrentUser.RequiresReauthentication = true;
				throw new Exception ("Login failed and we don't handle that.");
			}

			DismissViewController (true, () => {
				NavigationItem.RightBarButtonItem = null;
				LoadAccounts ();
			});
		}

		async void LoadAccounts ()
		{
			SetLoadingState (true);
			IEnumerable<SObject> response;

			try {
				response = await Client.QueryAsync ("SELECT Id, Name, AccountNumber, Phone, Website, Industry, LastModifiedDate FROM Account"); // , SLAExpirationDate__c
			} catch (InvalidSessionException) {
				InitializeSalesforce ();
				SetLoadingState (false);
				return;
			} catch (WebException) {
				ShowGeneralNetworkError();
				SetLoadingState (false);
				return;
			}

			// Marshal our data into account objects
			DataSource.Objects = response.Select (s => s.As<AccountObject> ()).ToList();
			SetLoadingState (false);
		}

		static void ShowGeneralNetworkError ()
		{
			const string message = "Looks like you aren't connected to the Internet.";
			var alertView = new UIAlertView ("Oops!", message, null, "Dismiss", null);
			alertView.Show ();
		}

		internal static void SetLoadingState(bool loading)
		{
			UIApplication.SharedApplication.NetworkActivityIndicatorVisible = loading;
		}
	}
}
