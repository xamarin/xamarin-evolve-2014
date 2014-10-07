using System;
using Xamarin.Forms;
using Salesforce;
using System.Collections.Generic;
using System.Net;
using Xamarin.Auth;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

#if __IOS__
using MonoTouch.UIKit;
#else
using Android.Content;
using Android.App;
#endif

namespace SalesforceForms
{
	public partial class RootPage : TabbedPage
	{
		NavigationPage accountsTab, productsTab, searchTab, monkeysTab;
		AccountsList accountsList;
		ProductList productsList;
		MonkeyList monkeysList;

		Search search;
		public static RootPage Current { get; private set; }

		public RootPage ()
		{
			Current = this;

			accountsList = new AccountsList { Title = "Accounts", Icon = "glyphish_104_index_cards.png" };
			accountsTab = new NavigationPage { Title = "Accounts", Icon = "glyphish_104_index_cards.png" };
			accountsTab.PushAsync (accountsList);

			productsList = new ProductList { Title = "Products", Icon = "glyphish_24_gift.png" };
			productsTab = new NavigationPage { Title = "Products", Icon = "glyphish_24_gift.png" };
			productsTab.PushAsync (productsList);

			monkeysList = new MonkeyList { Title = "Monkeys", Icon = "monkey_grey.png" };
			monkeysTab = new NavigationPage { Title = "Monkeys", Icon = "monkey_grey.png" };
			monkeysTab.PushAsync (monkeysList);

			search = new Search { Title = "Account Search", Icon = "glyphish_06_magnify.png" };
			searchTab = new NavigationPage { Title = "Search", Icon = "glyphish_06_magnify.png" };
			searchTab.PushAsync (search);

			Children.Add (accountsTab);
			Children.Add (productsTab);
			Children.Add (monkeysTab);
			Children.Add (searchTab);
		}

		//
		// We need to pop open a WebView for authentication;
		// this is platform-specific !!
		//
		#if __IOS__
		UIViewController context;
		#else
		Context context;
		#endif
		public SalesforceClient Client { get; private set; }

		#if __IOS__
		public void InitializeSalesforce (UIViewController context) {
			this.context = context;
		#else
		public void InitializeSalesforce (Context context) {
			this.context = context;
		#endif
		
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
				LoadProducts ();
				LoadMonkeys ();
			}
		}

		void StartAuthorization ()
		{
			#if __IOS__
			var loginController = Client.GetLoginInterface () as UIViewController;
			context.PresentViewController (new UINavigationController(loginController), true, null);
			#else
			var intent = Client.GetLoginInterface () as Intent;
			(context as Activity).StartActivityForResult (intent, 42);
			#endif
		}

		void OnAuthenticationCompleted (AuthenticatorCompletedEventArgs e)
		{
			if (!e.IsAuthenticated) {
				// TODO: Handle failed login scenario by re-presenting login form with error
				Client.CurrentUser.RequiresReauthentication = true;
				throw new Exception ("Login failed and we don't handle that.");
			}

			#if __IOS__
			context.DismissViewController (true, () => {
				LoadAccounts ();
				LoadProducts ();
				LoadMonkeys ();
			});
			#else
			LoadAccounts ();
			LoadProducts ();
			LoadMonkeys ();
			#endif
		}
	}
}
