using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Linq;
using NavPatterns.Core;

namespace TabbedDemo
{
	partial class TopicsViewController : UITableViewController
	{
		private List<Topic> _topics;

		public override void ViewDidLoad ()
		{
			this.Title = "Topics";
			_topics = Repository.GetTopics ();
			base.ViewDidLoad ();
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
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var selectedRow = tableView.IndexPathForSelectedRow;
			var selectedTopic = _topics [selectedRow.Row];

			var topicDetailVC = new TopicDetailViewController ();
			topicDetailVC.Topic = selectedTopic;
			this.NavigationController.PushViewController (topicDetailVC, animated:true);
		}
	}
}