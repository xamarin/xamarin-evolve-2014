using MonoTouch.UIKit;

namespace MyTunes
{
	public class MyTunesViewController : UITableViewController
	{
		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();

			if (UIDevice.CurrentDevice.CheckSystemVersion(7,0)) {
				TableView.ContentInset = new UIEdgeInsets (20, 0, 0, 0);
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			TableView.Source = new ViewControllerSource<string>(TableView) {
				DataSource = new string[] { "One", "Two", "Three" },
			};
		}
	}

}

