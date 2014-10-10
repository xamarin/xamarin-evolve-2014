using System;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Touch.Droid.Activities
{


    [Activity(Label = "@string/activity_touch_sample")]
    public class TouchActivity : Activity
    {
		private TextView _touchInfoTextView, _durationInfoTextView, _coordinatesInfoTextView;
        private ImageView _touchMeImageView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.touch_layout);
            _touchInfoTextView = FindViewById<TextView>(Resource.Id.touchInfoTextView);
			_durationInfoTextView = FindViewById<TextView> (Resource.Id.durationInfoTextView);
			_coordinatesInfoTextView = FindViewById<TextView> (Resource.Id.coordinatesInfoTextView);

            _touchMeImageView = FindViewById<ImageView>(Resource.Id.touchImageView);

			//TODO: Step 1 - Listen for touch events
            //_touchMeImageView.Touch += TouchMeImageViewOnTouch;
        }

        private void TouchMeImageViewOnTouch(object sender, View.TouchEventArgs touchEventArgs)
        {
            string message = null;

			//TODO: Step 2 - Detect different touch event actions
            //switch (touchEventArgs.Event.Action & MotionEventActions.Mask )
            //{
            //    case MotionEventActions.Down:
            //        message = "Touch Down";
            //        break;
            //    case MotionEventActions.Move:
            //    message = "Touch Move";
            //        break;
            //    case MotionEventActions.Up:
            //        message = "Touch Ends";
            //        break;
            //    default:
            //        message = string.Empty;
            //        break;
            //}

            _touchInfoTextView.Text = message;

			_durationInfoTextView.Text = String.Format ("Duration:  {0}", touchEventArgs.Event.EventTime - touchEventArgs.Event.DownTime);

			_coordinatesInfoTextView.Text = String.Format ("X: {0} Y: {1}", touchEventArgs.Event.GetX(), touchEventArgs.Event.GetY());
        }
    }
}
