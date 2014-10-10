using Android.App;
using Android.OS;
using Android.Util;
using Android.Widget;
using System.Threading.Tasks;
using System.Threading;

namespace Demo1Lifecycle
{
	[Activity(Label = "App Lifecycle", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		const string logTag = "MainActivity";

		protected override void OnCreate(Bundle bundle)
		{
			Log.Debug(logTag, "OnCreate called, View being created");
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			Button startButton = FindViewById<Button>(Resource.Id.startButton);
			startButton.Click += (s, e) => StartActivity(typeof(MemoryEaterActivity));
		}

		protected override void OnStart()
		{
			Log.Debug (logTag, "OnStart called, App is Active");
			base.OnStart();

			// TODO: Demo1 – Step 1 – Start a background task
//			Task.Run(() => {
//
//				for ( ;; )	{
//					Log.Debug(logTag, "Bad thread running..");
//					Thread.Sleep(500);
//				}
//			});
		}

		protected override void OnResume()
		{
			Log.Debug (logTag, "OnResume called, app is ready to interact with the user");
			base.OnResume();
		}

		protected override void OnPause()
		{
			Log.Debug (logTag, "OnPause called, App is moving to background");
			base.OnPause();
		}

		protected override void OnStop()
		{
			Log.Debug (logTag, "OnStop called, App is in the background");
			base.OnStop();
		}

		protected override void OnRestart()
		{
			Log.Debug (logTag, "OnRestart called, app is returning from background");
			base.OnRestart();
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			Log.Debug (logTag, "OnDestroy called, App is Terminating");
		}
	}
}


