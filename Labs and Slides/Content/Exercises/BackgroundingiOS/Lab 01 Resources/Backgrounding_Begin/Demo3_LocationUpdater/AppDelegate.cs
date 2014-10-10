using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Demo3LocationUpdater
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        public static LocationManager Manager = null;

        // class-level declarations
        public override UIWindow Window
        {
            get;
            set;
        }

        public override void FinishedLaunching(UIApplication application)
        {
            // TODO: Demo3 - Step 1 - begin generating location updates
//            Manager = new LocationManager();
//            Manager.StartLocationUpdates();
        }

        public override void WillEnterForeground (UIApplication application)
        {
            Console.WriteLine ("App will enter foreground");
        }

        // Runs when the activation transitions from running in the background to
        // being the foreground application.
        // Also gets hit on app startup
        public override void OnActivated (UIApplication application)
        {
            Console.WriteLine ("App is becoming active");
        }

        public override void OnResignActivation (UIApplication application)
        {
            Console.WriteLine ("App moving to inactive state.");
        }

        public override void DidEnterBackground (UIApplication application)
        {
            Console.WriteLine ("App entering background state.");
            Console.WriteLine ("Now receiving location updates in the background");
        } 

    }
}

