using System;
using UIKit;
using MapKit;
using CoreLocation;
using System.Collections.Generic;
using System.Linq;

namespace Search
{
	public partial class SearchViewController : UIViewController
	{
		public async override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			InitializeMap ();

			//TODO : Demo 4 - Step 1 - Create search request
//			const int miles = 25;
//			MKCoordinateSpan coordinateSpan = new MKCoordinateSpan (
//				Helpers.MilesToLatitudeDegrees (miles), 
//				Helpers.MilesToLongitudeDegrees (miles, Cheyenne.Latitude));
//
//			var searchRequest = new MKLocalSearchRequest () {
//				NaturalLanguageQuery = "Hospital",
//				Region = new MKCoordinateRegion (Cheyenne.Coordinates, coordinateSpan)
//			};

			//TODO : Demo 4 - Step 2 - Create search
//			var localSearch = new MKLocalSearch(searchRequest);

			//TODO : Demo 4 - Step 3 - Search and wait for response
//			MKLocalSearchResponse response = await localSearch.StartAsync ();

			//TODO : Demo 4 - Step 4 - Plot search results on map
//			PlotResultsOnMap (map, response.MapItems.ToList());
		}
			
		//TODO : Demo 4 - Step 5 - Plot search results on map
		private void PlotResultsOnMap (MKMapView mapview, List<MKMapItem> items)
		{
			foreach (var item in items) {
				mapview.AddAnnotation (new MKPointAnnotation () {
					Title = item.Name,
					Subtitle = item.PhoneNumber ?? "",
					Coordinate = new CLLocationCoordinate2D (item.Placemark.Location.Coordinate.Latitude, item.Placemark.Location.Coordinate.Longitude)
				});
			}
		}

		#region Other Methods

		private MKMapView map;
		private CLLocationManager locationManager;

		void InitializeMap ()
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

			Helpers.CenterOnCheyenne (map);
		}

		public SearchViewController (IntPtr handle) : base (handle)
		{
		}

		#endregion
	}
}