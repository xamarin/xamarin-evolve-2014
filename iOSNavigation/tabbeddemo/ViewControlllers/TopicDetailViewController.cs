using MonoTouch.UIKit;
using NavPatterns.Core;
using System.Drawing;

namespace TabbedDemo
{
	public class TopicDetailViewController : UIViewController
	{
		public Topic Topic { get; set; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.Title = "Topic";
			this.View.BackgroundColor = UIColor.White;

			var topicName = new UILabel (new RectangleF (20, 84, 280, 47)) {
				Font = UIFont.SystemFontOfSize (32)
			};

			if (this.Topic != null) {
				topicName.Text = this.Topic.Name;
			}

			this.View.Add (topicName);
		}
	}	
}