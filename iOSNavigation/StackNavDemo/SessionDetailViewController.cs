using System;
using MonoTouch.UIKit;
using NavPatterns.Core;
using MonoTouch.Foundation;
using System.Linq;

namespace StackNavDemo
{
	partial class SessionDetailViewController : UIViewController
	{
		public Session Session { get; set; }

		public SessionDetailViewController (IntPtr handle) : base (handle) { }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (this.Session != null) {
				this.sessionTitle.Text = this.Session.Title;
				this.speakerName.SetTitle (this.Session.SpeakerName, UIControlState.Normal);
			}
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			var speaker = Repository.GetSpeakers ().FirstOrDefault (x => x.Name == this.Session.SpeakerName);

			var speakerVC = (SpeakerDetailViewController)segue.DestinationViewController;
			speakerVC.Speaker = speaker;

			base.PrepareForSegue (segue, sender);
		}
	}
}