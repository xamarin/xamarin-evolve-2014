using System;
using System.Drawing;
using Foundation;
using UIKit;
using MapKit;
using CoreLocation;

namespace Annotations
{
	public partial class AnnotationsViewController : UIViewController
	{
		const string pinId = "MyPin";
		const string customPinId = "CustomPin";

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			InitializeMap ();

			//TODO : Demo 2 - Step 1 - Create annotation
			//FindCentersForDiseaseControl ();

			//TODO : Demo 2 - Step 3 - create custom annotation
//			FindXamarinHeadquarters ();
		}

		void FindCentersForDiseaseControl ()
		{
			var point = new MKPointAnnotation {
				Coordinate = new CLLocationCoordinate2D (CDC.Latitude, CDC.Longitude),
				Title = "Centers for Disease Control",
				Subtitle = "Zombie Outbreak"
			};

			map.AddAnnotation (point);

			//TODO : Demo 2 - Step 2 - Customize view
			//ColorCentersForDiseaseControlGreen ();

			Helpers.CenterOnCDC (map);
		}

		void ColorCentersForDiseaseControlGreen ()
		{
			map.GetViewForAnnotation = (mapView, annotation) => {
				if (annotation is MKUserLocation)
					return null;

				MKAnnotationView view = null;

				if (annotation is MKPointAnnotation) {
					view = mapView.DequeueReusableAnnotation (pinId);
					if (view == null) {
						view = new MKPinAnnotationView (annotation, pinId);
						((MKPinAnnotationView)view).PinColor = MKPinAnnotationColor.Green;
					}
				}
				return view;
			};
		}

		void FindXamarinHeadquarters ()
		{
			var myCustomAnnotation = new CustomAnnotation (new CLLocationCoordinate2D (XamarinHQ.Latitude, XamarinHQ.Longitude), "Xamarin HQ", "San Francisco");

			//Add custom annotation to screen
			map.AddAnnotation (myCustomAnnotation);

			// Customize view
			map.GetViewForAnnotation = (mapView, annotation) => {
				if (annotation is MKUserLocation)
					return null;

				MKAnnotationView view = null;
				if (annotation is MKPointAnnotation) {
					view = mapView.DequeueReusableAnnotation (pinId);
					if (view == null) {
						view = new MKPinAnnotationView (annotation, pinId);
						((MKPinAnnotationView)view).PinColor = MKPinAnnotationColor.Green;
						((MKPinAnnotationView)view).CanShowCallout = true;

					}
				} else if (annotation is CustomAnnotation) {
					view = mapView.DequeueReusableAnnotation (customPinId);
					if (view == null) {
						view = new MKAnnotationView (annotation, customPinId);
						view.CanShowCallout = true;
					}
					view.Image = UIImage.FromFile ("xamarin.png");
				}
				return view;
			};

			Helpers.CenterOnXamarin (map);
		}

		#region Other Methods

		private MKMapView map;
		private CLLocationManager locationManager;

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
		}

		public AnnotationsViewController (IntPtr handle) : base (handle)
		{
		}

		#endregion
	}
}