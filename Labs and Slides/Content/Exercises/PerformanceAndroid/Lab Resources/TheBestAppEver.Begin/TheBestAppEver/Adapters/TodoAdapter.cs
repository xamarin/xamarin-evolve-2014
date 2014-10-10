using System.Collections.Generic;
using System.Linq;
using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Webkit;

namespace TheBestAppEver
{
	class TodoAdapter : BaseAdapter<TodoItem>
	{
		readonly List<TodoItem> data;
		readonly Context context;

		public TodoAdapter(Context context, IEnumerable<TodoItem> data)
		{
			this.context = context;
			this.data = data.ToList();
		}

		public override int Count {
			get {
				return data.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override TodoItem this[int index] {
			get { 
				return data[index];
			}
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = data[position];

			var view = LayoutInflater.FromContext(context).Inflate(Resource.Layout.TodoItemCell, parent, false);
			view.FindViewById<TextView>(Resource.Id.label).Text = item.Title;
			view.FindViewById<TextView>(Resource.Id.details).Text = item.Notes;

			var icon = view.FindViewById<ImageView>(Resource.Id.icon);
			if (item.Completed)
				icon.SetImageResource(Resource.Drawable.check);
			else
				icon.SetImageBitmap(null);

			return view;
		}
	}
}

