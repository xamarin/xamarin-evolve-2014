using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Json;

namespace SalesforceSample.Droid
{
	public class DetailAdapter : BaseAdapter<Tuple<string,string>>
	{
		readonly Activity context;

		public DetailAdapter(Activity activity, AccountObject item)
		{
			context = activity;
			Data = item;
		}

		AccountObject Data { get; set; }

		public override long GetItemId(int position)
		{
			return position;
		}
		
		public override Tuple<string,string> this[int position]
		{
			get { return new Tuple<string,string> ("",""); }
		}
		
		public override int Count
		{
			get { return 5; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.DetailListViewCell, null);

			// clear field
			view.FindViewById<TextView>(Resource.Id.Text1).Text = "";
			view.FindViewById<TextView>(Resource.Id.Text2).Text = "";

			switch (position) {
				case 0:
				view.FindViewById<TextView>(Resource.Id.Text1).Text = "Name";
				view.FindViewById<TextView>(Resource.Id.Text2).Text =  Data.Name;
				break;
				case 1:
				view.FindViewById<TextView>(Resource.Id.Text1).Text = "Industry";
				view.FindViewById<TextView>(Resource.Id.Text2).Text =  Data.Industry;
				break;
				case 2:
				view.FindViewById<TextView>(Resource.Id.Text1).Text = "Phone";
				view.FindViewById<TextView>(Resource.Id.Text2).Text =  Data.Phone;
				break;
				case 3:
				view.FindViewById<TextView>(Resource.Id.Text1).Text = "Website";
				view.FindViewById<TextView>(Resource.Id.Text2).Text =  Data.Website;
				break;
				case 4:
				view.FindViewById<TextView>(Resource.Id.Text1).Text = "Account Number";
				view.FindViewById<TextView>(Resource.Id.Text2).Text =  Data.AccountNumber;
				break;
			}

			return view;
		}
	}
}