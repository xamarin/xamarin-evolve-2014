using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Json;

namespace SalesforceSample.Droid
{
	
	public class EditAdapter : BaseAdapter<Tuple<string,string>>
	{
		Activity context;
		JsonObject data;

		public EditAdapter(Activity activity, JsonObject item)
			: base()
		{
			context = activity;
			data = item;
		}

		public JsonObject Data
		{
			get { return data; }
			set
			{
				if (data == value)
					return;
				data = value;
			}
		}

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
			get { return 5; } // Hardcoding, since our JsonObject has some private values.
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			Data = data;

			View view = convertView;
			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.EditListViewCell, null);

			// clear field
			view.FindViewById<TextView>(Resource.Id.Text1).Text = "";
			view.FindViewById<EditText>(Resource.Id.Text2).Text = "";

			switch (position) {
			case 0:
				{
					view.FindViewById<TextView> (Resource.Id.Text1).Text = "Name";
					var v = view.FindViewById<EditText> (Resource.Id.Text2);
					v.Text = Data ["Name"];
					v.AfterTextChanged += (sender, e) => {
						Data ["Name"] = v.Text;
					};
				}
				break;
			case 1:
				{
					view.FindViewById<TextView> (Resource.Id.Text1).Text = "Industry";
					var v = view.FindViewById<EditText> (Resource.Id.Text2);
					v.Text = Data ["Industry"];
					v.AfterTextChanged += (sender, e) => {
					Data ["Industry"] = v.Text;
					};
				}
				break;
			case 2:
				{
					view.FindViewById<TextView> (Resource.Id.Text1).Text = "Phone";
					var v = view.FindViewById<EditText> (Resource.Id.Text2);
					v.Text = Data ["Phone"];
					v.AfterTextChanged += (sender, e) => {
						Data ["Phone"] = v.Text;
					};
				}
				break;
			case 3:
				{
					view.FindViewById<TextView> (Resource.Id.Text1).Text = "Website";
					var v = view.FindViewById<EditText> (Resource.Id.Text2);
					v.Text = Data ["Website"];
					v.AfterTextChanged += (sender, e) => {
						Data ["Website"] = v.Text;
					};
				}
				break;
			case 4:
				{
					view.FindViewById<TextView> (Resource.Id.Text1).Text = "Account Number";
					var v = view.FindViewById<EditText> (Resource.Id.Text2);
					v.Text = Data ["AccountNumber"];
					v.AfterTextChanged += (sender, e) => {
						Data ["AccountNumber"] = v.Text;
					};
				}
				break;
			}

			return view;
		}
	}
}