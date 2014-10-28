using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Evolve.Core;

namespace com.xamarin.university.mobilenav.android.flyout
{
	/// <summary>
	/// Demo 5: Add an index
	/// </summary>		
	public class EventsAdapter: BaseAdapter<Exhibit>
	{
		private List<Exhibit> data;
		private Activity context;

		public EventsAdapter (Activity activity, IEnumerable<Exhibit> events)
		{
			data = (from s in events
			        orderby s.Title
			        select s).ToList ();
			context = activity;
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override Exhibit this [int position] {
			get { return data [position]; }
		}

		public override int Count {
			get { return data.Count; }
		}

		/// <summary>
		/// CUSTOM ROW STYLE !!
		/// </summary>
		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var view = convertView;
			if (view == null) {
				view = context.LayoutInflater.Inflate (Android.Resource.Layout.SimpleListItem1, null);
			}
			
			var animal = data [position];
			

			var animalNameView = view.FindViewById<TextView> (Android.Resource.Id.Text1);
			animalNameView.Text = animal.Title;

			return view;
		}
	}
}

