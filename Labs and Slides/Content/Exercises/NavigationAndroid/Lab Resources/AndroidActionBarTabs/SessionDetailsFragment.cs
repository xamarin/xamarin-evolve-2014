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
	internal class SessionDetailsFragment : Fragment
	{
		public static SessionDetailsFragment NewInstance (int playId)
		{
			var detailsFrag = new SessionDetailsFragment { Arguments = new Bundle () };
			detailsFrag.Arguments.PutInt ("current_session_id", playId);
			return detailsFrag;
		}

		TextView sessionTitleTextView;
		TextView locationTextView;
		TextView speakerNameTextView;

		public int ShownSessionIndex {
			get { return Arguments.GetInt ("current_session_id", 0); }
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			if (container == null) {
				// Currently in a layout without a container, so no reason to create our view.
				return null;
			}

			var view = inflater.Inflate(Resource.Layout.session_screen, container, false);

			var session = EvolveData.SessionData [ShownSessionIndex];

			sessionTitleTextView = view.FindViewById<TextView> (Resource.Id.sessionTitleTextView);
			sessionTitleTextView.Text = session.Title;

			locationTextView = view.FindViewById<TextView> (Resource.Id.locationTextView);
			locationTextView.Text = session.Location;

			speakerNameTextView = view.FindViewById<TextView> (Resource.Id.speakerNameTextView);
			speakerNameTextView.Text = session.Speaker;

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