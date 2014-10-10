using System;
using MonoTouch.CoreLocation;
using MonoTouch.UIKit;

namespace Demo3LocationUpdater
{
	public class LocationManager
	{
		// event for the location changing
        public event EventHandler<LocationUpdatedEventArgs> LocationUpdated;

		public LocationManager ()
		{
			LocationUpdated += PrintLocation;
		}

		// create a location manager to get system location updates to the application
		public CLLocationManager LocMgr
        {
            get; private set;
		}

		#pragma warning disable 0618
		public void StartLocationUpdates ()
		{
			// We need the user's permission for our app to use the GPS in iOS. This is done either by the user accepting
			// the popover when the app is first launched, or by changing the permissions for the app in Settings

			if (CLLocationManager.LocationServicesEnabled) {

                LocMgr = new CLLocationManager();
				LocMgr.DesiredAccuracy = 1; // sets the accuracy that we want in meters

                // Handle the LocationsUpdated event which is sent with >= iOS6 to indicate
                // our location (position) has changed.  
                if (UIDevice.CurrentDevice.CheckSystemVersion(6, 0))
                {
                    LocMgr.LocationsUpdated += (sender, e) =>
                    {
                        // fire our custom Location Updated event
                        LocationUpdated(this, new LocationUpdatedEventArgs(e.Locations[e.Locations.Length - 1]));
                    };
                }
                // <= iOS5 used UpdatedLocation which has been deprecated.
                else
                {
                    // This generates a warning.
                    LocMgr.UpdatedLocation += (sender, e) =>
                    {
                        // fire our custom Location Updated event
                        LocationUpdated(this, new LocationUpdatedEventArgs(e.NewLocation));
                    };
                }

				// Start our location updates
				LocMgr.StartUpdatingLocation ();

				// Get some output from our manager in case of failure
				LocMgr.Failed += (sender, e) =>
                {
                    Console.WriteLine("LocationManager failed: {0}", e.Error);
                }; 
				
			} else {

				//Let the user know that they need to enable LocationServices
				Console.WriteLine ("Location services not enabled, please enable this in your Settings");
			}
		}

		//This will keep going in the background and the foreground
		public void PrintLocation (object sender, LocationUpdatedEventArgs e) 
		{
			CLLocation location = e.Location;

			Console.WriteLine ("Altitude: " + location.Altitude + " meters");
			Console.WriteLine ("Longitude: " + location.Coordinate.Longitude);
			Console.WriteLine ("Latitude: " + location.Coordinate.Latitude);
			Console.WriteLine ("Course: " + location.Course);
			Console.WriteLine ("Speed: " + location.Speed);
		}
	}
}