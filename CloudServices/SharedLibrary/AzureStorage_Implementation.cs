using System;
using Portable;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System.Linq;
using Portable;

namespace Shared
{
	public class AzureStorageImplementation : DelegatingHandler, ICloudStorage
	{
		static AzureStorageImplementation todoServiceInstance = new AzureStorageImplementation();
		public static AzureStorageImplementation DefaultService { get { return todoServiceInstance; } }
		public List<TodoItem> Items { get; private set;}
		public MobileServiceClient Client;
		IMobileServiceTable<TodoItem> todoTable;

		public MobileServiceUser User;

		// Constructor
		protected AzureStorageImplementation()
		{
			CurrentPlatform.Init ();

			Items = new List<TodoItem>();

			Client = new MobileServiceClient (
				"https://YOUR_APP.azure-mobile.net/"
				, "YOUR_SECRET", this);	
			//Client = new MobileServiceClient ("https://???????.azure-mobile.net/", "555", this);	

			todoTable = Client.GetTable<TodoItem>(); // Create an MSTable instance to allow us to work with the TodoItem table
		}

		async public Task<List<TodoItem>> RefreshDataAsync()
		{
			try 
			{
				// This code refreshes the entries in the list view by querying the TodoItems table.
				Items = await todoTable.ToListAsync();
				//	.Where (todoItem => todoItem.Done == false).ToListAsync();
			} 
			catch (MobileServiceInvalidOperationException msioe) 
			{
				Console.Error.WriteLine (@"ERROR {0}", msioe.Message);
				return null;
			}

			return Items;
		}

		public async Task SaveTodoItemAsync(TodoItem todoItem)
		{
			if (String.IsNullOrEmpty(todoItem.ID))
				await todoTable.InsertAsync(todoItem);
			else
				await todoTable.UpdateAsync(todoItem);
		}

		public async Task<TodoItem> GetTodoItemAsync(string id)
		{
			try 
			{
				return await todoTable.LookupAsync(id);
				// demo using a query instead
//				return await todoTable.Where (u => u.ID == id).ToListAsync().FirstOrDefault();
				// different demo using a query
//				var list = await todoTable.Where (u => u.ID == id).ToListAsync();
//				var exists = list.Any<TodoItem>();
//				if (exists)
//					return list.FirstOrDefault(); 
			} 
			catch (MobileServiceInvalidOperationException msioe)
			{
				Console.Error.WriteLine(@"INVALID {0}", msioe.Message);
			}
			catch (Exception e) 
			{
				Console.Error.WriteLine(@"ERROR {0}", e.Message);
			}
			return null;
		}

		public async Task DeleteTodoItemAsync(TodoItem item)
		{
			try 
			{
				await todoTable.DeleteAsync(item);
			} 
			catch (MobileServiceInvalidOperationException msioe)
			{
				Console.Error.WriteLine(@"INVALID {0}", msioe.Message);
			}
			catch (Exception e) 
			{
				Console.Error.WriteLine(@"ERROR {0}", e.Message);
			}
		}


		private int busyCount = 0;

		// Public events
		public event Action<bool> BusyUpdate;
		void Busy(bool busy)
		{
			// assumes always executes on UI thread
			if (busy) 
			{
				if (busyCount++ == 0 && BusyUpdate != null)
					BusyUpdate(true);
			} 
			else 
			{
				if (--busyCount == 0 && BusyUpdate != null)
					BusyUpdate(false);
			}
		}

		// TODO:: Uncomment this code when using Mobile Services and inheriting from IServiceFilter
		#region implemented abstract members of HttpMessageHandler

		protected override async Task<System.Net.Http.HttpResponseMessage> SendAsync (System.Net.Http.HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
		{
			Busy (true);
			var response = await base.SendAsync (request, cancellationToken);

			Busy (false);
			return response;
		}

		#endregion
	}
}

