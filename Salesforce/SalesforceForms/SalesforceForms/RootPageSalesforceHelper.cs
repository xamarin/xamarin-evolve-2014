using System;
using Xamarin.Forms;
using Salesforce;
using System.Collections.Generic;
using System.Net;
using Xamarin.Auth;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SalesforceForms
{
	public partial class RootPage
	{
		/// <summary>
		/// ACCOUNTS
		/// </summary>
		public async void LoadAccounts ()
		{
			SetLoadingState (true);
			IEnumerable<SObject> response;

			try {
				response = await Client.QueryAsync ("SELECT Id, Name, AccountNumber, Phone, Website, Industry, LastModifiedDate FROM Account"); // , SLAExpirationDate__c
			} catch (InvalidSessionException) {
				InitializeSalesforce (context);
				SetLoadingState (false);
				return;
			} catch (WebException) {
				ShowGeneralNetworkError();
				SetLoadingState (false);
				return;
			}

			// Marshal our data into account objects
			//DataSource.Objects = response.Select (s => s.As<AccountObject> ()).ToList();
			var objs = response.Select (s => s.As<AccountObject> ()).ToList();
			Debug.WriteLine ("Accounts: " + objs.Count);

			// Display the list
			accountsList.Items = objs;


			SetLoadingState (false);
		}

		/// <summary>
		/// PRODUCTS
		/// </summary>
		public async void LoadProducts ()
		{
			SetLoadingState (true);
			IEnumerable<SObject> response;

			try {
				response = await Client.QueryAsync (
					"SELECT Id, Name, ProductCode, Description, LastModifiedDate "
					+"FROM Product2");
			} catch (InvalidSessionException) {
				InitializeSalesforce (context);
				SetLoadingState (false);
				return;
			} catch (WebException) {
				ShowGeneralNetworkError();
				SetLoadingState (false);
				return;
			}

			// Marshal our data into account objects
			var objs = response.Select (s => s.As<ProductObject> ()).ToList();
			Debug.WriteLine ("Products: " + objs.Count);

			// Display the list
			productsList.Items = objs;

			SetLoadingState (false);
		}

		/// <summary>
		/// PRODUCTS
		/// </summary>
		public async void LoadMonkeys ()
		{
			SetLoadingState (true);
			IEnumerable<SObject> response;

			try {
				//				response = await Client.QueryAsync (
				//					"SELECT Id, Name, ProductCode, Description, LastModifiedDate "
				//					+"FROM Product2");

				response = await Client.QueryAsync (
					"SELECT Id, Name, xamevolve14__Expertise__c, xamevolve14__Species__c "
					+"FROM xamevolve14__Monkey__c");
			} catch (InvalidSessionException) {
				InitializeSalesforce (context);
				SetLoadingState (false);
				return;
			} catch (WebException) {
				ShowGeneralNetworkError();
				SetLoadingState (false);
				return;
			}

			// Marshal our data into account objects
			var objs = response.Select (s => s.As<MonkeyObject> ()).ToList();
			Debug.WriteLine ("Monkeys: " + objs.Count);

			// Display the list
			monkeysList.Items = objs;

			SetLoadingState (false);
		}

		/// <summary>
		/// SEARCH
		/// </summary>
		public async Task<List<AccountObject>> Search (string query)
		{
			SetLoadingState (true);
			IEnumerable<SearchResult> response;
			List<AccountObject> objs1 = new List<AccountObject> ();;

			try {
				var searchString = 
					" FIND {" + query + "} "+
					" IN NAME FIELDS "+
					" RETURNING Account "+
					" (Id, Name, AccountNumber, Phone, Website, Industry, LastModifiedDate)";

				response = await Client.SearchAsync (searchString); //

				// returns SearchResult NOT SObject

				var objs = response.ToList();
				Debug.WriteLine ("Searched Accounts: " + objs.Count);
				// now collect IDs for QUERY against accounts
				string ids = "";
				foreach (var o in objs) {
					ids += ",'" + o.Id + "'";
				}
				ids = ids.Trim(',');

				// HACK: pull the 'found' SObjects
				IEnumerable<SObject> response1;
				var soql = 
					"SELECT Id, Name, AccountNumber, Phone, Website, Industry, LastModifiedDate "+
					"FROM Account "+
					"WHERE Id IN (" + ids + ")";

				response1 = await Client.QueryAsync (soql);

				objs1 = response1.Select (s1 => s1.As<AccountObject> ()).ToList();
				Debug.WriteLine ("Accounts: " + objs1.Count);

				SetLoadingState (false);


			} catch (InvalidSessionException) {
				InitializeSalesforce (context);
				SetLoadingState (false);
				return null;
			} catch (WebException we) {
				Console.WriteLine (we);
				ShowGeneralNetworkError();
				SetLoadingState (false);
				return null;
			}



			return objs1;
		}


		async void ShowGeneralNetworkError ()
		{
			const string message = "Looks like you aren't connected to the Internet.";
			//var alertView = new UIAlertView ("Oops!", message, null, "Dismiss", null);
			await this.DisplayAlert ("Ooops", message, "Dismiss");
		}

		internal void SetLoadingState(bool loading)
		{
			this.IsBusy = loading;
		}
	}
}

