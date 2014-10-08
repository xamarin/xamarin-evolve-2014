using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using NavPatterns.Core;

namespace StackNavDemo
{
	partial class SpeakerDetailViewController : UIViewController
	{
		public Speaker Speaker { get; set; }

		public SpeakerDetailViewController (IntPtr handle) : base (handle) { }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (this.Speaker != null) {
				this.speakerName.Text = this.Speaker.Name;
			}
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			var sessionsVC = (SessionsViewController)segue.DestinationViewController;
			sessionsVC.Speaker = Speaker;

			base.PrepareForSegue (segue, sender);
		}
	}
}