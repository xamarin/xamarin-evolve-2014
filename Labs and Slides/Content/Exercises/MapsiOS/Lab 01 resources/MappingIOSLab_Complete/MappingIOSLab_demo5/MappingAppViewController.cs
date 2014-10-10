using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using System.Diagnostics;
using MonoTouch.CoreLocation;
using System.Linq;
using System.Collections.Generic;

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

            // TODO: Step 5a - search for an address
            SearchForAddress(map);

            // TODO: Step 5c - search for items of interest
            SearchForLocationsNearPosition(map);
        }

        // TODO: Step 5a - search for an address
        private void SearchForAddress(MKMapView mapView)
        {
            var searchRequest = new MKLocalSearchRequest ();
            searchRequest.NaturalLanguageQuery = "Main Street, New York, NY";
            // searchRequest.Region = new MKCoordinateRegion (mapView.UserLocation.Coordinate, new MKCoordinateSpan (0.25, 0.25));

            // perform search
            var localSearch = new MKLocalSearch (searchRequest);
            localSearch.Start (delegate (MKLocalSearchResponse response, NSError error) 
            {
                if (response != null && error == null) 
                {
                    var items = response.MapItems.ToList();
                    PlotItems(mapView, items);
                } 
                else 
                {
                    Console.WriteLine ("local search error: {0}", error);
                }
            });                
        }

        // TODO: Step 5c - Search for items of interest in the current map view
        private void SearchForLocationsNearPosition(MKMapView mapView)
        {
            var searchRequest = new MKLocalSearchRequest();
            searchRequest.NaturalLanguageQuery = "Bakery";
            searchRequest.Region = mapView.Region;

            var localSearch = new MKLocalSearch(searchRequest);
            localSearch.Start (delegate (MKLocalSearchResponse response, NSError error) 
            {
                if (response != null && error == null) 
                {
                    var items = response.MapItems.ToList();
                    PlotItems(mapView, items);

                    // zoom in on the first item we plotted
                    var firstItem = items.FirstOrDefault();
                    if (firstItem != null)
                    {
                        MKCoordinateSpan span = new MKCoordinateSpan(0.8, 0.8);
                        CLLocationCoordinate2D coord = new CLLocationCoordinate2D(
                            firstItem.Placemark.Location.Coordinate.Latitude, 
                            firstItem.Placemark.Location.Coordinate.Longitude);
                        mapView.Region = new MKCoordinateRegion(coord, span);
                    }
                } 
                else 
                {
                    Console.WriteLine ("local search error: {0}", error);
                }
            });
        }

        // TODO: Step 5b - plot found items
        private void PlotItems(MKMapView mapview, List<MKMapItem> items)
        {
            foreach (var item in items)
            {
                mapview.AddAnnotation(new MKPointAnnotation()
                {
                    Title = item.Name,
                    Coordinate = new CLLocationCoordinate2D(item.Placemark.Location.Coordinate.Latitude, item.Placemark.Location.Coordinate.Longitude)
                });
            }
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

        // Handle how overlays are rendered
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
                    circleRenderer.Alpha = 0.5f;
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
            //            var customAn = view.Annotation as CustomAnnotation;
            //
            //            var alert = new UIAlertView(customAn != null ? "Custom Annotation" : "Generic Annotation", 
            //                customAn != null ? customAn.Title : "Title Text", 
            //                null, "OK");
            //
            //            alert.Show ();
        }

        // Add event handler for marker being tapped
        public override void DidSelectAnnotationView(MKMapView mapView, MKAnnotationView view)
        {
            //            var alert = new UIAlertView("Marker was tapped", "Marker tapped", null, "OK");
            //            alert.Show ();
        }


    }
}

