using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Linq;
using NavPatterns.Core;

namespace StackNavDemo
{
	partial class SessionsViewController : UITableViewController
	{
		private List<Session> _sessions;
		public Topic Topic { get; set; }
		public Speaker Speaker { get; set; }

		public SessionsViewController (IntPtr handle) : base (handle) { }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

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

			return cell;
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			var selectedRow = this.TableView.IndexPathForSelectedRow;
			var selectedSession = _sessions [selectedRow.Row];

			var sessionDetailVC = (SessionDetailViewController)segue.DestinationViewController;
			sessionDetailVC.Session = selectedSession;

			base.PrepareForSegue (segue, sender);
		}
	}
}