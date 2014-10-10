using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace TheBestAppEver
{
	[Activity(Label = "Best App Ever", MainLauncher = true, Icon = "@drawable/icon")]			
	public class MainActivity : ListActivity
	{
		readonly Dictionary<string, Type> choices = new Dictionary<string, Type>()
		{
			{ "Simple ListView", typeof(SimpleTodoActivity) },
			{ "Custom ListView", typeof(CustomAdapterTodoActivity) },
		};

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, 
														choices.Keys.ToArray());
		}

		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{
			StartActivity(choices.Values.ToArray()[position]);
		}
	}
}

