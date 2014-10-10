using Android.Content;
using Android.OS;
using System;

namespace Demo3LocationUpdater
{
	public class ServiceConnectionEventArgs : EventArgs
	{
		public bool IsConnected { get; private set;}
		public ServiceConnectionEventArgs(bool isConnected)
		{
			IsConnected = isConnected;
		}
	}

	// TODO: Demo3 - Step 3 - Create an IServiceConnection to locate and bind to the service
	public class LocationServiceConnection : Java.Lang.Object, IServiceConnection
	{
		IBinder binder;

		public event EventHandler<ServiceConnectionEventArgs> ConnectionChanged = delegate{};

		public LocationService Service
		{
			get	{
				LocationServiceBinder lBinder = binder as LocationServiceBinder;
				return lBinder != null ? lBinder.Service : null;
			}
		}

		/// <summary>
		/// This is called when the connection with the service has been established.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="service">Service.</param>
		public void OnServiceConnected(ComponentName name, IBinder service)
		{
			LocationServiceBinder serviceBinder = service as LocationServiceBinder;

			if (serviceBinder != null) {
				this.binder = serviceBinder;
				ConnectionChanged(this, new ServiceConnectionEventArgs(true));
			}
		}

		/// <summary>
		/// This is called when the connected with the service has been
		/// unexpectedly disconnected.
		/// </summary>
		/// <param name="name">Name.</param>
		public void OnServiceDisconnected(ComponentName name)
		{
			ConnectionChanged(this, new ServiceConnectionEventArgs(false));
			this.binder = null;
		}
	}
}

