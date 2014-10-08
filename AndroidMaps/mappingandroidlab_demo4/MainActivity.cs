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
using Android.Graphics;

namespace MapTestApp
{
    [Activity(Label = "MapTestApp", MainLauncher = true)]
    public class MainActivity : Activity, ILocationListener
    {
        private GoogleMap _map;
        private MapFragment _mapFragment;
        private LocationManager _locationManager;
		private Marker _newYorkMarker;
		private GroundOverlay _chicagoOverlay;
		private string _gotoNewYorkMarkerID;

        // add lat/long position constants to use
        private static readonly LatLng Location_NewYork = new LatLng(40.714353, -74.005973);
        private static readonly LatLng Location_Chicago = new LatLng(41.878114, -87.629798);
        private static readonly LatLng Location_Xamarin = new LatLng(37.797679, -122.401816);
        private static readonly LatLng Location_Atlanta = new LatLng(33.755, -84.39);

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

			// Set the map type 
			_map.MapType = GoogleMap.MapTypeTerrain;

			// show user location
			_map.MyLocationEnabled = true;

			// setup a location manager
			_locationManager = GetSystemService(Context.LocationService) as LocationManager;

			// Add points on the map
			MarkerOptions marker1 = new MarkerOptions()
				.SetPosition(Location_Xamarin)
				.SetTitle("Xamarin")
				.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueBlue));
			_map.AddMarker(marker1);

			MarkerOptions marker2 = new MarkerOptions()
			    .SetPosition(Location_Atlanta)
			    .SetTitle("Atlanta, GA")
			    .InvokeIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueRed));
			_map.AddMarker(marker2);

			// Add custom marker images on the map
			AddMonkeyMarkersToMap();

			// Add custom arrow callout on map
			AddInitialNewYorkBarToMap();

			// Add custom overlay image on the map
			PositionChicagoGroundOverlay(Location_Chicago);

			// use a generic location provider instead
			Criteria locationCriteria = new Criteria();
			locationCriteria.Accuracy = Accuracy.Coarse;
			locationCriteria.PowerRequirement = Power.Medium;

			var locationProvider = _locationManager.GetBestProvider(locationCriteria, true);
			if (locationProvider != null)
			{
				_locationManager.RequestLocationUpdates(locationProvider, 2000, 1, this);
			} else
			{
				Log.Info("error", "Best provider is not available. Does the device have location services enabled?");
			}

			// TODO: Step 4a - attach map handler for marker touch
            _map.MarkerClick += MapOnMarkerClick;

			// TODO: Step 4c - attach map handler for info window touch
			_map.InfoWindowClick += HandleInfoWindowClick;

			#region extra
			TiltCamera ();
			#endregion
		}

		#region Step 4b - Handle taps on Map Markers
		// TODO: Step 4b - handle map marker taps
		private void MapOnMarkerClick(object sender, GoogleMap.MarkerClickEventArgs markerClickEventArgs)
		{
		    markerClickEventArgs.Handled = true;

		    Marker marker = markerClickEventArgs.P0;

		    if (marker.Id.Equals(_gotoNewYorkMarkerID))
		    {
		        _map.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(Location_NewYork, 13));
		        _gotoNewYorkMarkerID = null;
		        _newYorkMarker.Remove();
		        _newYorkMarker = null;
		    }
		    else
		    {
		        Toast.MakeText(this, String.Format("You clicked on Marker ID {0}", marker.Id), ToastLength.Short).Show();
		    }
		}
		#endregion

		#region Step 4c - Handle Taps on the Info Popup
		// TODO: Step 4c - handle info popup tap
        private void HandleInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            // Draw a circle on the map
            var circleOptions = new CircleOptions();

            circleOptions.InvokeCenter(Location_NewYork);
            circleOptions.InvokeRadius(100000.0);
            circleOptions.InvokeFillColor(Android.Graphics.Color.Argb(150, 59, 153, 212));
            circleOptions.InvokeStrokeColor(Android.Graphics.Color.Rgb(159, 153, 212));
            circleOptions.InvokeStrokeWidth(2);

            _map.AddCircle(circleOptions);

            // Draw a polygon (Wyoming) on the map
            var polygonOptions = new PolygonOptions();
            polygonOptions.Add(new LatLng[]
            {
                new LatLng(45.00, -111.00),
                new LatLng(45, -104),
                new LatLng(41, -104),
                new LatLng(41, -111)
            });

            polygonOptions.InvokeFillColor(Android.Graphics.Color.Argb(150, 21, 48,78));
            polygonOptions.InvokeStrokeColor(Android.Graphics.Color.Rgb(21, 48, 78));
            polygonOptions.InvokeStrokeWidth(2);
            _map.AddPolygon(polygonOptions);
        }
		#endregion

		#region Step 4d - don't forget to detach our map handlers 
		// TODO: Step 4d - detach map handlers on pause
		protected override void OnPause()
		{
		    base.OnPause();

		    _map.MarkerClick -= MapOnMarkerClick;
		    _map.InfoWindowClick -= HandleInfoWindowClick;
		}
		#endregion

		private void AddMonkeyMarkersToMap()
		{
			LatLng[] locationForCustomIconMarkers = new[]
			{
				new LatLng(36.741773, -84.004986),
				new LatLng(37.051696, -83.545667),
				new LatLng(37.311197, -82.902646),
                new LatLng(49.25, -123.1),
			};

            BitmapDescriptor icon = BitmapDescriptorFactory.FromResource(Resource.Drawable.monkey);

			for (int i = 0; i < locationForCustomIconMarkers.Length; i++)
			{
				MarkerOptions markerOptions = new MarkerOptions()
					.SetPosition(locationForCustomIconMarkers[i])
					.InvokeIcon(icon)
					.SetSnippet(String.Format("This is marker #{0}.", i + 1))
					.SetTitle(String.Format("Marker {0}", i + 1));
				_map.AddMarker(markerOptions);
			}
		}

		private void AddInitialNewYorkBarToMap()
		{
			MarkerOptions markerOptions = new MarkerOptions()
				.SetSnippet("Click me to visit New York.")
				.SetPosition(Location_NewYork)
				.SetTitle("Goto New York");
			_newYorkMarker = _map.AddMarker(markerOptions);
			_newYorkMarker.ShowInfoWindow();
			_gotoNewYorkMarkerID = _newYorkMarker.Id;
		}

		private void PositionChicagoGroundOverlay(LatLng position)
		{
			if (_chicagoOverlay == null)
			{
				BitmapDescriptor image = BitmapDescriptorFactory.FromResource(Resource.Drawable.monkey);
				GroundOverlayOptions groundOverlayOptions = new GroundOverlayOptions()
					.Position(position, 150000, 200000)
					.InvokeImage(image);
				_chicagoOverlay = _map.AddGroundOverlay(groundOverlayOptions);
			}
			else
			{
				_chicagoOverlay.Position = Location_Chicago;
			}
		}

        // implement ILocationListener
        public void OnLocationChanged(Location location)
        {
            _map.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(new Android.Gms.Maps.Model.LatLng(location.Latitude, location.Longitude), 5.0f));
        }

        public void OnProviderDisabled(string provider)
        {
            // throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            // throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
            // throw new NotImplementedException();
        }

		#region BonusCode

		public void TiltCamera ()
		{
			CameraPosition.Builder builder = CameraPosition.InvokeBuilder ();
			builder.Target (Location_Atlanta);
			builder.Zoom (18);
			builder.Bearing (155);
			builder.Tilt (45);
			CameraPosition cameraPosition = builder.Build ();
			CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition (cameraPosition);

			if (_map != null) 
			{
				_map.MoveCamera (cameraUpdate);
			}
		}
		#endregion
    }
}


