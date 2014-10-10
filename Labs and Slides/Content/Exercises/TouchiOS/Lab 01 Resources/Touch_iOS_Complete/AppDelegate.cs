using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Touch.iOS.ViewControllers;

namespace Touch.iOS
{

    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        protected UINavigationController mainNavController;
        protected UIWindow window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // create our window
            window = new UIWindow(UIScreen.MainScreen.Bounds);
            window.MakeKeyAndVisible();

            // instantiate our main navigatin controller and add it's view to the window
            mainNavController = new UINavigationController();

			mainNavController.PushViewController(new Home(), false);

            window.RootViewController = mainNavController;

            return true;
        }
    }
}
