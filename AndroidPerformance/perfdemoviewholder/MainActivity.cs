using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;

namespace PerfDemoViewHolder
{
	[Activity (Label = "PerfDemoViewHolder", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : ListActivity
	{
		protected async override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			await OnRefresh();
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.main_menu, menu);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			if (item.ItemId == Resource.Id.refresh) {
				OnRefresh();
			}

			return base.OnOptionsItemSelected(item);
		}

		async Task OnRefresh() {

			var todos = (await TaskService.GetItems(this, 10000));

			using (var t = new Timer("MainActivity")) {
				this.ListAdapter = new TodoAdapter(this, todos);
			}
		}
	}
}