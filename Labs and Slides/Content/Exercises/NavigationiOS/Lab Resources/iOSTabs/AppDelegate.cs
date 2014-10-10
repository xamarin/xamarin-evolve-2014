using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace com.xamarin.university.mobilenav.ios.tabs {

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
		EvolveTabBarController evolveTabController;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// We create a UITabBarController to be the 'root' of our app
			evolveTabController = new EvolveTabBarController ();

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.MakeKeyAndVisible ();
			window.RootViewController = evolveTabController;
			return true;
		}
	}
}