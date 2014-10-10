using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System.Threading.Tasks;

namespace TheBestAppEver
{
	[Activity(Label = "SimpleTodoActivity", Icon = "@drawable/icon")]			
	public class SimpleTodoActivity : ListActivity
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

			ListAdapter = null;

			// Change the "2000" value to a higher number to see ArrayAdapter fail.
			// 2000 will have issues on the Android SDK emulator.
			var todos = (await TaskService.GetItems(this, 2000));

			using (var t = new Timer("SimpleTodoActivity"))
			{
				ListAdapter = new ArrayAdapter<TodoItem>(this, Android.Resource.Layout.SimpleListItem1, todos.ToArray());
			}
		}
	}
}


