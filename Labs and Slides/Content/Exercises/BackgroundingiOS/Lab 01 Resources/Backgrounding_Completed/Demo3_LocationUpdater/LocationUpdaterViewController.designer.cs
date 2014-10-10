// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace Demo3LocationUpdater
{
	[Register ("Demo_3_LocationUpdaterViewController")]
	partial class LocationUpdaterViewController
	{
		[Outlet]
		[GeneratedCodeAttribute ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UILabel LblAltitude { get; set; }

		[Outlet]
		[GeneratedCodeAttribute ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UILabel LblCourse { get; set; }

		[Outlet]
		[GeneratedCodeAttribute ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UILabel LblLatitude { get; set; }

		[Outlet]
		[GeneratedCodeAttribute ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UILabel LblLongitude { get; set; }

		[Outlet]
		[GeneratedCodeAttribute ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UILabel LblSpeed { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (LblAltitude != null) {
				LblAltitude.Dispose ();
				LblAltitude = null;
			}
			if (LblCourse != null) {
				LblCourse.Dispose ();
				LblCourse = null;
			}
			if (LblLatitude != null) {
				LblLatitude.Dispose ();
				LblLatitude = null;
			}
			if (LblLongitude != null) {
				LblLongitude.Dispose ();
				LblLongitude = null;
			}
			if (LblSpeed != null) {
				LblSpeed.Dispose ();
				LblSpeed = null;
			}
		}
	}
}
