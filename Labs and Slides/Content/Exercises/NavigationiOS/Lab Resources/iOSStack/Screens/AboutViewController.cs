using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace com.xamarin.university.mobilenav.ios.stack {
	public class AboutViewController : UIViewController {

		UIWebView webView;

		public AboutViewController ()
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// iOS7: Keep content from hiding under navigation bar.
			if (UIDevice.CurrentDevice.CheckSystemVersion (7, 0)) {
				EdgesForExtendedLayout = UIRectEdge.None;
			}

			webView = new UIWebView()
			{
				ScalesPageToFit = false,
			};

			webView.Frame = new RectangleF (0, 0, this.View.Bounds.Width, this.View.Bounds.Height);
			// Add the table view as a subview
			View.AddSubview(webView);

			string homePageUrl = NSBundle.MainBundle.BundlePath + "/About.html";

			 webView.LoadRequest (new NSUrlRequest (new NSUrl (homePageUrl, false)));
		}
	}
}