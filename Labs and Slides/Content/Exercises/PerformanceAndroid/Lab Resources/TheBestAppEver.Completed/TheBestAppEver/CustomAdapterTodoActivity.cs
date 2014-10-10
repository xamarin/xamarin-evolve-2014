using Android.App;
using Android.OS;
using Android.Views;
using System.Threading.Tasks;

namespace TheBestAppEver
{
	[Activity(Label = "CustomAdapterTodoActivity", Icon = "@drawable/icon")]			
	public class CustomAdapterTodoActivity : ListActivity
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

			var todos = (await TaskService.GetItems(this, 50000));

			using (var t = new Timer("CustomAdapterTodoActivity")) {
				ListAdapter = new TodoAdapter(this, todos);
			}

		}
	}
}


