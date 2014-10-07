using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Json;

namespace SalesforceSample.Droid
{
	public class DataAdapter : BaseAdapter<AccountObject>
	{
		readonly Activity context;
		readonly List<AccountObject> objects = new List<AccountObject> ();

		public DataAdapter(Activity activity, List<AccountObject> items)
		{
			context = activity;
			objects = items;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override AccountObject this[int position]
		{
			get { return objects[position]; }
		}

		public override int Count
		{
			get { return objects.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var o = objects[position];
		
			var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.RootListViewCell, null);
			view.FindViewById<TextView>(Resource.Id.Text1).Text = o.Name;
			view.FindViewById<TextView>(Resource.Id.Text2).Text = o.AccountNumber;

			return view;
		}
	}
}

