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
	internal class AnimalDetailsFragment : Fragment
	{
		public static AnimalDetailsFragment NewInstance (int playId)
		{
			var detailsFrag = new AnimalDetailsFragment { Arguments = new Bundle () };
			detailsFrag.Arguments.PutInt ("current_animal_id", playId);
			return detailsFrag;
		}

		TextView animalNameTextView;
		ImageView headshotImageView;
		TextView speciesNameTextView;
		TextView twitterHandleView;

		public int ShownAnimalIndex {
			get { return Arguments.GetInt ("current_animal_id", 0); }
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			if (container == null) {
				// Currently in a layout without a container, so no reason to create our view.
				return null;
			}

			var view = inflater.Inflate(Resource.Layout.animal_screen, container, false);

			var animal = EvolveData.AnimalData [ShownAnimalIndex];

			headshotImageView = view.FindViewById<ImageView> (Resource.Id.headshotImageView);
			//var headshot = GetHeadShot (animal.HeadshotUrl);
			//headshotImageView.SetImageDrawable (headshot);

			animalNameTextView = view.FindViewById<TextView> (Resource.Id.animalNameTextView);
			animalNameTextView.Text = animal.Name;

			speciesNameTextView = view.FindViewById<TextView> (Resource.Id.speciesNameTextView);
			speciesNameTextView.Text = animal.Species;

			twitterHandleView = view.FindViewById<TextView> (Resource.Id.twitterTextView);
			//twitterHandleView.Text = "@" + animal.TwitterHandle;

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