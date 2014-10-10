using System;
using MonoTouch.UIKit;
using Touch.iOS.GestureRecognizer;
using System.Drawing;

namespace Touch.iOS.ViewControllers
{
    public class CustomCheckmarkGestureRecognizer : UIViewController
    {
        protected bool isChecked = false;
        private CheckmarkGestureRecognizer checkmarkGesture;

        private UIImageView imgCheckmark;

        public CustomCheckmarkGestureRecognizer()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Custom Gesture Recognizer";

            View.BackgroundColor = UIColor.White;

            imgCheckmark = new UIImageView(UIImage.FromBundle("Images/CheckBox_Start.png"));
            imgCheckmark.Frame = new RectangleF(85, 150, 150, 150);

            View.Add(imgCheckmark);

            WireUpCheckmarkGestureRecognizer();
        }

        //TODO: Step 13 - Listen for the Checkmark gesture
        protected void WireUpCheckmarkGestureRecognizer()
        {
            // create the recognizer
            checkmarkGesture = new CheckmarkGestureRecognizer();

            // wire up the event handler
            checkmarkGesture.AddTarget(() =>
            {
                //TODO: Step 14 - Check the state of the gesture
                if (checkmarkGesture.State != UIGestureRecognizerState.Recognized ||
                    checkmarkGesture.State != UIGestureRecognizerState.Ended)
                    return;

                BeginInvokeOnMainThread(() =>
                {
                    imgCheckmark.Image = UIImage.FromBundle(
                        isChecked
                            ? "Images/CheckBox_Checked.png"
                            : "Images/CheckBox_Unchecked.png");
                });

                isChecked = !isChecked;
            });

            //TODO: Step 15 - Add the gesture to the view
            View.AddGestureRecognizer(checkmarkGesture);
        }
    }
}

