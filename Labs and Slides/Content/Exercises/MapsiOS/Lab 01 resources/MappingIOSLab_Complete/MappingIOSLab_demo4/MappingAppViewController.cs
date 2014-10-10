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

            // specify a custom map delegate
            var mapDelegate = new MyMapDelegate();
            map.Delegate = mapDelegate;

            // add a point annotation
            map.AddAnnotation(new MKPointAnnotation()
            {
                Title = "MyAnnotation",
                Coordinate = new CLLocationCoordinate2D(42.364260, -71.120824)
            });

            // add a custom annotation
            // map.AddAnnotation(new CustomAnnotation("CustomSpot", new CLLocationCoordinate2D(38.364260, -68.120824)));

            // TODO: Step 4a - draw a circle overlay
            var circleOverlay = MKCircle.Circle(new CLLocationCoordinate2D(33.755, -84.39), 100 * 1609.34); // 1609.34 = meters in a mile
            map.AddOverlay(circleOverlay);

            // TODO: Step 4b - draw a polygon (Wyoming)
            var stateOverlay = MKPolygon.FromCoordinates(new CLLocationCoordinate2D[]
                {
                    new CLLocationCoordinate2D(45.00, -111.00),
                    new CLLocationCoordinate2D(45, -104),
                    new CLLocationCoordinate2D(41, -104),
                    new CLLocationCoordinate2D(41, -111)
                });
            map.AddOverlay(stateOverlay);
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

    // Setup a map delgate to handle annotations and relative eventing
    class MyMapDelegate : MKMapViewDelegate
    {
        string pId = "PinAnnotation";
        string cId = "CustomAnnotation";

        // Review new GetViewForAnnotation method that checks for annotation type before returning a view to use
        public override MKAnnotationView GetViewForAnnotation (MKMapView mapView, NSObject annotation)
        {
            MKAnnotationView anView;

            if (annotation is MKUserLocation)
                return null; 

            if (annotation is CustomAnnotation) {

                // show custom annotation
                anView = mapView.DequeueReusableAnnotation (cId);

                if (anView == null)
                    anView = new MKAnnotationView (annotation, cId);

				anView.Image = UIImage.FromFile ("Icon-29.png");
                anView.CanShowCallout = true;
                anView.Draggable = true;
                anView.RightCalloutAccessoryView = UIButton.FromType (UIButtonType.DetailDisclosure);

            } else {

                // show pin annotation
                anView = (MKPinAnnotationView)mapView.DequeueReusableAnnotation (pId);

                if (anView == null)
                    anView = new MKPinAnnotationView (annotation, pId);

                ((MKPinAnnotationView)anView).PinColor = MKPinAnnotationColor.Green;
                anView.CanShowCallout = true;
            }

            return anView;
        }

		/// Because we set anView.Draggable = true; we need to also handle the Ending drag event, or else our annotation will forever be "floating" over the map
		public override void ChangedDragState (MKMapView mapView, MKAnnotationView annotationView, MKAnnotationViewDragState newState, MKAnnotationViewDragState oldState)
		{
			switch (newState) {
			case MKAnnotationViewDragState.Ending:
				annotationView.SetDragState (MKAnnotationViewDragState.None, false);
				break;
			}
		}

        // TODO: Step 4c - Handle how overlays are rendered
        MKCircleRenderer circleRenderer = null;
        MKPolygonRenderer polyRenderer = null;
        public override MKOverlayRenderer OverlayRenderer(MKMapView mapView, IMKOverlay overlay)
        {
            if (overlay is MKCircle)
            {
                if (circleRenderer == null)
                {
                    circleRenderer = new MKCircleRenderer(overlay as MKCircle);
                    circleRenderer.FillColor = UIColor.Purple;
                    circleRenderer.Alpha = 0.8f;
                }
                return circleRenderer;

            } else if (overlay is MKPolygon)
            {
                if (polyRenderer == null)
                {
                    polyRenderer = new MKPolygonRenderer(overlay as MKPolygon);
                    polyRenderer.FillColor = UIColor.Green;
                    polyRenderer.Alpha = 0.5f;
                }
                return polyRenderer;
            } else
            {
                Debug.WriteLine("OverlayRenderer() - Unknown overlay type!");
                return null;
            }

        }            

        // Add event handler for accessory being tapped
        public override void CalloutAccessoryControlTapped (MKMapView mapView, MKAnnotationView view, UIControl control)
        {
            var customAn = view.Annotation as CustomAnnotation;

            var alert = new UIAlertView(customAn != null ? "Custom Annotation" : "Generic Annotation", 
                customAn != null ? customAn.Title : "Title Text", 
                null, "OK");

            alert.Show ();
        }

        // Add event handler for marker being tapped
        public override void DidSelectAnnotationView(MKMapView mapView, MKAnnotationView view)
        {
            var alert = new UIAlertView("Marker was tapped", "Marker tapped", null, "OK");
            alert.Show ();
        }
    }
}

