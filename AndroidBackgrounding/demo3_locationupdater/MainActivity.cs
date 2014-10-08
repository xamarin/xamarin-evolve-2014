using Android.App;
using Android.Util;
using Android.Widget;
using Android.OS;

namespace Demo3LocationUpdater
{
	[Activity (Label = "Location Watcher", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		const string logTag = "Location Watcher";

		TextView latText, lonText, altText, speedText, accuracyText, bearingText;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			Log.Debug (logTag, "OnCreate called, App is becoming Active");
			
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			latText = FindViewById<TextView>(Resource.Id.latText);
			lonText = FindViewById<TextView>(Resource.Id.lonText);
			altText = FindViewById<TextView>(Resource.Id.altText);
			speedText = FindViewById<TextView>(Resource.Id.speedText);
			accuracyText = FindViewById<TextView>(Resource.Id.accuracyText);
			bearingText = FindViewById<TextView>(Resource.Id.bearingText);

			// Initialize everything to blank
			latText.Text = lonText.Text = altText.Text = speedText.Text = 
				accuracyText.Text = bearingText.Text = string.Empty;

			// Hook into the connection changed event from our singleton.
			App.Current.ConnectionChanged += (sender, e) => 
			{
				Log.Debug(logTag, "ConnectionChanged: " + e.IsConnected);
				if (e.IsConnected) {
					App.Current.LocationService.LocationChanged += OnLocationChanged;
				}
				else {
					App.Current.LocationService.LocationChanged -= OnLocationChanged;
					latText.Text = lonText.Text = altText.Text = speedText.Text = 
						accuracyText.Text = bearingText.Text = string.Empty;
				}
			};
		}

		protected override void OnStart()
		{
			Log.Debug (logTag, "OnStart called, App is Active");
			base.OnStart();
		}

		protected override void OnResume()
		{
			Log.Debug (logTag, "OnResume called, app is ready to interact with the user");
			base.OnResume();
		}

		protected override void OnPause()
		{
			if (App.Current.LocationService != null) {
				App.Current.LocationService.LocationChanged -= OnLocationChanged;
			}

			Log.Debug (logTag, "OnPause called, App is moving to background");
			base.OnPause();
		}

		protected override void OnRestart()
		{
			if (App.Current.LocationService != null) {
				App.Current.LocationService.LocationChanged += OnLocationChanged;
			}

			base.OnRestart();
		}

		protected override void OnStop()
		{
			Log.Debug (logTag, "OnStop called, App is in the background");
			base.OnStop();
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			Log.Debug (logTag, "OnDestroy called, App is Terminating");
		}

		void OnLocationChanged(object sender, Android.Locations.LocationChangedEventArgs e)
		{
			Log.Debug(logTag, "OnLocationChanged - UI being updated.");

			var loc = e.Location;

			RunOnUiThread(() => {
				latText.Text = loc.Latitude.ToString();
				lonText.Text = loc.Longitude.ToString();
				altText.Text = loc.Altitude.ToString();
				speedText.Text = loc.Speed.ToString();
				accuracyText.Text = loc.Accuracy.ToString();
				bearingText.Text = loc.Bearing.ToString();
			});
		}
	}
}


