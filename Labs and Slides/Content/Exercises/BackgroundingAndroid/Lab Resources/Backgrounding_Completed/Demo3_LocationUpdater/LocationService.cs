using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Locations;
using Android.Util;

namespace Demo3LocationUpdater
{
	/// <summary>
	/// Simple service to expose location information using the
	/// Android LocationManager.
	/// </summary>
	[Service]
	public class LocationService : Service, ILocationListener
	{
		const string logTag = "LocationService";
		IBinder binder = null;
		LocationManager locMgr;

		public event EventHandler<LocationChangedEventArgs> LocationChanged = delegate{};

		public override IBinder OnBind(Intent intent)
		{
			// TODO: Demo3 - Step 2 - Return a binder implementation
			binder = new LocationServiceBinder(this);
			return binder;
		}

		public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
		{
			Log.Debug(logTag, "OnStartCommand: service is running");
			StartLocationUpdates();

			return StartCommandResult.Sticky;
		}

		public override void OnDestroy()
		{
			Log.Debug(logTag, "OnDestroy: service is stopping");
			StopLocationUpdates();
		}

		/// <summary>
		/// This method activates the Android LocationManager and begins reporting
		/// location changes through our own LocationChanged event.
		/// </summary>
		public void StartLocationUpdates()
		{
			locMgr = Application.Context.GetSystemService("location") as LocationManager;
			if (locMgr == null)
				return;

			var locationCriteria = new Criteria() {
				Accuracy = Accuracy.NoRequirement,
				PowerRequirement = Power.NoRequirement
			};

			var locationProvider = locMgr.GetBestProvider(locationCriteria, true);
			locMgr.RequestLocationUpdates(locationProvider, 2000, 0, this);
		}

		/// <summary>
		/// This method deactivates the location reporting.
		/// </summary>
		void StopLocationUpdates()
		{
			if (locMgr != null) {
				locMgr.RemoveUpdates(this);
			}
			locMgr = null;
		}

		#region ILocationListener implementation
		/// <summary>
		/// Called when the location has changed
		/// </summary>
		/// <param name="location">New Location.</param>
		void ILocationListener.OnLocationChanged(Location location)
		{
			Log.Debug(logTag, "OnLocationChanged - Service updated.");
			this.LocationChanged(this, new LocationChangedEventArgs(location));
		}

		/// <summary>
		/// Called when the user disables a location provider (GPS, etc.)
		/// </summary>
		void ILocationListener.OnProviderDisabled(string provider)
		{
			Log.Debug(logTag, "OnProviderDisabled: " + provider);
		}

		/// <summary>
		/// Called when the user enables a location provider (GPS, etc.)
		/// </summary>
		void ILocationListener.OnProviderEnabled(string provider)
		{
			Log.Debug(logTag, "OnProviderEnabled: " + provider);
		}

		/// <summary>
		/// Called when the state of a location provider has changed.
		/// </summary>
		void ILocationListener.OnStatusChanged(string provider, Availability status, Bundle extras)
		{
			Log.Debug(logTag, "OnStatusChanged: " + provider + " - " + status);
		}
		#endregion
	}
}

