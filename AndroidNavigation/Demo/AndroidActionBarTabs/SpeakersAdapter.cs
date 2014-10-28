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

namespace com.xamarin.university.mobilenav.android.actionbartabs
{
	public class AnimalsAdapter: BaseAdapter<Animal>, ISectionIndexer
	{
		private List<Animal> data;
		private Activity context;

		public AnimalsAdapter (Activity activity, IEnumerable<Animal> animals)
		{
			data = (from s in animals
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

		public override Animal this [int position] {
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
				view = context.LayoutInflater.Inflate (Resource.Layout.animal_row, null);
			}
			
			var animal = data [position];
			
			var imageView = view.FindViewById<ImageView> (Resource.Id.headshotImageView);
			//var headshot = GetHeadShot (animal.HeadshotUrl);
			//imageView.SetImageDrawable (headshot);
			
			var animalNameView = view.FindViewById<TextView> (Resource.Id.animalNameTextView);
			animalNameView.Text = animal.Name;
			
			var speciesNameTextView = view.FindViewById<TextView> (Resource.Id.speciesNameTextView);
			//speciesNameTextView.Text = animal.Species;
			
			var twitterHandleView = view.FindViewById<TextView> (Resource.Id.twitterTextView);
			//twitterHandleView.Text = "@" + animal.TwitterHandle;
			
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

