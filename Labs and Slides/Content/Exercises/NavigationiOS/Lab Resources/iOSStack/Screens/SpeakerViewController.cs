using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Evolve.Core;

namespace com.xamarin.university.mobilenav.ios.stack
{
	public class SpeakerViewController : UIViewController
	{
		Speaker speaker;
		public SpeakerViewController (Speaker showSpeaker)
		{
			speaker = showSpeaker;
		}

		UILabel name, company;
		UIImageView avatar;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// iOS7: Keep content from hiding under navigation bar.
			if (UIDevice.CurrentDevice.CheckSystemVersion (7, 0)) {
				EdgesForExtendedLayout = UIRectEdge.None;
			}

			Title = speaker.Name;
			View.BackgroundColor = UIColor.White;

			name = new UILabel (new RectangleF(10, 10, 200, 30));
			name.Font = UIFont.BoldSystemFontOfSize (20f);
			company = new UILabel (new RectangleF( 10, 40, 200, 30));
			avatar = new UIImageView (new RectangleF (230, 10, 75, 75));

			View.Add (name);
			View.Add (company);
			View.Add (avatar);

			name.Text = speaker.Name;
			company.Text = speaker.Company;
			avatar.Image = UIImage.FromBundle (speaker.HeadshotUrl);
		}
	}
}

