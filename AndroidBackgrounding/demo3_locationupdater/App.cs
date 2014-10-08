using System;
using Android.App;
using Android.Content;
using System.Threading.Tasks;

namespace Demo3LocationUpdater
{
	public class App
	{
		static Lazy<App> app = new Lazy<App>(() => new App());

		public static App Current
		{
			get { return app.Value; }
		}

		// TODO: Demo3 - Step 4 - Provide access to bound service
		LocationServiceConnection lsConnection;

		public MyLocationService LocationService
		{
			get 
			{ 
				return lsConnection.Service; 
			}
		}

		public event EventHandler<ServiceConnectionEventArgs> ConnectionChanged = delegate{};

		private App()
		{
			Task.Run(() => {
				var context = Application.Context;

				// Start the service - since it's in our process.
				var intent = new Intent(context, typeof(MyLocationService));
				context.StartService(intent);

				// TODO: Demo3 - Step 5 - Bind to the service
				#region Bind the Service
				lsConnection = new LocationServiceConnection();
				lsConnection.ConnectionChanged += (s,e) => ConnectionChanged(this, e);
				context.BindService(intent, lsConnection, Bind.AutoCreate);
				#endregion
			});
		}
	}
}

