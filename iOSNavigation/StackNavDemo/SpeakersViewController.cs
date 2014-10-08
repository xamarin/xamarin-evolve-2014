using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Linq;
using NavPatterns.Core;

namespace StackNavDemo
{
	partial class SpeakersViewController : UITableViewController
	{
		private readonly List<Speaker> _speakers;

		public SpeakersViewController (IntPtr handle) : base (handle)
		{
			_speakers = Repository.GetSpeakers ();
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

			return cell;
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			var selectedRow = this.TableView.IndexPathForSelectedRow;
			var selectedSpeaker = _speakers [selectedRow.Row];

			var speakerDetailVC = (SpeakerDetailViewController)segue.DestinationViewController;
			speakerDetailVC.Speaker = selectedSpeaker;

			base.PrepareForSegue (segue, sender);
		}
	}
}
