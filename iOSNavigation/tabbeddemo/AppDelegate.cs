using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TabbedDemo
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		//TODO : Demo 2 - Step 01 - Declare the tab bar controller
//		EvolveTabController evolveTabBarController;

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			//TODO : Demo 2 - Step 02 - Set the root view controller
//			evolveTabBarController = new EvolveTabController ();
//			window.RootViewController = evolveTabBarController;
			
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}