using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Xamarin.WebServicesAsync.Soap.iOS.ViewControllers
{
	public class SoapTableViewControllerCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("SoapTableViewControllerCell");

		public SoapTableViewControllerCell () : base (UITableViewCellStyle.Value1, Key)
		{
			// TODO: add subviews to the ContentView, set various colors, etc.
			TextLabel.Text = "TextLabel";
		}
	}
}

