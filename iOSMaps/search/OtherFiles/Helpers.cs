using System;
using CoreLocation;
using MapKit;

namespace Search
{
	public static class Atlanta
	{
		public static double Latitude = 33.7596961;
		public static double Longitude = -84.4170825;
		public static CLLocationCoordinate2D Coordinates = new CLLocationCoordinate2D (Latitude, Longitude);
	}

	public static class UnitedStates
	{
		public static double Latitude = 39.8111444;
		public static double Longitude = -98.5569364;
		public static CLLocationCoordinate2D Coordinates = new CLLocationCoordinate2D (Latitude, Longitude);
	}

	public static class Cheyenne
	{
		public static double Latitude = 41.1481529;
		public static double Longitude = -104.7696278;
		public static CLLocationCoordinate2D Coordinates = new CLLocationCoordinate2D (Latitude, Longitude);
	}

	public static class Helpers
	{

		public static void CenterOnAtlanta (MKMapView map)
		{
			const int miles = 250;
			MKCoordinateSpan span = new MKCoordinateSpan (MilesToLatitudeDegrees (miles), MilesToLongitudeDegrees (miles, Atlanta.Latitude));
			map.Region = new MKCoordinateRegion (Atlanta.Coordinates, span);
		}

		public static void CenterOnCheyenne (MKMapView map)
		{
			const int miles = 15;
			MKCoordinateSpan span = new MKCoordinateSpan (MilesToLatitudeDegrees (miles), MilesToLongitudeDegrees (miles, Cheyenne.Latitude));
			map.Region = new MKCoordinateRegion (Cheyenne.Coordinates, span);
		}

		public static void CenterOnUnitedStates (MKMapView map)
		{
			const int miles = 1800;
			MKCoordinateSpan span = new MKCoordinateSpan (MilesToLatitudeDegrees (miles), MilesToLongitudeDegrees (miles, UnitedStates.Latitude));
			map.Region = new MKCoordinateRegion (UnitedStates.Coordinates, span);
		}

		public static double MilesToLatitudeDegrees (double miles)
		{
			const double earthRadius = 3960.0; // in miles
			const double radiansToDegrees = 180.0 / Math.PI;
			return (miles / earthRadius) * radiansToDegrees;
		}

		public static double MilesToLongitudeDegrees (double miles, double atLatitude)
		{
			const double earthRadius = 3960.0; // in miles
			const double degreesToRadians = Math.PI / 180.0;
			const double radiansToDegrees = 180.0 / Math.PI;
			// derive the earth's radius at that point in latitude
			double radiusAtLatitude = earthRadius * Math.Cos (atLatitude * degreesToRadians);
			return (miles / radiusAtLatitude) * radiansToDegrees;
		}
	}
}