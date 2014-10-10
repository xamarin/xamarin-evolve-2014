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
using Xamarin.Geolocation;

namespace MapTestApp
{
	[Activity(Label = "MapTestApp", MainLauncher = true)]
	public class MainActivity2 : Activity
	{
		private GoogleMap _map;
		private MapFragment _mapFragment;
		private Geolocator _locator;

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

			_map.UiSettings.MyLocationButtonEnabled = true;
			_map.MyLocationEnabled = true;

			_locator = new Geolocator(this) {
				DesiredAccuracy = 1000
			};

			_locator.PositionChanged += OnLocationChanged;
			_locator.StartListening(2000, 1);
		}

		protected override void OnPause()
		{
			base.OnPause();
			_locator.StopListening();
		}

		public void OnLocationChanged(object sender, PositionEventArgs e)
		{
			Position location = e.Position;
			_map.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(new Android.Gms.Maps.Model.LatLng(location.Latitude, location.Longitude), 5.0f));
		}
	}
}


