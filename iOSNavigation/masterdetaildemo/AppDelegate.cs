using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MasterDetailDemo
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		//TODO - Demo 3 - Step 01 - Declare the split view controller
//		EvolveSplitViewController evolveSplitViewController;

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			//TODO - Demo 3 - Step 02 - Set the root view controller
//			evolveSplitViewController = new EvolveSplitViewController();
//			window.RootViewController = evolveSplitViewController;

			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}