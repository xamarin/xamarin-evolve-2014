// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace iOSBackgrounding
{
	[Register ("MainController")]
	partial class MainController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblLocation { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.MapKit.MKMapView mapView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (lblLocation != null) {
				lblLocation.Dispose ();
				lblLocation = null;
			}
			if (mapView != null) {
				mapView.Dispose ();
				mapView = null;
			}
		}
	}
}
