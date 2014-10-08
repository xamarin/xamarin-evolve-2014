using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using NavPatterns.Core;

namespace StackNavDemo
{
	partial class TopicsViewController : UITableViewController
	{
		private readonly List<Topic> _topics;
		public TopicsViewController (IntPtr handle) : base (handle)
		{
			_topics = Repository.GetTopics ();
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _topics.Count ();
		}

		private const string cellId = "topicsCell";
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellId);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellId);
			}

			var topic = _topics [indexPath.Row];
			cell.TextLabel.Text = topic.Name;

			return cell;
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			var selectedRow = this.TableView.IndexPathForSelectedRow;
			var selectedTopic = _topics [selectedRow.Row];

			var sessionsVC = (SessionsViewController)segue.DestinationViewController;
			sessionsVC.Topic = selectedTopic;

			base.PrepareForSegue (segue, sender);
		}
	}
}
