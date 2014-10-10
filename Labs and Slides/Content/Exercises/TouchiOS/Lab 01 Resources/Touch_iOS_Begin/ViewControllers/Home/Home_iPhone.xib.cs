using Touch.iOS.ViewControllers.GestureRecognizers;

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Touch.iOS.ViewControllers;

namespace Touch.iOS.ViewControllers.Home
{

    public partial class Home_iPhone : UIViewController
    {
        private CustomCheckmarkGestureRecognizer_iPhone customGestureScreen;
        private GestureRecognizers_iPhone gestureScreen;

        // The IntPtr and initWithCoder constructors are required for items that need 
        // to be able to be created from a xib rather than from managed code

        public Home_iPhone(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }

        [Export("initWithCoder:")]
        public Home_iPhone(NSCoder coder)
            : base(coder)
        {
            Initialize();
        }

        public Home_iPhone()
            : base("Home_iPhone", null)
        {
            Initialize();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Working with Touch";

            btnTouch.TouchUpInside += (s, e) =>{
				NavigationController.PushViewController(new SimpleTouch(), true);
            };

            btnGestureRecognizers.TouchUpInside += (s, e) =>{
                if (gestureScreen == null)
                {
                    gestureScreen = new GestureRecognizers_iPhone();
                }
                NavigationController.PushViewController(gestureScreen, true);
            };

            btnCustomGestureRecognizer.TouchUpInside += (s, e) =>{
                if (customGestureScreen == null)
                {
                    customGestureScreen = new CustomCheckmarkGestureRecognizer_iPhone();
                }
                NavigationController.PushViewController(customGestureScreen, true);
            };
        }

        private void Initialize()
        {
        }
    }
}
