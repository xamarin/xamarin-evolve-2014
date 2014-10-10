using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Util;

namespace com.xamarin.university.mobilenav.android.actionbaritems
{
	[Activity (Label = "@string/app_name", Theme = "@style/Theme.AppCompat", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class MainActivity : ActionBarActivity
	{
		static readonly string Tag = "ActionBarItems";

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			ISubMenu sub = menu.AddSubMenu ("Evolve");
			// group id, , order, text
			sub.Add (0, 1, 1, "What's On");
			sub.Add (0, 2, 2, "Speakers");
			sub.Add (0, 3, 3, "Sessions");

			sub.Item.SetShowAsAction (ShowAsAction.Always | ShowAsAction.WithText);
			return true;

		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			Log.Debug (Tag, "Item {0} has been selected.", item.Order);

			if (item.ItemId == Android.Resource.Id.Home || item.ItemId == 0) {
				return false;
			} 
			var intent = new Intent ();
			switch (item.Order) {
			case 1:
				intent.SetClass (this, typeof(MainActivity));
				intent.AddFlags (ActivityFlags.ClearTop);            // http://developer.android.com/reference/android/content/Intent.html#FLAG_ACTIVITY_CLEAR_TOP
				StartActivity (intent);
				break;
			case 2:
				intent.SetClass (this, typeof(SpeakersActivity));
				intent.AddFlags (ActivityFlags.ClearTop);            // http://developer.android.com/reference/android/content/Intent.html#FLAG_ACTIVITY_CLEAR_TOP
				StartActivity (intent);
				break;
			case 3:
				intent.SetClass (this, typeof(SessionsActivity));
				intent.AddFlags (ActivityFlags.ClearTop);            // http://developer.android.com/reference/android/content/Intent.html#FLAG_ACTIVITY_CLEAR_TOP
				StartActivity (intent);
				break;
			}
			return true;
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);
		}
	}
}


