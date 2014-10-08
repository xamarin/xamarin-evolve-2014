using MonoTouch.UIKit;
using System.Collections.Generic;
using NavPatterns.Core;
using MonoTouch.Foundation;
using System.Linq;

namespace TabbedDemo
{
	partial class SessionsViewController : UITableViewController
	{
		private List<Session> _sessions;

		public Topic Topic { get; set; }

		public Speaker Speaker { get; set; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.Title = "Sessions";

			_sessions = Repository.GetSessions ();

			if (this.Topic != null) {
				_sessions = _sessions.Where (x => x.Topic == this.Topic.Name).ToList ();
			} else if (this.Speaker != null) {
				_sessions = _sessions.Where (x => x.SpeakerName == this.Speaker.Name).ToList ();
			}
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _sessions.Count ();
		}

		private const string cellId = "sessionsCell";

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellId);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellId);
			}

			var session = _sessions [indexPath.Row];
			cell.TextLabel.Text = session.Title;
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var selectedRow = tableView.IndexPathForSelectedRow;
			var selectedSession = _sessions [selectedRow.Row];

			var sessionDetailVC = new SessionDetailViewController () {
				Session = selectedSession
			};

			this.NavigationController.PushViewController (sessionDetailVC, animated: true);
		}
	}
}