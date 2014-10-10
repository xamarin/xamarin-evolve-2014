using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MyTunes
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		UIViewController controller;

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			window = new UIWindow(UIScreen.MainScreen.Bounds);

			controller = new MyTunesViewController();
			window.RootViewController = controller;
			window.MakeKeyAndVisible();

			return true;
		}

	}
}

