using System;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

namespace Demo3LocationUpdater
{
    public partial class LocationUpdaterViewController : UIViewController
    {
        public LocationUpdaterViewController(IntPtr handle) : base(handle)
        {
        }

		bool subscribedToHandler;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// TODO: Demo 3 - Step 2 - Subscribe to the LocationUpdated event once and only if not done before.
//			if (!subscribedToHandler)
//			{
//				AppDelegate.Manager.LocationUpdated += HandleLocationChanged;
//				subscribedToHandler = true;
//			}

			// TODO: Demo3 - Step 3a - Subscribe to the LocationUpdated event when app is active, but don't subscribe twice.
//			UIApplication.Notifications.ObserveDidBecomeActive ((sender, e) => {
//				if(!subscribedToHandler)
//				{
//					AppDelegate.Manager.LocationUpdated += HandleLocationChanged;
//					subscribedToHandler = true;
//				}
//			});

			// TODO: Demo3 - Step 3b - Unsubscribe from the LocationUpdated event when the app is backgrounded
//			UIApplication.Notifications.ObserveDidEnterBackground ((sender, e) => {
//				AppDelegate.Manager.LocationUpdated -= HandleLocationChanged;
//				subscribedToHandler = false;
//			});
		}

        public void HandleLocationChanged (object sender, LocationUpdatedEventArgs e)
        {
            // handle foreground updates
            CLLocation location = e.Location;

            LblAltitude.Text = location.Altitude + " meters";
            LblLongitude.Text = location.Coordinate.Longitude.ToString ();
            LblLatitude.Text = location.Coordinate.Latitude.ToString ();
            LblCourse.Text = location.Course.ToString ();
            LblSpeed.Text = location.Speed.ToString ();

            Console.WriteLine ("UI updated");
        }
    }
}

