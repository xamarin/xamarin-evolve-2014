using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portable; 
using DropBoxSync.iOS;
using MonoTouch.Foundation;

namespace Shared
{
	/// <summary>
	/// Check out the Dropbox Datastore API 
	/// https://www.dropbox.com/developers/datastore
	/// </summary>
	public class DropboxStorageImplementation : ICloudStorage
	{
		DBDatastore store;

		public event EventHandler ItemsUpdated;
		public List<TodoItem> Items { get; private set;}

		Dictionary<string,DBRecord> records = new Dictionary<string, DBRecord> ();
		Dictionary<string,TodoItem> taskDictionary = new Dictionary<string, TodoItem> ();
		const string tableName = "tasks";


		NSTimer timer;

		static object locker = new object();
		bool AutoUpdating { get; set; }

		public DropboxStorageImplementation ()
		{
			string DropboxSyncKey = "YOUR_SYNC_KEY";
			string DropboxSyncSecret = "YOUR_SECRET";
			var manager = new DBAccountManager (DropboxSyncKey, DropboxSyncSecret);
			DBAccountManager.SharedManager = manager;
		}



		public async Task SaveTodoItemAsync (TodoItem t)
		{
			DBError error;

			var table = store.GetTable (tableName);
			var r = table.GetRecord (t.ID, out error);
			if (r == null)
				table.Insert (t.ToDictionary ());
			else 
				r.Update (t); 

			await store.SyncAsync ();
		}


		public async Task DeleteTodoItemAsync (TodoItem t)
		{
			DBError error;

			var table = store.GetTable (tableName);
			var r = table.GetRecord (t.ID, out error);
			r.DeleteRecord();

			await store.SyncAsync ();
		}


		public async Task<TodoItem> GetTodoItemAsync(string id)
		{
			return (from i in Items
				where i.ID == id
				select i).FirstOrDefault ();
		}



		public void Init ()
		{
			Console.Write("Init");
			if (store != null)
				return;
			DBError error;
			store = DBDatastore.OpenDefaultStore (DBAccountManager.SharedManager.LinkedAccount, out error);
			DBError error1;
			var sync = store.Sync (out error1);

			store.AddObserver (store, () => {
				Console.Write("AddObserver");

				DBError error2;
				store.Sync(out error2); // needed?

				var table = store.GetTable (tableName);
				var results = table.Query (null, out error);

				Console.WriteLine(results.Length);

				ProccessResults (results);
			});


			// TIMER TO AUTOUPDATE
			AutoUpdating = true;

			store.BeginInvokeOnMainThread(()=>{
				timer = NSTimer.CreateRepeatingScheduledTimer(2,()=>{
					if(!AutoUpdating)
						return;
					//Console.WriteLine("AutoUpdating"); // SPAM
					DBError error3;
					store.Sync(out error3);
				});
			});

		}

		//TODO: tidy up this method!!!
		void ProccessResults (DBRecord[] results)
		{
			taskDictionary.Clear ();

			records = results.ToDictionary (x => x.RecordId.ToString (), x => x);
			lock (locker) {
				Console.WriteLine("ProcessResults" + results.Length.ToString());

				//foreach (var result in results) {
				for (var i = 0; i < results.Length; i++) { var result = results [i];
					var id = result.RecordId.ToString ();
					Console.WriteLine ("id " + id + " " + i);
					TodoItem t;
					taskDictionary.TryGetValue (id, out t);
					if (t == null) {
						t = result.ToTask ();
						taskDictionary.Add (id, t);
					} else {
						t.Update (result);
					}
				}

				store.BeginInvokeOnMainThread (() => {

					Items = taskDictionary.Select (x => x.Value).OrderBy (x => x.Name).ToList();
					Console.WriteLine("Updated Items property: " + Items.Count);


					if (ItemsUpdated != null) {
						Console.WriteLine("TasksUpdated handler called " + Items.Count);
						ItemsUpdated (this, EventArgs.Empty);
					}
				});

				Console.WriteLine ("DONE");
			}
		}


		public async Task<List<TodoItem>> RefreshDataAsync()
		{
			if (store == null)
				return new List<TodoItem>();

			await store.SyncAsync ();

			var table = store.GetTable (tableName);
			DBError error;
			var results = table.Query (null, out error);

			Console.WriteLine("RefreshDataAsync:" + results.Length);

			ProccessResults (results);

			return Items;
		}
	}


	public static class TodoExtensions
	{
		public static NSDictionary ToDictionary (this TodoItem t)
		{
			var keys = new NSString[] {
				new NSString("Title"),
				new NSString("Description"),
				new NSString("IsDone")
			};
			var values = new NSObject[] {
				new NSString(t.Name),
				new NSString(t.Notes),
				new NSString(t.Done.ToString())
			};
			return NSDictionary.FromObjectsAndKeys (values, keys);
		}

		public static TodoItem ToTask (this DBRecord record)
		{
			return new TodoItem ().Update (record);
		}

		public static TodoItem Update (this TodoItem t, DBRecord record)
		{
			t.ID = record.RecordId;

			t.Name = record.Fields [new NSString ("Title")].ToString ();
			t.Notes = record.Fields [new NSString ("Description")].ToString ();
			t.Done = Convert.ToBoolean (record.Fields [new NSString ("IsDone")].ToString ());
			return t;
		}

		public static DBRecord Update (this DBRecord record, TodoItem t)
		{
			record.SetObject (new NSString(t.Name), "Title");
			record.SetObject (new NSString(t.Notes), "Description");
			record.SetObject (new NSString(t.Done.ToString()), "IsDone");
			return record;
		}
	}
}

