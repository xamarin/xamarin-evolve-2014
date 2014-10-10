using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;

namespace Touch.iOS.ViewControllers
{
	public class GestureRecognizers : UIViewController
	{
		private RectangleF originalImageFrame = RectangleF.Empty;

		private UIImageView imgDragMe, imgTapMe;

		private UILabel lblGestureStatus;

		UITapGestureRecognizer tapGesture = null;

		public GestureRecognizers ()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Title = "Gesture Recognizers";

			View.BackgroundColor = UIColor.White;

			lblGestureStatus = new UILabel ();
			lblGestureStatus.Text = "Tap Location: ";
			lblGestureStatus.Frame = new RectangleF (0, 350, View.Frame.Width, 44.0f);

            imgTapMe = new UIImageView(UIImage.FromBundle("Images/DoubleTapMe.png"));
            imgTapMe.UserInteractionEnabled = true;
            imgTapMe.Frame = new RectangleF(184, 275, 56, 56);
            
            //TODO: Step 10 - Add a tap gesture recognizer
            //var tapGestureRecognizer = new UITapGestureRecognizer();
            //tapGestureRecognizer.AddTarget(
            //    (tg) =>
            //    {
            //        var currTapGesture = (tg as UITapGestureRecognizer);
            //        if (currTapGesture == null) return;
            //
            //        lblGestureStatus.Text = string.Format("Tap Location: @{0}", currTapGesture.LocationOfTouch(0, imgTapMe));
            //    });
            //tapGestureRecognizer.NumberOfTapsRequired = 2;
            //
            //imgTapMe.AddGestureRecognizer(tapGestureRecognizer);

         
			imgDragMe = new UIImageView(UIImage.FromBundle("Images/DragMe.png"));
			imgDragMe.UserInteractionEnabled = true;
			imgDragMe.Frame = new RectangleF (78, 275, 56, 56);

            //TODO: Step 11a - Add a pan gesture recognizer for drag motions
			//imgDragMe.AddGestureRecognizer(new UIPanGestureRecognizer(HandleDrag));

			originalImageFrame = imgDragMe.Frame;

			View.AddSubviews (new UIView[]{ lblGestureStatus, imgDragMe, imgTapMe });
		}

        //TODO: Step 11b - Provide the handler drag event
        //private void HandleDrag(UIPanGestureRecognizer recognizer)
        //{
        //    switch (recognizer.State)
        //    {
        //        case UIGestureRecognizerState.Began:
        //            // if it's just began, cache the location of the image
        //            originalImageFrame = imgDragMe.Frame;
        //            break;
        //
        //        case UIGestureRecognizerState.Possible:
        //        case UIGestureRecognizerState.Cancelled:
        //        case UIGestureRecognizerState.Failed:
        //            return;
        //    }
        //
        //    // move the shape by adding the offset to the object's frame
        //    PointF offset = recognizer.TranslationInView(imgDragMe);
        //    var newFrame = originalImageFrame;
        //    newFrame.Offset(offset.X, offset.Y);
        //    imgDragMe.Frame = newFrame;
        //}
	}
}

