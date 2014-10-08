using MonoTouch.UIKit;
using NavPatterns.Core;
using System.Drawing;

namespace TabbedDemo
{
	public class SponsorDetailViewController : UIViewController
	{
		private readonly Sponsor _sponsor;

		public SponsorDetailViewController (Sponsor sponsor)
		{
			_sponsor = sponsor;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.Title = "Speaker";
			this.View.BackgroundColor = UIColor.White;

			var sponsorName = new UILabel (new RectangleF (20, 84, 280, 47)) {
				Font = UIFont.SystemFontOfSize (16),
				Text = _sponsor.Name
			};

			this.View.Add (sponsorName);
		}
	}
}