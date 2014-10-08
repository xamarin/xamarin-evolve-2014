using MonoTouch.UIKit;
using NavPatterns.Core;
using System.Drawing;

namespace TabbedDemo
{
	public class RoomDetailViewController : UIViewController
	{
		public Room Room { get; set; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.Title = "Room";
			this.View.BackgroundColor = UIColor.White;

			var roomName = new UILabel (new RectangleF (20, 84, 280, 47)) {
				Font = UIFont.SystemFontOfSize (32)
			};

			if (this.Room != null) {
				roomName.Text = this.Room.Name;
			}

			this.View.Add (roomName);
		}
	}
}