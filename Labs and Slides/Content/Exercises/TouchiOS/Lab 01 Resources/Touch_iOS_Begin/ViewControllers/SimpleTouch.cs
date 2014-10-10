using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;

namespace Touch.iOS.ViewControllers
{
    public class SimpleTouch : UIViewController
    {
        protected bool imageHighlighted = false;
        protected bool touchStartedInside;

        UIImageView imgDragMe, imgTouchMe, imgTapMe;
        UILabel lblNumberOfFingers, lblTouchStatus;

        public SimpleTouch()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Simple Touch";

            View.BackgroundColor = UIColor.White;

            //TODO: Step 1 - Ensure we can have user interaction and multiple touches enabled
            //View.UserInteractionEnabled = true;
            //View.MultipleTouchEnabled = true;

            lblNumberOfFingers = new UILabel();
            lblNumberOfFingers.Text = "Number of Fingers: 0";
            lblNumberOfFingers.Frame = new RectangleF(0, 400, View.Frame.Width, 44.0f);

            lblTouchStatus = new UILabel();
            lblTouchStatus.Text = "Touch Status:";
            lblTouchStatus.Frame = new RectangleF(0, 100, View.Frame.Width, 44.0f);

            imgTouchMe = new UIImageView(UIImage.FromBundle("Images/TouchMe.png"));
            imgTouchMe.Frame = new RectangleF(250, 96, 56, 56);

            imgDragMe = new UIImageView(UIImage.FromBundle("Images/DragMe.png"));
            imgDragMe.Frame = new RectangleF(78, 275, 56, 56);

            imgTapMe = new UIImageView(UIImage.FromBundle("Images/DoubleTapMe.png"));
            imgTapMe.Frame = new RectangleF(184, 275, 56, 56);

            View.AddSubviews(new UIView[] { lblNumberOfFingers, lblTouchStatus, imgTouchMe, imgDragMe, imgTapMe });
        }

        //TODO: Step 2 - Subscribe to touches began events
        //public override void TouchesBegan(NSSet touches, UIEvent evt)
        //{
        //    base.TouchesBegan(touches, evt);
        //
        //    // we can get the number of fingers from the touch count, but Multitouch must be enabled
        //    lblNumberOfFingers.Text = string.Format("Number of Fingers: {0}", touches.Count);
        //
        //    // get the touch
        //    var touch = touches.AnyObject as UITouch;
        //
        //    if (touch == null) return;
        //
        //    Console.WriteLine("screen touched");
        //
        //    //TODO: Step 3 - Check if touch was on a particular view
        //    //if (imgTouchMe.Frame.Contains(touch.LocationInView(View)))
        //    //    lblTouchStatus.Text = "Touch Status: Touches Began";
        //
        //    //TODO: Step 4 - Detect multiple taps
        //    //if (touch.TapCount == 2 && imgTapMe.Frame.Contains(touch.LocationInView(View)))
        //    //{
        //    //    imgTapMe.Image = UIImage.FromBundle(
        //    //        imageHighlighted
        //    //            ? "Images/DoubleTapMe.png"
        //    //            : "Images/DoubleTapMe_Highlighted.png");
        //    //
        //    //    imageHighlighted = !imageHighlighted;
        //    //}
        //
        //    //TODO: Step 5 - Start recording a drag event
        //    //if (imgDragMe.Frame.Contains(touch.LocationInView(View)))
        //    //    touchStartedInside = true;
        //
        //}

        //TODO: Step 6 - Listen for cancelled touches
        //public override void TouchesCancelled(NSSet touches, UIEvent evt)
        //{
        //    base.TouchesCancelled(touches, evt);
        //
        //    // reset our tracking flags
        //    touchStartedInside = false;
        //}

        //TODO: Step 7 - Listen for moved touches
        //public override void TouchesMoved(NSSet touches, UIEvent evt)
        //{
        //    base.TouchesMoved(touches, evt);
        //
        //    var touch = touches.AnyObject as UITouch;
        //
        //    if (touch == null) return;
        //
        //    if (imgTouchMe.Frame.Contains(touch.LocationInView(View)))
        //        lblTouchStatus.Text = "Touch Status: Touches Moved";
        //
        //    ////TODO: Step 8 - If we started a drag event, update the frame for the image
        //    //if (!touchStartedInside) return;
        //    //
        //    //// move the shape
        //    //float offsetX = touch.PreviousLocationInView(View).X - touch.LocationInView(View).X;
        //    //float offsetY = touch.PreviousLocationInView(View).Y - touch.LocationInView(View).Y;
        //    //imgDragMe.Frame = new RectangleF(new PointF(imgDragMe.Frame.X - offsetX, imgDragMe.Frame.Y - offsetY), imgDragMe.Frame.Size);
        //}

        //TODO: Step 9 - Listen for ended touches
        //public override void TouchesEnded(NSSet touches, UIEvent evt)
        //{
        //    base.TouchesEnded(touches, evt);
        //
        //    var touch = touches.AnyObject as UITouch;
        //
        //    if (touch == null) return;
        //
        //    if (imgTouchMe.Frame.Contains(touch.LocationInView(View)))
        //        lblTouchStatus.Text = "Touch Status: Touches Ended";
        //
        //    // reset our tracking flags
        //    touchStartedInside = false;
        //}


    }
}

