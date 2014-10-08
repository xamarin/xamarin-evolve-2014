using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Linq;
using NavPatterns.Core;

namespace TabbedDemo
{
	partial class SpeakersViewController : UITableViewController
	{
		private List<Speaker> _speakers;

		public override void ViewDidLoad ()
		{
			this.Title = "Speakers";
			_speakers = Repository.GetSpeakers ();
			base.ViewDidLoad ();
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _speakers.Count ();
		}

		private const string cellId = "speakersCell";
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellId);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellId);
			}

			var speaker = _speakers [indexPath.Row];
			cell.TextLabel.Text = speaker.Name;
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var selectedRow = tableView.IndexPathForSelectedRow;
			var selectedSpeaker = _speakers [selectedRow.Row];

			var speakerDetailVC = new SpeakerDetailViewController ();
			speakerDetailVC.Speaker = selectedSpeaker;
			this.NavigationController.PushViewController (speakerDetailVC, animated:true);
		}
	}
}