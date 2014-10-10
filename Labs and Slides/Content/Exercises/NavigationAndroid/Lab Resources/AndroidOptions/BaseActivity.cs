using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;

namespace com.xamarin.university.mobilenav.android.options
{
	public class BaseActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			var item = menu.Add(Android.Views.Menu.None, 1, 1, new Java.Lang.String("What's On"));
			item.SetIcon(Resource.Drawable.ic_tab_whats_on);
			
			item = menu.Add(Android.Views.Menu.None, 2, 2, new Java.Lang.String("Speakers"));
			item.SetIcon(Resource.Drawable.ic_tab_speakers);
			
			item = menu.Add(Android.Views.Menu.None, 3, 3, new Java.Lang.String("Sessions"));
			item.SetIcon(Resource.Drawable.ic_tab_sessions);
			
			item = menu.Add(Android.Views.Menu.None, 4, 4, new Java.Lang.String("My Schedule"));
			item.SetIcon(Resource.Drawable.ic_tab_my_schedule);
			
			return true;
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			var intent = new Intent();
			switch (item.TitleFormatted.ToString())
			{
			case "What's On":
				
				intent.SetClass(this, typeof(WhatsOnActivity));
				intent.AddFlags(ActivityFlags.ClearTop);            // http://developer.android.com/reference/android/content/Intent.html#FLAG_ACTIVITY_CLEAR_TOP
				StartActivity(intent);
				return true;
				
			case "Speakers": 
				
				intent.SetClass(this, typeof(SpeakersActivity));
				intent.AddFlags(ActivityFlags.ClearTop);            // http://developer.android.com/reference/android/content/Intent.html#FLAG_ACTIVITY_CLEAR_TOP
				StartActivity(intent);
				return true;
				
			case "Sessions": 
				
				intent.SetClass(this, typeof(SessionsActivity));
				intent.AddFlags(ActivityFlags.ClearTop);            // http://developer.android.com/reference/android/content/Intent.html#FLAG_ACTIVITY_CLEAR_TOP
				StartActivity(intent);
				return true;
				
			case "My Schedule":
				
				intent.SetClass(this, typeof(MyScheduleActivity));
				StartActivity(intent);
				return true;
				
			default:
				// generally shouldn't happen...
				return base.OnOptionsItemSelected(item);
			}
		}
	}
}

