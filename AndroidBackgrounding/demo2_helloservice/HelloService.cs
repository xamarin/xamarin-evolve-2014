using Android.App;
using Android.Content;
using Android.Widget;
using Android.Util;
using Android.OS;
using System.Threading.Tasks;
using System.Threading;

namespace Demo2HelloService
{
	[Service]
	public class HelloService : Service
	{
		const string logTag = "TheService";
		volatile bool isRunning;

		public HelloService()
		{
			Log.Debug(logTag, "Service constructed");
		}

		public override void OnCreate()
		{
			Log.Debug(logTag, "Service OnCreate");
			base.OnCreate();
		}

		public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
		{
			isRunning = true;
			Log.Debug(logTag, "Service OnStartCommand - {0}", startId);
			Toast.MakeText(this, "Service Started", ToastLength.Long).Show();

			Task.Run(() => 
			{
				for (long index = 1; index < 60 && isRunning; index++) 
				{
					Thread.Sleep(1000);
					Log.Debug(logTag, "[{0}] Service running - {1}", startId, index);
				}

				if (isRunning) 
				{
					StopSelf();
				}
			});

			// Continue running until stopped.
			return StartCommandResult.Sticky;
		}

		public override IBinder OnBind(Intent intent)
		{
			return null;
		}

		public override void OnDestroy()
		{
			isRunning = false;
	
			Log.Debug(logTag, "Service Destroyed.");
			Toast.MakeText(this, "Service Destroyed", ToastLength.Long).Show();
			base.OnDestroy();
		}
	}
}

