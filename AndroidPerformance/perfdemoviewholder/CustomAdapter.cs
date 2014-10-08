using System;
using System.Collections.Generic;
using System.Linq;
using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Util;
using Android.Graphics;

namespace PerfDemoViewHolder
{
	public class TodoAdapter : BaseAdapter<TodoItem>
	{
		//TODO : Demo 4 - Step 1
		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var item = data [position];
			var view = convertView;

			if (view == null) {
				Log.Debug ("-----CustomAdapter-----", "Inflating view");
				view = LayoutInflater.FromContext (context).Inflate (Resource.Layout.TodoItemCell, parent, false);
			}

			Log.Debug ("-----CustomAdapter-----", "Finding views");

			view.FindViewById<TextView> (Resource.Id.title).Text = item.Title;
			view.FindViewById<TextView> (Resource.Id.notes).Text = item.Notes;

			var icon = view.FindViewById<ImageView> (Resource.Id.checkmark);
			if (item.Completed) {
				icon.SetImageResource (Resource.Drawable.check);
			} else {
				icon.SetImageBitmap (null);
			}

			return view;
		}

		//TODO : Demo 4 - Step 2
//		private class ViewHolder : Java.Lang.Object
//		{
//			public TextView Title;
//			public TextView Notes;
//			public ImageView Checkmark;
//		}

		//TODO : Demo 4 - Step 3
//		WeakReference checkImageCache;
//		public override View GetView (int position, View convertView, ViewGroup parent)
//		{
//			ViewHolder viewHolder;
//			var view = convertView;
//
//			if (view == null) {
//				Log.Debug ("-----CustomAdapter-----", "Inflating view");
//				view = LayoutInflater.FromContext (context).Inflate (Resource.Layout.TodoItemCell, parent, false);
//
//				Log.Debug ("-----CustomAdapter-----", "Finding views");
//				viewHolder = new ViewHolder ();
//
//				viewHolder.Title = view.FindViewById<TextView> (Resource.Id.title);
//				viewHolder.Notes = view.FindViewById<TextView> (Resource.Id.notes);
//				viewHolder.Checkmark = view.FindViewById<ImageView> (Resource.Id.checkmark);
//
//				Bitmap checkImage = null;
//				checkImage = (checkImageCache != null) ? (Bitmap)checkImageCache.Target : null;
//				if (checkImage == null) {
//					checkImage = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.check);
//					checkImageCache = new WeakReference(checkImage);
//				}
//				viewHolder.Checkmark.SetImageBitmap(checkImage);
//
//				view.Tag = viewHolder;
//			} else {
//				viewHolder = view.Tag as ViewHolder;
//			}
//
//			var item = data [position];
//
//			viewHolder.Title.Text = item.Title;
//			viewHolder.Notes.Text = item.Notes;
//			viewHolder.Checkmark.Visibility = (item.Completed) ? ViewStates.Visible : ViewStates.Invisible;
//
//			return view;
//		}


		#region Other Methods

		readonly List<TodoItem> data;
		readonly Context context;

		public TodoAdapter (Context context, IEnumerable<TodoItem> data)
		{
			this.context = context;
			this.data = data.ToList ();
		}

		public override int Count {
			get {
				return data.Count;
			}
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override TodoItem this [int index] {
			get { 
				return data [index];
			}
		}

		#endregion
	}
}