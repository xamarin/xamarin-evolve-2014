using System;
using MapKit;
using CoreLocation;

namespace MapKitBasics
{
	public static class Atlanta
	{
		public static double Latitude = 33.7596961;
		public static double Longitude = -84.4170825;
		public static CLLocationCoordinate2D Coordinates = new CLLocationCoordinate2D(Latitude, Longitude);
	}

	public static class Helpers
	{
		private static void CenterOnAtlanta (MKMapView map)
		{
			MKCoordinateSpan span = new MKCoordinateSpan (MilesToLatitudeDegrees (250), MilesToLongitudeDegrees (250, Atlanta.Latitude));
			map.Region = new MKCoordinateRegion (Atlanta.Coordinates, span);
		}

		public static double MilesToLatitudeDegrees(double miles)
		{
			const double earthRadius = 3960.0; // in miles
			const double radiansToDegrees = 180.0 / Math.PI;
			return (miles/earthRadius) * radiansToDegrees;
		}

		public static double MilesToLongitudeDegrees(double miles, double atLatitude)
		{
			const double earthRadius = 3960.0; // in miles
			const double degreesToRadians = Math.PI / 180.0;
			const double radiansToDegrees = 180.0 / Math.PI;

			// derive the earth's radius at that point in latitude
			double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
			return (miles / radiusAtLatitude) * radiansToDegrees;
		}
	}
}