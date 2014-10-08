using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.AVFoundation;
using System.Threading.Tasks;
using MonoTouch.CoreMotion;

namespace iOSBackgrounding
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			Console.WriteLine ("FinishedLaunching() - becoming active");
			return true;
		}

		public override void OnActivated (UIApplication application)
		{
			Console.WriteLine ("OnActivated() - app is the acive one");
		}

		// This method is invoked when the application is about to move from active to inactive state.
		// OpenGL applications should use this method to pause.
		public override void OnResignActivation (UIApplication application)
		{
			Console.WriteLine ("OnResignActiviation() - moving to inactive state");
		}

		// This method should be used to release shared resources and it should store the application state.
		// If your application supports background exection this method is called instead of WillTerminate
		// when the user quits.
		public override void DidEnterBackground (UIApplication application)
		{
			Console.WriteLine ("DidEnterBackground() - entered background state");
		}

		// This method is called as part of the transiton from background to active state.
		public override void WillEnterForeground (UIApplication application)
		{
			Console.WriteLine ("WillEnterForeground() - preparing to become the active app");
		}

		// This method is called when the application is about to terminate. Save data, if needed.
		public override void WillTerminate (UIApplication application)
		{
			Console.WriteLine ("WillTerminate() - app is getting destroyed");
		}
	}
}

