using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Util;

namespace Demo2HelloService
{
	[Activity(Label = "Hello Service", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		const string logTag = "MainActivity";

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			LinearLayout rootLayout = new LinearLayout(this) {
				Orientation = Orientation.Vertical
			};

	
			#region Start & Stop the Service
			Button startButton = new Button(this) {
				Text = "Start the Service",
				LayoutParameters = new LinearLayout.LayoutParams(
					ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent),
			};
			rootLayout.AddView(startButton);

			startButton.Click += delegate {
				StartService(new Intent(this, typeof(HelloService)));
			};

			// TODO: Demo2 - Step 4a - Request the service stop
			Button stopButton = new Button(this) 
			{
				Text = "Stop the Service",
				LayoutParameters = new LinearLayout.LayoutParams(
					ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent),
			};
			rootLayout.AddView(stopButton);

			stopButton.Click += delegate {
				StopService(new Intent(this, typeof(HelloService)));
			};
			#endregion

			SetContentView(rootLayout);
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


