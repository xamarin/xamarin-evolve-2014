using Android.OS;

namespace Demo3LocationUpdater
{
	// TODO: Demo3 - Step 1 - Create a binder class
	public class LocationServiceBinder : Binder
	{
		public LocationService Service { get; private set; }

		public LocationServiceBinder (LocationService service)
		{
			this.Service = service;
		}
	}
}

