using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using NavPatterns.Core;

namespace MasterDetailDemo
{
	public class MasterViewController : UITableViewController
	{
		//TODO - Demo 3 - Step 06
//		public event EventHandler<MenuSelectedEventArgs> RowClicked;

		//TODO - Demo 3 - Step 07
//		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
//		{
//			var session = _sessions [indexPath.Row];
//			RowClicked (this, new MenuSelectedEventArgs (session));
//		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.TableView.ContentInset = new UIEdgeInsets (20, 0, 0, 0);

			//TODO - Demo 3 - Step 10
//			RowClicked (this, new MenuSelectedEventArgs (_sessions.First ()));
		}

		#region Other Methods
		private const string cellId = "sessionCell";
		private List<Session> _sessions;

		public MasterViewController ()
		{
			_sessions = Repository.GetSessions ();
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _sessions.Count ();
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellId);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellId);
			}

			var session = _sessions [indexPath.Row];

			cell.TextLabel.Text = session.Title;

			return cell;
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}

		#endregion
	}
}