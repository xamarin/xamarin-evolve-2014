using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Locations;
using Android.Util;
using Android.Gms.Maps.Model;

namespace MapTestApp
{
    [Activity(Label = "MapTestApp", MainLauncher = true)]
	// TODO Step 2 - ILocationListener Interface
	public class MainActivity : Activity, ILocationListener
    {
        private GoogleMap _map;
        private MapFragment _mapFragment;
        private LocationManager _locationManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
        }

        protected override void OnResume ()
        {
            base.OnResume ();

			// Get a handle on the map element
			_mapFragment = FragmentManager.FindFragmentById(Resource.Id.map) as MapFragment;
			_map = _mapFragment.Map;

			#region Show Location
			// TODO: Step 2a - show user location
			 _map.MyLocationEnabled = true;

			_map.UiSettings.MyLocationButtonEnabled = true;
			#endregion

			#region Setup Location Manager

			// TODO: Step 2b - setup a location manager
			 _locationManager = GetSystemService(Context.LocationService) as LocationManager;

			#endregion

			#region Get Location Provider 

			// TODO: Step 2d - use a generic location provider
			Criteria locationCriteria = new Criteria();
			locationCriteria.Accuracy = Accuracy.Coarse;
			locationCriteria.PowerRequirement = Power.Medium;

			var locationProvider = _locationManager.GetBestProvider(locationCriteria, true);
			if (locationProvider != null)
			{
			    _locationManager.RequestLocationUpdates(locationProvider, 2000, 1, this);
			} 

			#endregion

        }

		#region Impliment Methods for ILocationListener

        // TODO: Step 2c - implement ILocationListener
        public void OnLocationChanged(Location location)
        {
            _map.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(location.Latitude, location.Longitude), 5.0f));
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
        }
		#endregion
    }
}


