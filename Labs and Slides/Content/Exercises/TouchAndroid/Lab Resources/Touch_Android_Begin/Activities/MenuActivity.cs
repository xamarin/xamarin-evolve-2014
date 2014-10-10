using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Touch.Droid.Activities
{

    /// <summary>
    ///   The main activity is implemented as a ListActivity. When the user
    ///   clicks on a item in the ListView, we will display the appropriate activity.
    /// </summary>
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class MenuActivity : ListActivity
    {
		private Dictionary<string, Intent> _gestureActivities;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

			_gestureActivities = new Dictionary<string, Intent>
				{
					{ "Touch Sample", new Intent(this, typeof(TouchActivity)) }, 
					{ "Gesture Recognizer", new Intent(this, typeof(GestureRecognizerActivity)) },
					{ "Custom Gesture", new Intent(this, typeof(CustomGestureRecognizerActivity))}
				};

			ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, _gestureActivities.Select(ga => ga.Key).ToList());
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
			var startActivity = _gestureActivities.ElementAt(position);

			StartActivity(startActivity.Value);
        }
    }
}
