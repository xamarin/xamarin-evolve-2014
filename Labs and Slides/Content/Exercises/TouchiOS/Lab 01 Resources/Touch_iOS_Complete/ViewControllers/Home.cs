using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace Touch.iOS.ViewControllers
{
	public class Home : UIViewController
	{
		public Home ()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Title = "Working with Touch";

			View.BackgroundColor = UIColor.White;

			var btnTouch = UIButton.FromType(UIButtonType.RoundedRect);
			btnTouch.SetTitle ("Simple Touch", UIControlState.Normal);
			btnTouch.Frame = new RectangleF (0, 100, View.Frame.Width, 44.0f);

			btnTouch.TouchUpInside += (s, e) => 
                NavigationController.PushViewController(new SimpleTouch(), true);

			var btnGestureRecognizers = UIButton.FromType(UIButtonType.RoundedRect);
			btnGestureRecognizers.SetTitle ("Gesture Recognizer", UIControlState.Normal);
			btnGestureRecognizers.Frame = new RectangleF (0, 150, View.Frame.Width, 44.0f);
			btnGestureRecognizers.TouchUpInside += (s, e) => 
                NavigationController.PushViewController(new GestureRecognizers(), true);

			var btnCustomGestureRecognizer = UIButton.FromType(UIButtonType.RoundedRect);
			btnCustomGestureRecognizer.SetTitle ("Custom Gesture Recognizer", UIControlState.Normal);
			btnCustomGestureRecognizer.Frame = new RectangleF (0, 200, View.Frame.Width, 44.0f);
			btnCustomGestureRecognizer.TouchUpInside += (s, e) => 
                NavigationController.PushViewController(new CustomCheckmarkGestureRecognizer(), true);

			View.AddSubviews (new UIView[]{ btnTouch, btnGestureRecognizers, btnCustomGestureRecognizer });
		}
	}
}

