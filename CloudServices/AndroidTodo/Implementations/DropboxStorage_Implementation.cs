using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portable; 

using DropboxSync.Android;

namespace Shared
{
	/// <summary>
	/// Check out the Dropbox Datastore API 
	/// https://www.dropbox.com/developers/datastore
	/// </summary>
	public class DropboxStorageImplementation : ICloudStorage
	{
		public DBDatastore store;

		public event EventHandler ItemsUpdated;
		public List<TodoItem> Items { get; private set;}

		//Dictionary<string,DBRecord> records = new Dictionary<string, DBRecord> ();
		Dictionary<string,TodoItem> taskDictionary = new Dictionary<string, TodoItem> ();
		string tableName = "tasks";


		//NSTimer timer;

		static object locker = new object();
		bool AutoUpdating { get; set; }

		public DropboxStorageImplementation ()
		{
			Console.WriteLine ("DropboxStorageImplementation ctor");
		}


		public void Init (DBAccount account)
		{
			Console.WriteLine("Init");
			if (store != null)
				return;

			store = DBDatastore.OpenDefault (account);

			store.Sync ();

//			store.AddObserver (store, () => {
//				Console.Write("AddObserver");
//
//				DBError error2;
//				store.Sync(out error2); // needed?
//
//				var table = store.GetTable (tableName);
//				var results = table.Query (null, out error);
//
//				Console.WriteLine(results.Length);
//
//				ProccessResults (results);
//			});


			// TIMER TO AUTOUPDATE
			AutoUpdating = true;

			#if __IOS__
			store.BeginInvokeOnMainThread(()=>{
				timer = NSTimer.CreateRepeatingScheduledTimer(2,()=>{
					if(!AutoUpdating)
						return;
					//Console.WriteLine("AutoUpdating"); // SPAM
					DBError error3;
					store.Sync(out error3);
				});
			});
			#endif

		}

		//TODO: tidy up this method!!!
		void ProccessResults (DBRecord[] results)
		{
			taskDictionary.Clear ();

			//records = results.ToDictionary (x => x.Id.ToString (), x => x);
			lock (locker) {
				Console.WriteLine("ProcessResults" + results.Length.ToString());

				//foreach (var result in results) {
				for (var i = 0; i < results.Length; i++) { var result = results [i];
					var id = result.Id.ToString ();
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
				Items = taskDictionary.Select (x => x.Value).OrderBy (x => x.Name).ToList();
				Console.WriteLine("Updated " + Items.Count);
//				store.BeginInvokeOnMainThread (() => {
					if (ItemsUpdated != null) {
						Console.WriteLine("TasksUpdated handler called " + Items.Count);
						ItemsUpdated (this, EventArgs.Empty);
					}
//				});

				Console.WriteLine ("DONE");
			}
		}

		public async Task SaveTodoItemAsync (TodoItem t)
		{
			await Task.Run(() => {
			var table = store.GetTable (tableName);
			var r = table.Get (t.ID);
			if (r == null)
				table.Insert (t.ToDictionary ());
			else 
				r.Update (t); 

			store.Sync ();
			return;
			});
		}
		public async Task<List<TodoItem>> RefreshDataAsync()
		{
			await Task.Run(() => {
			if (store == null)
				return new List<TodoItem>();

			store.Sync ();

			var table = store.GetTable (tableName);

			var results = table.Query (null);

			Console.WriteLine("RefreshDataAsync:" + results.Count() );

			ProccessResults (results.ToArray<DBRecord> ());

			return Items;
			});
			return null;
		}
		public async Task<TodoItem> GetTodoItemAsync(string id)
		{
			await Task.Run (() => {
				return (from i in Items
				       where i.ID == id
				       select i).FirstOrDefault ();
			});
			return null;
		}
		public async Task DeleteTodoItemAsync (TodoItem t)
		{
			await Task.Run (() => {
				var table = store.GetTable (tableName);
				var r = table.Get (t.ID);
				r.DeleteRecord ();

				store.Sync ();
			});
		}
	}


	public static class TodoExtensions
	{
		public static DBFields ToDictionary (this TodoItem t)
		{
			var fields = new DBFields();
			fields.Set("Title", t.Name);
			fields.Set("Description", t.Notes);
			fields.Set("IsDone", t.Done);
			return fields;
		}

		public static TodoItem ToTask (this DBRecord record)
		{
			return new TodoItem ().Update (record);
		}

		public static TodoItem Update (this TodoItem t, DBRecord record)
		{
			t.ID = record.Id;

			t.Name = record.GetString ("Title");
			t.Notes = record.GetString("Description");
			t.Done = record.GetBoolean ("IsDone");
			return t;
		}

		public static DBRecord Update (this DBRecord record, TodoItem t)
		{
			record.Set ("Title", t.Name);
			record.Set ("Description", t.Notes);
			record.Set ("IsDone", t.Done);
			return record;
		}
	}
}

