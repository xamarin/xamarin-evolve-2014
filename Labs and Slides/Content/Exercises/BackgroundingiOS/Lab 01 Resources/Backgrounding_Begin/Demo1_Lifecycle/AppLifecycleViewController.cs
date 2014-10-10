using MonoTouch.UIKit;
using System.Drawing;
using System;

namespace Demo1_AppLifecycle
{
    public class AppLifecycleViewController : UIViewController
    {
		UILabel label;
        const float labelWidth = 200;
        const float labelHeight = 100;

        public AppLifecycleViewController()
        {
            Console.WriteLine("AppLifecycleViewController constructed");
        }

        public override void ViewDidLoad()
        {
            Console.WriteLine("ViewDidLoad called, View is ready to be shown.");

            base.ViewDidLoad();

            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            var frame = new RectangleF(
                View.Frame.Width / 2 - labelWidth / 2,
                View.Frame.Height / 2 - labelHeight / 2,
                labelWidth,
                labelHeight);

			label = new UILabel(frame) {
                Text = "App Lifecycle Demo",
                Font = UIFont.FromName("Helvetica-Bold", 20f),
                AdjustsFontSizeToFitWidth = true
            };

            // TODO: Demo1 - Step 1 - Add app-level notification
//            UIApplication.Notifications.ObserveWillEnterForeground ((sender, args) => {
//                // We can use a notification to let us know when the app has entered the foreground
//                // from the background, and update the text in the View
//                // this causes a flicker, but we will use it for demo purposes
//            	label.Text = "Welcome back!";
//                Console.WriteLine ("ObserveWillEnterForeground called.");
//            });

            View.AddSubview(label);
        }
    }
}

