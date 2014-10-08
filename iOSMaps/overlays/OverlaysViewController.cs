using System;
using UIKit;
using MapKit;
using CoreLocation;

namespace Overlays
{
	public partial class OverlaysViewController : UIViewController
	{
		private MKCircleRenderer circleRenderer = null;
		private MKPolygonRenderer polyRenderer = null;
		const int radius = 80467;
		// meters in 50 miles

		private MKMapView map;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			InitializeMap ();

			//TODO : Demo 3 - Step 1 - Add circle overlay
//			FindZombieInfestedZones ();

			//TODO : Demo 3 - Step 2 - Add polygon overlay
//			FindSafeZones ();

			//TODO : Demo 3 - Step 3 - Add polyline overlay
//			FindRouteToSafeZone ();
		}

		void FindZombieInfestedZones ()
		{
			var circleOverlay = MKCircle.Circle (CDC.Coordinates, radius);
			map.AddOverlay (circleOverlay);

			map.OverlayRenderer = (mapView, overlay) => {
				if (overlay is MKCircle) {
					circleRenderer = new MKCircleRenderer (overlay as MKCircle) {
						FillColor = UIColor.Red,
						Alpha = 0.5f
					};
					return circleRenderer;
				}
				return null;
			};

			Helpers.CenterOnAtlanta (map);
		}

		void FindSafeZones ()
		{
			var polygonOverlay = MKPolygon.FromCoordinates (new CLLocationCoordinate2D[] {
				new CLLocationCoordinate2D (45.00, -111.00),
				new CLLocationCoordinate2D (45, -104),
				new CLLocationCoordinate2D (41, -104),
				new CLLocationCoordinate2D (41, -111)
			});

			map.AddOverlay (polygonOverlay);

			map.OverlayRenderer = (mapView, overlay) => {
				if (overlay is MKCircle) {
					if (circleRenderer == null) {
						circleRenderer = new MKCircleRenderer (overlay as MKCircle) {
							FillColor = UIColor.Red,
							Alpha = 0.5f
						};
					}
					return circleRenderer;
				} else if (overlay is MKPolygon) {
					if (polyRenderer == null) {
						polyRenderer = new MKPolygonRenderer (overlay as MKPolygon);
						polyRenderer.FillColor = UIColor.Green;
						polyRenderer.Alpha = 0.5f;
					}
					return polyRenderer;
				}
				return null;
			};

			Helpers.CenterOnCheyenne (map);
		}

		void FindRouteToSafeZone ()
		{
			MKPlacemarkAddress address = null;

			//Start at our current location
			var fromLocation = new MKPlacemark (CDC.Coordinates, address);

			//Go to the safe zone
			var destinationLocation = new MKPlacemark (new CLLocationCoordinate2D (Cheyenne.Latitude, Cheyenne.Longitude), address);

			var request = new MKDirectionsRequest {
				Source = new MKMapItem (fromLocation),
				Destination = new MKMapItem (destinationLocation),
				RequestsAlternateRoutes = false
			};

			var directions = new MKDirections (request);

			//Async network call to Apple's servers
			directions.CalculateDirections ((response, error) => {
				if (error != null) {
					Console.WriteLine (error.LocalizedDescription);
				} else {

					foreach (var route in response.Routes) {
						map.AddOverlay (route.Polyline);
					}
				}
			});

			map.OverlayRenderer = (mapView, overlay) => {
				if (overlay is MKCircle) {
					if (circleRenderer == null) {
						circleRenderer = new MKCircleRenderer (overlay as MKCircle) {
							FillColor = UIColor.Red,
							Alpha = 0.5f
						};
					}
					return circleRenderer;
				} else if (overlay is MKPolygon) {
					if (polyRenderer == null) {
						polyRenderer = new MKPolygonRenderer (overlay as MKPolygon);
						polyRenderer.FillColor = UIColor.Green;
						polyRenderer.Alpha = 0.5f;
					}
					return polyRenderer;
				} else if (overlay is MKPolyline) {
					var route = (MKPolyline)overlay;
					var renderer = new MKPolylineRenderer (route) {
						StrokeColor = UIColor.Blue
					};
					return renderer;
				}
				return null;
			};

			Helpers.CenterOnUnitedStates (map);
		}

		CLLocationManager locationManager;
		private void InitializeMap ()
		{
			locationManager = new CLLocationManager ();

			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
				locationManager.RequestWhenInUseAuthorization ();
			}

			map = new MKMapView (UIScreen.MainScreen.Bounds);
			View.Add (map);

			if (CLLocationManager.LocationServicesEnabled) {
				map.ShowsUserLocation = true;
			}

			var centersForDiseaseControlAnnotation = new MKPointAnnotation {
				Coordinate = new CLLocationCoordinate2D (CDC.Latitude, CDC.Longitude),
				Title = "Centers for Disease Control",
				Subtitle = "Zombie Outbreak"
			};
			map.AddAnnotation (centersForDiseaseControlAnnotation);
			Helpers.CenterOnAtlanta (map);
		}


		public OverlaysViewController (IntPtr handle) : base (handle)
		{
		}

	}
}