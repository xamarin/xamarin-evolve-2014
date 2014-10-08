using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Linq;

namespace StackNavDemo
{
	partial class MenuTableViewController : UITableViewController
	{
		private readonly string[] _menuItems;
		private const string cellId = "menuCell";

		public MenuTableViewController (IntPtr handle) : base (handle)
		{
			_menuItems = new [] { "Sessions", "Speakers", "Topics" };
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _menuItems.Count ();
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellId);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellId);
			}

			var menuItem = _menuItems [indexPath.Row];
			cell.TextLabel.Text = menuItem;

			return cell;
		}
			
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var menuItem = _menuItems [indexPath.Row];
			UIStoryboard board = UIStoryboard.FromName ("MainStoryboard_iPhone", null);
			UIViewController nextViewController = null;

			if (menuItem == "Sessions") {
				nextViewController = (UIViewController)board.InstantiateViewController ("sessionsVC");
			} else if (menuItem == "Speakers") {
				nextViewController = (UIViewController)board.InstantiateViewController ("speakersVC");
			} else if (menuItem == "Topics") {
				nextViewController = (UIViewController)board.InstantiateViewController ("topicsVC");
			} 

			if (nextViewController != null) {
				this.NavigationController.PushViewController (nextViewController, animated:true);
			}
		}
	}
}