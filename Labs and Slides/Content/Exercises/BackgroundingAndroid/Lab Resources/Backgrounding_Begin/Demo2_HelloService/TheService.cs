using Android.App;
using Android.Content;
using Android.Widget;
using Android.Util;
using Android.OS;
using System.Threading.Tasks;
using System.Threading;

namespace Demo2HelloService
{
	// TODO: Demo2 - Step 1 - Create a simple service
/* REMOVE COMMENT HERE **
	[Service]
	public class TheService : Service
	{
		const string logTag = "TheService";
		volatile bool isRunning;

		public TheService()
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

			Task.Run(() => {
				for (long index = 1 ;; index++) {

				// TODO: Demo2 - Step 3a - Stop the service when work is complete
//				for (long index = 1; index < 15; index++) {
				
				// TODO: Demo2 - Step 4a - Stop the service when requested
//				for (long index = 1; isRunning && index < 15; index++) {
				
					Thread.Sleep(1000);
					Log.Debug(logTag, "[{0}] Service running - {1}", startId, index);
				}

				Log.Debug(logTag, "Service {0} stopping - {1}", startId,
					isRunning ? "Work complete" : "OnDestroy");

				if (isRunning) {
					// TODO: Demo2 - Step 3b - Tell Android we are done.
//					StopSelf();
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
** REMOVE ENDING COMMENT MARKER */
}

