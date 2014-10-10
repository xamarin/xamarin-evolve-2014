using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using System.Diagnostics;
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

        // Reusable identifier constant for pin views
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
				locationManager.RequestAlwaysAuthorization ();
			}
            map.ShowsUserLocation = true;

            // TODO: Step 3d - specify a custom map delegate
//            var mapDelegate = new MyMapDelegate();
//            map.Delegate = mapDelegate;

            // Add a point annotation
            map.AddAnnotation(new MKPointAnnotation()
            {
                Title = "MyAnnotation",
                Coordinate = new MonoTouch.CoreLocation.CLLocationCoordinate2D(42.364260, -71.120824)
            });

            // TODO: Step 3f - add a custom annotation
//            map.AddAnnotation(new CustomAnnotation("CustomSpot", new MonoTouch.CoreLocation.CLLocationCoordinate2D(38.364260, -68.120824)));

            // TODO: Step 3a - remove old GetViewForAnnotation delegate code to new delegate - we will recreate this next
            // Customize annotation view via GetViewForAnnotation delegate
            map.GetViewForAnnotation = delegate(MKMapView mapView, NSObject annotation)
            {
                if (annotation is MKUserLocation)
                    return null;

                MKPinAnnotationView pinView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation(pId);
                if (pinView == null)
                {
                    pinView = new MKPinAnnotationView(annotation, pId);

                    pinView.PinColor = MKPinAnnotationColor.Green;
                    pinView.CanShowCallout = true;

                    // Add accessory views to the pin
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

    // TODO: Step 3b - Setup a map delegate to handle annotations and relative eventing
//    class MyMapDelegate : MKMapViewDelegate
//    {
//        string pId = "PinAnnotation";
//        string cId = "CustomAnnotation";
//
//        // TODO: Step 3c -  Review new GetViewForAnnotation method that checks for annotation type before returning a view to use
////        public override MKAnnotationView GetViewForAnnotation (MKMapView mapView, NSObject annotation)
////        {
////            MKAnnotationView anView;
////
////            if (annotation is MKUserLocation)
////                return null; 
////
////            if (annotation is CustomAnnotation) {
////
////                // show custom annotation
////                anView = mapView.DequeueReusableAnnotation (cId);
////
////                if (anView == null)
////                    anView = new MKAnnotationView (annotation, cId);
////
////                anView.Image = UIImage.FromFile ("icon-29.png");
////                anView.CanShowCallout = true;
////                anView.Draggable = true;
////                anView.RightCalloutAccessoryView = UIButton.FromType (UIButtonType.DetailDisclosure);
////
////            } else {
////
////                // show pin annotation
////                anView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation (pId);
////
////                if (anView == null)
////                    anView = new MKPinAnnotationView (annotation, pId);
////
////                ((MKPinAnnotationView)anView).PinColor = MKPinAnnotationColor.Green;
////                anView.CanShowCallout = true;
////            }
////
////            return anView;
////        }
////
////		/// Because we set anView.Draggable = true; we need to also handle the Ending drag event, or else our annotation will forever be "floating" over the map 
////		public override void ChangedDragState (MKMapView mapView, MKAnnotationView annotationView, MKAnnotationViewDragState newState, MKAnnotationViewDragState oldState)
////		{
////			switch (newState) {
////			case MKAnnotationViewDragState.Ending:
////				annotationView.SetDragState (MKAnnotationViewDragState.None, false);
////				break;
////			}
////		}
////
//        // TODO: Step 3g - Add event handler for accessory being tapped
////        public override void CalloutAccessoryControlTapped (MKMapView mapView, MKAnnotationView view, UIControl control)
////        {
////            var customAn = view.Annotation as CustomAnnotation;
////
////            var alert = new UIAlertView(customAn != null ? "Custom Annotation" : "Generic Annotation", 
////                customAn != null ? customAn.Title : "Title Text", 
////                null, "OK");
////
////            alert.Show ();
////        }
//
//        // TODO: Step 3h - Add event handler for marker being tapped
////        public override void DidSelectAnnotationView(MKMapView mapView, MKAnnotationView view)
////        {
////            var alert = new UIAlertView("Marker was tapped", "Marker tapped", null, "OK");
////            alert.Show ();
////        }
//    }
}

