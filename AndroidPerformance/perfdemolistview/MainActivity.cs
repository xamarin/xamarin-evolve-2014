using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PerfDemoListView
{
	[Activity (Label = "PerfDemoListView", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : ListActivity
	{
		protected async override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			await OnRefresh ();
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.main_menu, menu);
			return base.OnCreateOptionsMenu (menu);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			if (item.ItemId == Resource.Id.refresh) {
				OnRefresh ();
			}

			return base.OnOptionsItemSelected (item);
		}

		async Task OnRefresh ()
		{
			ListAdapter = null;
		
			List<TodoItem> todos = await TaskService.GetItemsAsync (this, 50000000);

			using (var t = new Timer ("MainActivity")) {

				//TODO : Demo 3 - Step 1
				this.ListAdapter = new ArrayAdapter<TodoItem> (this, Android.Resource.Layout.SimpleListItem1, todos.ToArray ());

				//TODO : Demo 3 - Step 2
				//this.ListAdapter = new CustomAdapter<TodoItem> (this, Android.Resource.Layout.SimpleListItem1, todos);

			}
		}
	}
}