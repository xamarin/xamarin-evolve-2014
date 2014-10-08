using MonoTouch.UIKit;
using NavPatterns.Core;
using System.Drawing;

namespace TabbedDemo
{
	public class SessionDetailViewController : UIViewController
	{
		public Session Session { get; set; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.Title = "Session";
			this.View.BackgroundColor = UIColor.White;

			var sessionTitle = new UILabel (new RectangleF (20, 84, 280, 47)) {
				Font = UIFont.SystemFontOfSize (16)
			};

			if (this.Session != null) {
				sessionTitle.Text = this.Session.Title;
			}

			this.View.Add (sessionTitle);
		}
	}	
}