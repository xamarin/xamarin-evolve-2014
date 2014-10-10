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
		CLLocationManager locationManager = new CLLocationManager ();

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

        // TODO: Step 2c - Add reusable identifier constant for pin views
        private string pId = "PinAnnotation";

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			
            // Perform any additional setup after loading the view, typically from a nib.

            // add the map view
            var map = new MKMapView(UIScreen.MainScreen.Bounds);
            View.Add(map);

            // change the map style
            map.MapType = MKMapType.Standard;

            // enable/disable interactions
            // map.ZoomEnabled = false;
            // map.ScrollEnabled = false;

            // show user location
			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
				locationManager.RequestWhenInUseAuthorization();
			}
            map.ShowsUserLocation = true;

            // TODO: Step 2a - Add a point annotation
            map.AddAnnotation(new MKPointAnnotation()
            {
                Title = "MyAnnotation",
                Coordinate = new MonoTouch.CoreLocation.CLLocationCoordinate2D(42.364260, -71.120824)
            });

            // TODO: Step 2b - Customize annotation view via GetViewForAnnotation delegate
            map.GetViewForAnnotation = delegate(MKMapView mapView, NSObject annotation)
            {
                if (annotation is MKUserLocation)
                    return null;

                MKPinAnnotationView pinView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation(pId);
                if (pinView == null)
                {
                    pinView = new MKPinAnnotationView(annotation, pId);

                    // TODO: Step 2e - Move one-time setup to here
                    pinView.PinColor = MKPinAnnotationColor.Green;
                    pinView.CanShowCallout = true;

                    // TODO: Step 2d - Add accessory views to the pin
                    pinView.RightCalloutAccessoryView = UIButton.FromType(UIButtonType.DetailDisclosure);
					pinView.LeftCalloutAccessoryView = new UIImageView(UIImage.FromFile("Icon-29.png"));
                }

                return pinView;
            };
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

