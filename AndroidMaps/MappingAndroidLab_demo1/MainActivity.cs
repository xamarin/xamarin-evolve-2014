using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;

namespace MapTestApp
{
    [Activity(Label = "MapTestApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private GoogleMap _map;
        private MapFragment _mapFragment;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
        }

		protected override void OnResume()
		{
			base.OnResume();

			// TODO: Step 1c - Get a handle on the map element
			#region Find Map Fragment and get a refernce to the Google Map object

            _mapFragment = FragmentManager.FindFragmentById(Resource.Id.map) as MapFragment;
           
			_map = _mapFragment.Map;

			#endregion

			#region Set the Map Type

			// TODO: Step 1d - Set the map type 
//	         _map.MapType = GoogleMap.MapTypeNormal;
//	         _map.MapType = GoogleMap.MapTypeSatellite;
//	         _map.MapType = GoogleMap.MapTypeHybrid;
			_map.MapType = GoogleMap.MapTypeTerrain;

			#endregion

			#region Disable Interactions

			// TODO: Step 1e - disable interactions

	        _map.UiSettings.RotateGesturesEnabled = false;
	        _map.UiSettings.TiltGesturesEnabled = false;
	        _map.UiSettings.ScrollGesturesEnabled = false;
	        _map.UiSettings.ZoomControlsEnabled = false;
	        _map.UiSettings.ZoomGesturesEnabled = false; 




			#endregion
		}
    }
}


