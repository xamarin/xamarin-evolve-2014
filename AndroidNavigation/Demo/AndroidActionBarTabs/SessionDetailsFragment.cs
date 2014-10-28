using System;
using Android.OS;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics.Drawables;
using Evolve.Core;

namespace com.xamarin.university.mobilenav.android.actionbartabs
{
	internal class EventDetailsFragment : Fragment
	{
		public static EventDetailsFragment NewInstance (int playId)
		{
			var detailsFrag = new EventDetailsFragment { Arguments = new Bundle () };
			detailsFrag.Arguments.PutInt ("current_event_id", playId);
			return detailsFrag;
		}

		TextView eventTitleTextView;
		TextView locationTextView;
		TextView animalNameTextView;

		public int ShownEventIndex {
			get { return Arguments.GetInt ("current_event_id", 0); }
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			if (container == null) {
				// Currently in a layout without a container, so no reason to create our view.
				return null;
			}

			var view = inflater.Inflate(Resource.Layout.event_screen, container, false);

			var evnt = EvolveData.EventData [ShownEventIndex];

			eventTitleTextView = view.FindViewById<TextView> (Resource.Id.eventTitleTextView);
			eventTitleTextView.Text = evnt.Title;

			locationTextView = view.FindViewById<TextView> (Resource.Id.locationTextView);
			locationTextView.Text = evnt.Location;

			animalNameTextView = view.FindViewById<TextView> (Resource.Id.animalNameTextView);
			animalNameTextView.Text = evnt.Abstract;

			return view;
		}

		private Drawable GetHeadShot (string url)
		{
			Drawable headshotDrawable = null;
			try {
				headshotDrawable = Drawable.CreateFromStream (Resources.Assets.Open (url), null);
			} catch (Exception ex) {
				Log.Debug (GetType ().FullName, "Error getting headshot for " + url + ", " + ex.ToString ());
				headshotDrawable = null;
			}
			return headshotDrawable;
		}
	}
}