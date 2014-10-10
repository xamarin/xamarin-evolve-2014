using System.Collections.Generic;
using System.Linq;
using Android.Widget;
using Android.Views;
using Android.Content;
using System;
using Android.Graphics;

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

		// TODO: Step 2b - use a view holder to cache off the references to the 
		// underlying view elements in each inflated layout.
		class ViewHolder : Java.Lang.Object {
			public TextView TextView;
			public TextView DetailView;
			public ImageView ImageView;
		}

		// TODO: Step 2c - Set icon once to our shared value
		WeakReference checkImageCache;

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			ViewHolder holder;

			// TODO: Step 2a - view recycling is a must.
			View view = convertView;
			if (view == null) {
				view = LayoutInflater.FromContext(context).Inflate(Resource.Layout.TodoItemCell, parent, false);

				// TODO: Step 2b - cache off the view holder into the tag.
				holder = new ViewHolder() {
					TextView = view.FindViewById<TextView>(Resource.Id.label),
					DetailView = view.FindViewById<TextView>(Resource.Id.details),
					ImageView = view.FindViewById<ImageView>(Resource.Id.icon)
				};
				view.Tag = holder;

				// TODO: Step 2c - Set the icon once to our shared value.
				Bitmap checkImage = null;
				checkImage = (checkImageCache != null) ? (Bitmap)checkImageCache.Target : null;
				if (checkImage == null) {
					// TODO: Step 2c - Use proper size bitmap.
					checkImage = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.small_check);
					checkImageCache = new WeakReference(checkImage);
				}
				holder.ImageView.SetImageBitmap(checkImage);

			} else {
				holder = (ViewHolder) view.Tag;
			}

			var item = data[position];
			holder.TextView.Text = item.Title;
			holder.DetailView.Text = item.Notes;
			// TODO: Step 2c - Hide and show checkmark vs. setting image
			holder.ImageView.Visibility = (item.Completed) ? ViewStates.Visible : ViewStates.Invisible;

			return view;
		}
	}
}

