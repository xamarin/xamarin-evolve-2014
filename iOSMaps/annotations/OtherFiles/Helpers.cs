using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using CoreLocation;
using MapKit;

namespace Annotations
{
	public static class Atlanta
	{
		public static double Latitude = 33.7596961;
		public static double Longitude = -84.4170825;
		public static CLLocationCoordinate2D Coordinates = new CLLocationCoordinate2D(Latitude, Longitude);
	}

	public static class XamarinHQ
	{
		public static double Latitude = 37.7977763;
		public static double Longitude = -122.4018806;
		public static CLLocationCoordinate2D Coordinates = new CLLocationCoordinate2D(Latitude, Longitude);
	}

	public static class CDC
	{
		public static double Latitude = 33.799318;
		public static double Longitude = -84.328008;
		public static CLLocationCoordinate2D Coordinates = new CLLocationCoordinate2D(Latitude, Longitude);
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

		public static void CenterOnCDC (MKMapView map)
		{
			const int miles = 15;
			MKCoordinateSpan span = new MKCoordinateSpan (MilesToLatitudeDegrees (miles), MilesToLongitudeDegrees (miles, CDC.Latitude));
			map.Region = new MKCoordinateRegion (CDC.Coordinates, span);
		}

		public static void CenterOnXamarin (MKMapView map)
		{
			const int miles = 15;
			MKCoordinateSpan span = new MKCoordinateSpan (MilesToLatitudeDegrees (miles), MilesToLongitudeDegrees (miles, XamarinHQ.Latitude));
			map.Region = new MKCoordinateRegion (XamarinHQ.Coordinates, span);
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
