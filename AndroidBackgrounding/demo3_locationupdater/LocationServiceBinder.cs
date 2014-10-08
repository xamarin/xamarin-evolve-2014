using Android.OS;

namespace Demo3LocationUpdater
{
	// TODO: Demo3 - Step 1 - Create a binder class
	#region Create the Binder Class
	public class LocationServiceBinder : Binder
	{
		public MyLocationService Service { get; private set; }

		public LocationServiceBinder (MyLocationService service)
		{
			this.Service = service;
		}
	}
	#endregion
}

