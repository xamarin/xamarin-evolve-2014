using MonoTouch.UIKit;
using NavPatterns.Core;
using System.Drawing;

namespace TabbedDemo
{
	public class SpeakerDetailViewController : UIViewController
	{
		public Speaker Speaker { get; set; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.Title = "Speaker";
			this.View.BackgroundColor = UIColor.White;

			var speakerName = new UILabel (new RectangleF (20, 84, 280, 47)) {
				Font = UIFont.SystemFontOfSize (16)
			};

			if (this.Speaker != null) {
				speakerName.Text = this.Speaker.Name;
			}

			this.View.Add (speakerName);
		}
	}
}