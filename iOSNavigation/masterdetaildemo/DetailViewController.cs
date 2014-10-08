using MonoTouch.UIKit;
using System.Drawing;
using NavPatterns.Core;

namespace MasterDetailDemo
{
	public class DetailViewController : UIViewController
	{
		private UILabel titleLabel;
		private UILabel speakerNameLabel;
		private UIToolbar toolbar;

		//TODO - Demo 3 - Step 09 - Pass session data to detail
//		public void Update (Session session)
//		{
//			titleLabel.Text = session.Title;
//			speakerNameLabel.Text = session.SpeakerName;
//
//			//TODO - Demo 3 - Step 19 - Dismiss popover when item selected
// //			if (Popover != null) {
// //				Popover.Dismiss (true);
// //			}
//		}

		//TODO - Demo 3 - Step 11 - Add toolbar for popover button
//		void AddToolbar ()
//		{
//			toolbar = new UIToolbar (new RectangleF (x: 0, y: 20, width: View.Frame.Width, height: 40));
//			toolbar.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
//			toolbar.Delegate = new NavBarDelegate ();
//			View.AddSubview (toolbar);
//		}

		public DetailViewController () : base ()
		{
			AddDetailLabel ();

			//TODO - Demo 3 - Step 12 - Add toolbar
//			AddToolbar ();
		}

		//TODO - Demo 3 - Step 13 - Add button
//		public void AddContentsButton (UIBarButtonItem button)
//		{
//			button.Title = "Sessions";
//			toolbar.SetItems (new UIBarButtonItem[] { button }, false);
//		}
//		// Remove button
//		public void RemoveContentsButton ()
//		{
//			toolbar.SetItems (new UIBarButtonItem[0], false);
//		}

		//TODO - Demo 3 - Step 16
//		public UIPopoverController Popover { get; set; }


		#region Other Methods

		void AddDetailLabel ()
		{
			View.BackgroundColor = UIColor.White;

			titleLabel = new UILabel (new RectangleF (x: 100, y: 100, width: 450, height: 50));
			titleLabel.Font = UIFont.SystemFontOfSize (20);

			speakerNameLabel = new UILabel (new RectangleF (x: 100, y: 200, width: 450, height: 50));
			speakerNameLabel.Font = UIFont.SystemFontOfSize (20);

			View.AddSubview (titleLabel);
			View.AddSubview (speakerNameLabel);
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}

		#endregion
	}
}