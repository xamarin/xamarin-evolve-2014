using System;
using System.Collections.Generic;
using System.Linq;
using Android.Widget;
using Android.App;
using Android.Views;
using Android.Content;

namespace TheBestAppEver
{
	public class EnumerableAdapter<T> : BaseAdapter<T>
	{
		readonly List<T> data;
		readonly Context context;
		readonly int textViewResourceId;

		public EnumerableAdapter(Context context, int textViewResourceId, IEnumerable<T> data)
		{
			this.textViewResourceId = textViewResourceId;
			this.context = context;
			this.data = data.ToList();
		}

		public Func<T, long> GetItemIdProc { get; set; }
		public Func<T, string> GetTextProc { get; set; }
		public Func<T, string> GetDetailTextProc { get; set; }

		public override int Count {
			get {
				return data.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return GetItemIdProc == null ? position : GetItemIdProc(this[position]);
		}

		public override T this[int index] {
			get { 
				return data[index];
			}
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			// TODO: Step 1 - use view recycling
			var view = convertView;
			if (view == null) {
				int layoutId = textViewResourceId;
				if (layoutId <= 0) {
					layoutId = (GetDetailTextProc != null) 
						? Android.Resource.Layout.SimpleListItem2
						: Android.Resource.Layout.SimpleListItem1;
				}
				view = LayoutInflater.FromContext(context).Inflate(layoutId, null);
			}

			var item = this[position];
			var text = view.FindViewById<TextView>(Android.Resource.Id.Text1);
			text.Text = GetTextProc == null ? item.ToString() : GetTextProc(item);

			if (GetDetailTextProc != null) {
				var detail = view.FindViewById<TextView>(Android.Resource.Id.Text2);
				detail.Text = GetDetailTextProc(item);
			}

			return view;
		}
	}
}

