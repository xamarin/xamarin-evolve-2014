using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Linq;
using NavPatterns.Core;

namespace TabbedDemo
{
	partial class RoomsViewController : UITableViewController
	{
		private List<Room> _rooms;

		public override void ViewDidLoad ()
		{
			this.Title = "Rooms";
			_rooms = Repository.GetRooms ();
			base.ViewDidLoad ();
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _rooms.Count ();
		}

		private const string cellId = "roomsCell";
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellId);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellId);
			}

			var room = _rooms [indexPath.Row];
			cell.TextLabel.Text = room.Name;
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var selectedRow = tableView.IndexPathForSelectedRow;
			var selectedRoom = _rooms [selectedRow.Row];

			var roomDetailVC = new RoomDetailViewController ();
			roomDetailVC.Room = selectedRoom;
			this.NavigationController.PushViewController (roomDetailVC, animated:true);
		}
	}
	
}