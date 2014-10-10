using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Touch.iOS.ViewControllers.GestureRecognizers
{

    public partial class GestureRecognizers_iPhone : UIViewController
    {
        private RectangleF originalImageFrame = RectangleF.Empty;

        // The IntPtr and initWithCoder constructors are required for items that need 
        // to be able to be created from a xib rather than from managed code

        public GestureRecognizers_iPhone(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }

        [Export("initWithCoder:")]
        public GestureRecognizers_iPhone(NSCoder coder)
            : base(coder)
        {
            Initialize();
        }

        public GestureRecognizers_iPhone()
            : base("GestureRecognizers_iPhone", null)
        {
            Initialize();
        }



        private void Initialize()
        {
        }
    }
}
