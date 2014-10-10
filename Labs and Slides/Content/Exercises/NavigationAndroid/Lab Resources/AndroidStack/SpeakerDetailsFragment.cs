using System;
using Android.OS;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics.Drawables;
using Evolve.Core;

namespace com.xamarin.university.mobilenav.android.stack
{
	internal class SpeakerDetailsFragment : Fragment
	{
		public static SpeakerDetailsFragment NewInstance (int playId)
		{
			var detailsFrag = new SpeakerDetailsFragment { Arguments = new Bundle () };
			detailsFrag.Arguments.PutInt ("current_speaker_id", playId);
			return detailsFrag;
		}

		TextView speakerNameTextView;
		ImageView headshotImageView;
		TextView companyNameTextView;
		TextView twitterHandleView;

		public int ShownSpeakerIndex {
			get { return Arguments.GetInt ("current_speaker_id", 0); }
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			if (container == null) {
				// Currently in a layout without a container, so no reason to create our view.
				return null;
			}

			var view = inflater.Inflate(Resource.Layout.speaker_screen, container, false);

			var speaker = EvolveData.SpeakerData [ShownSpeakerIndex];

			headshotImageView = view.FindViewById<ImageView> (Resource.Id.headshotImageView);
			var headshot = GetHeadShot (speaker.HeadshotUrl);
			headshotImageView.SetImageDrawable (headshot);

			speakerNameTextView = view.FindViewById<TextView> (Resource.Id.speakerNameTextView);
			speakerNameTextView.Text = speaker.Name;

			companyNameTextView = view.FindViewById<TextView> (Resource.Id.companyNameTextView);
			companyNameTextView.Text = speaker.Company;

			twitterHandleView = view.FindViewById<TextView> (Resource.Id.twitterTextView);
			twitterHandleView.Text = "@" + speaker.TwitterHandle;

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