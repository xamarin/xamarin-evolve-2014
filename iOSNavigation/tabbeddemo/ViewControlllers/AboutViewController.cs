using MonoTouch.UIKit;
using System.Drawing;

namespace TabbedDemo
{
	public class AboutViewController : UIViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.View.BackgroundColor = UIColor.White;

			var about = new UILabel (new RectangleF (20, 84, 280, 47)) {
				Font = UIFont.SystemFontOfSize (32),
				Text = "About Evolve"
			};

			this.View.Add (about);
		}
	}
}