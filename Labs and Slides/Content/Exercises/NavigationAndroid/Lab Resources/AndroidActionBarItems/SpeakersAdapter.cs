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

namespace com.xamarin.university.mobilenav.android.actionbaritems
{
	public class SpeakersAdapter: BaseAdapter<Speaker>, ISectionIndexer
	{
		private List<Speaker> data;
		private Activity context;

		public SpeakersAdapter (Activity activity, IEnumerable<Speaker> speakers)
		{
			data = (from s in speakers
			        orderby s.Name
			        select s).ToList ();
			context = activity;

			// setup data for iSectionIndexer
			alphaIndex = new Dictionary<string, int> ();
			for (int i = 0; i < data.Count; i++) {
				var key = data [i].Name [0].ToString ();  // first character of name
				if (!alphaIndex.ContainsKey (key))
					alphaIndex.Add (key, i);
			}
			sections = new string[alphaIndex.Keys.Count];
			alphaIndex.Keys.CopyTo (sections, 0);
			sectionsObjects = new Java.Lang.Object[sections.Length];
			for (int i = 0; i < sections.Length; i++) {
				sectionsObjects [i] = new Java.Lang.String (sections [i]);
			}
		}
		// This code sets up the indexer
		// -- ISectionIndexer --
		string[] sections;
		Java.Lang.Object[] sectionsObjects;
		Dictionary<string, int> alphaIndex;

		public int GetPositionForSection (int section)
		{
			return alphaIndex [sections [section]];
		}

		public int GetSectionForPosition (int position)
		{
			int prevSection = 0; 
			for (int i = 0; i < sections.Length; i++) {
				if (GetPositionForSection (i) > position && prevSection <= position) { 
					prevSection = i;
					break; 
				}
				prevSection = i; 
			} 
			return prevSection; 
		}

		public Java.Lang.Object[] GetSections ()
		{
			return sectionsObjects;
		}
		// -- END ISectionIndexer --
		public override long GetItemId (int position)
		{
			return position;
		}

		public override Speaker this [int position] {
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
				view = context.LayoutInflater.Inflate (Resource.Layout.speaker_row, null);
			}
			
			var speaker = data [position];
			
			var imageView = view.FindViewById<ImageView> (Resource.Id.headshotImageView);
			var headshot = GetHeadShot (speaker.HeadshotUrl);
			
			imageView.SetImageDrawable (headshot);
			
			var speakerNameView = view.FindViewById<TextView> (Resource.Id.speakerNameTextView);
			speakerNameView.Text = speaker.Name;
			
			var companyNameTextView = view.FindViewById<TextView> (Resource.Id.companyNameTextView);
			companyNameTextView.Text = speaker.Company;
			
			var twitterHandleView = view.FindViewById<TextView> (Resource.Id.twitterTextView);
			twitterHandleView.Text = "@" + speaker.TwitterHandle;
			
			return view;
		}

		private Drawable GetHeadShot (string url)
		{
			Drawable headshotDrawable = null;
			try {
				headshotDrawable = Drawable.CreateFromStream (context.Assets.Open (url), null);
			} catch (Exception ex) {
				Log.Debug (GetType ().FullName, "Error getting headshot for " + url + ", " + ex.ToString ());
				headshotDrawable = null;
			}
			return headshotDrawable;
		}
	}
}

