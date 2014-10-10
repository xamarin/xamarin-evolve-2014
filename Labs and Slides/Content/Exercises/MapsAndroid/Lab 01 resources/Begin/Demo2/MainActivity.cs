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

namespace MapTestApp
{
    [Activity(Label = "MapTestApp", MainLauncher = true)]
	public class MainActivity : Activity // TODO: Step 2c - implement ILocationListener
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

			// TODO: Step 2a - show user location
//			 _map.UiSettings.MyLocationButtonEnabled = true;
//			 _map.MyLocationEnabled = true;

			// TODO: Step 2b - setup a location manager
//			 _locationManager = GetSystemService(Context.LocationService) as LocationManager;

			// TODO: Step 2d - use a GPS provider
//			string Provider = LocationManager.GpsProvider;
//			if(_locationManager.IsProviderEnabled(Provider))
//			{
//			    _locationManager.RequestLocationUpdates (Provider, 2000, 1, this);
//			} 
//			else 
//			{
//			    Log.Info("error", Provider + " is not available. Does the device have location services enabled?");
//			}

			// TODO: Step 2e - use a generic location provider instead
//			Criteria locationCriteria = new Criteria();
//			locationCriteria.Accuracy = Accuracy.Coarse;
//			locationCriteria.PowerRequirement = Power.Medium;
//
//			var locationProvider = _locationManager.GetBestProvider(locationCriteria, true);
//			if (locationProvider != null)
//			{
//			    _locationManager.RequestLocationUpdates(locationProvider, 2000, 1, this);
//			} else
//			{
//			    Log.Info("error", "Best provider is not available. Does the device have location services enabled?");
//			}
        }

        // TODO: Step 2c - implement ILocationListener
//        public void OnLocationChanged(Location location)
//        {
//            _map.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(new Android.Gms.Maps.Model.LatLng(location.Latitude, location.Longitude), 5.0f));
//        }
//
//        public void OnProviderDisabled(string provider)
//        {
//            // throw new NotImplementedException();
//        }
//
//        public void OnProviderEnabled(string provider)
//        {
//            // throw new NotImplementedException();
//        }
//
//        public void OnStatusChanged(string provider, Availability status, Bundle extras)
//        {
//            // throw new NotImplementedException();
//        }
    }
}


