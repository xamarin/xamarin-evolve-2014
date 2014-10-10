using Android.App;
using Android.OS;
using Android.Views;
using Touch.Droid.Views;

namespace Touch.Droid.Activities
{
    [Activity(Label = "@string/activity_gesture_recognizer")]
    public class GestureRecognizerActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //TODO: Step 8 - Set GestureRecognizerView as content view
			//SetContentView( new GestureRecognizerView(this) );
        }
    }
}
