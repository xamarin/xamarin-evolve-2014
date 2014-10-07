using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Graphics;
using Android.Views;
using Portable;
using AndroidTodo;
using System;
using DropboxSync.Android;
using Android.Util;

namespace AndroidTodo {
	[Activity (Label = "EvolveCloud", MainLauncher = true, Icon="@drawable/ic_launcher", Theme = "@style/AppTheme")]			
	public class HomeScreen : Activity {
		protected TodoItemListAdapter todoList;
		protected IList<TodoItem> todoItems;
		protected Button addTaskButton = null;
		protected ListView todoListView = null;

		public DBAccountManager Account { get; private set; }
		public DBDatastore DropboxDatastore { get; set; }


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			View titleView = Window.FindViewById(Android.Resource.Id.Title);
			if (titleView != null) {
			  IViewParent parent = titleView.Parent;
			  if (parent != null && (parent is View)) {
			    View parentView = (View)parent;
			    parentView.SetBackgroundColor(Color.Rgb(0x26, 0x75 ,0xFF)); //38, 117 ,255
			  }
			}

			// set our layout to be the home screen
			SetContentView(Resource.Layout.HomeScreen);

			//Find our controls
			todoListView = FindViewById<ListView> (Resource.Id.lstTasks);
			addTaskButton = FindViewById<Button> (Resource.Id.btnAddTask);

			// wire up add task button handler
			if(addTaskButton != null) {
				addTaskButton.Click += (sender, e) => {
					StartActivity(typeof(TaskDetailsScreen));
				};
			}
			
			// wire up task click handler
			if(todoListView != null) {
				todoListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
					var taskDetails = new Intent (this, typeof (TaskDetailsScreen));
					taskDetails.PutExtra ("TaskID", todoItems[e.Position].ID);
					StartActivity (taskDetails);
				};
			}

			// HACK: uncomment for Dropbox
			// ALSO ALL THE METHODS BELOW
			BootstrapDropbox ();
		}

		#region Dropbox
		void BootstrapDropbox ()
		{
			string DropboxSyncKey = "YOUR_SYNC_KEY";
			string DropboxSyncSecret = "YOUR_SECRET";
			// Setup Dropbox.
			Account = DBAccountManager.GetInstance (ApplicationContext, DropboxSyncKey, DropboxSyncSecret);
			Account.LinkedAccountChanged += (sender, e) => {
				if (e.P1.IsLinked) {
					Console.WriteLine("Account.LinkedAccountChanged" + "Now linked to {0}", e.P1 != null ? e.P1.AccountInfo != null ? e.P1.AccountInfo.DisplayName : "nobody" : "null");
				}else {
					Console.WriteLine("Account.LinkedAccountChanged" + "Now unlinked from {0}", e.P1 != null ? e.P1.AccountInfo != null ? e.P1.AccountInfo.DisplayName : "nobody" : "null");
					Account.StartLink(this, (int)RequestCode.LinkToDropboxRequest);
					return;
				}
				Account = e.P0;
				StartApp (e.P1);
			};
			// TODO: Restart auth flow.
			if (!Account.HasLinkedAccount) {
				Account.StartLink (this, (int)RequestCode.LinkToDropboxRequest);
			} else {
				StartApp ();
			}
		}
		void StartApp (DBAccount account = null)
		{
			AppDelegate.Current.DropboxStore.Init (account);
			DropboxDatastore = AppDelegate.Current.DropboxStore.store;
			Console.WriteLine("StartApp" + "...");
			DropboxDatastore.Sync();

		}
		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			var code = (RequestCode)requestCode;

			if (code == RequestCode.LinkToDropboxRequest && resultCode != Result.Canceled) {
				StartApp();
			} else {
				Account.Unlink();
				BootstrapDropbox ();
			}
		}
		#endregion





		protected async override void OnResume ()
		{
			base.OnResume ();

			// NO AUTH
			//HACK: tasks = AppDelegate.Current.TaskMgr.GetTasks();
			todoItems = await AppDelegate.Current.TaskMgr.GetTasksAsync ();
			todoList = new TodoItemListAdapter(this, todoItems);
			todoListView.Adapter = todoList;

			// AZURE AUTH
//			if (AzureStorageImplementation.DefaultService.User == null)
//				await AzureStorageImplementation.DefaultService.Authenticate (this);
//
//			if (AzureStorageImplementation.DefaultService.User != null) {
//				Console.WriteLine ("Logged in user: " + AzureStorageImplementation.DefaultService.User.UserId);
//				todoItems = await AppDelegate.Current.TaskMgr.GetTasksAsync (); //AzureStorageImplementation.DefaultService.RefreshDataAsync ();
//				todoList = new TodoItemListAdapter(this, todoItems);
//				todoListView.Adapter = todoList;
//			} else {
//				Console.WriteLine ("Didn't log in");
//			}
		}
	}
	enum RequestCode
	{
		LinkToDropboxRequest
	}
}