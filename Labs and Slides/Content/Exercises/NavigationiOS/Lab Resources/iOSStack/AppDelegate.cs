using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace com.xamarin.university.mobilenav.ios.stack {

	public class Application {
		public static void Main (string[] args)
		{
			try {
				UIApplication.Main (args, null, "AppDelegate");
			} catch (Exception e) {
				Console.WriteLine (e.ToString ());
			}
		}
	}

	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		UINavigationController evolveNavigationController;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// We create a UINavigationController to be the 'root' of our app
			evolveNavigationController = new UINavigationController ();
			// then push our first table as the first view that's shown
			evolveNavigationController.PushViewController (new MenuTableViewController (), false);

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.MakeKeyAndVisible ();
			window.RootViewController = evolveNavigationController;
			return true;
		}
	}
}