using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace MappingApp
{
    public partial class MappingAppViewController : UIViewController
    {
		CLLocationManager locationManager = new CLLocationManager();

        public MappingAppViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
			
            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			
            // Perform any additional setup after loading the view, typically from a nib.

            // TODO: Step 1a - add the map view
            // var map = new MKMapView(UIScreen.MainScreen.Bounds);
            // View.Add(map);

            // TODO: Step 1b - change the map style
            // map.MapType = MKMapType.Standard;
            // map.MapType = MKMapType.Satellite;
            // map.MapType = MKMapType.Hybrid;

            // TODO: Step 1c - enable/disable interactions
            // map.ZoomEnabled = false;
            // map.ScrollEnabled = false;

            // TODO: Step 1d - show user location
			// if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
			// 	 locationManager.RequestAlwaysAuthorization ();
			// }
            // map.ShowsUserLocation = true;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}

