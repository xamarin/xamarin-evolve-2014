using System;
using System.Drawing;
using Foundation;
using UIKit;
using MapKit;
using CoreLocation;

namespace MapKitBasics
{
	public partial class MapKitBasicsViewController : UIViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

//			//TODO : Demo 1 - Step 1 - Add map to screen
//			var map = new MKMapView (UIScreen.MainScreen.Bounds);
//			View.Add (map);

//			//TODO : Demo 1 - Step 2 - Change map type
//			map.MapType = MKMapType.Standard;
//			map.MapType = MKMapType.Satellite;
//			map.MapType = MKMapType.Hybrid;

//			//TODO : Demo 1 - Step 3 - Show user location
//			locationManager = new CLLocationManager ();
//
//			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
//				locationManager.RequestWhenInUseAuthorization ();
//				//TODO - Demo 1 - Step XX - Add to info.plist
//				//NSLocationWhenInUseUsageDescription
//			}
//
//			if (CLLocationManager.LocationServicesEnabled) {
//				map.ShowsUserLocation = true;
//			}

//			//TODO : Demo 1 - Step 4 - Turn off interaction options
//			map.ZoomEnabled = false;
//			map.PitchEnabled = false;
//			map.ScrollEnabled = false;

//			//TODO : Demo 1 - Step 5 - Center map
//			var coords = new CLLocationCoordinate2D (Atlanta.Latitude, Atlanta.Longitude);
//			map.CenterCoordinate = coords;

//			//TODO : Demo 1 - Step 6 - Zoom on map
//			const int milesToZoom = 10;
//			var latitudeDelta = Helpers.MilesToLatitudeDegrees (milesToZoom);
//			var longitudeDelta = Helpers.MilesToLongitudeDegrees (milesToZoom, coords.Latitude);
//			MKCoordinateSpan span = new MKCoordinateSpan (latitudeDelta, longitudeDelta);
//			map.Region = new MKCoordinateRegion (coords, span);

		}

		CLLocationManager locationManager;

		public MapKitBasicsViewController (IntPtr handle) : base (handle) {}
	}
}