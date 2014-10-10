using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Evolve.Core;

namespace com.xamarin.university.mobilenav.ios.tabs
{
	public class SpeakersTableSource : UITableViewSource
	{		
		static readonly string speakerCellId = "SpeakerCell";
		List<Speaker> data;
		UITableViewController controller;

		public SpeakersTableSource (List<Speaker> speakers, UITableViewController tvc)
		{
			data = speakers;
			controller = tvc;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return data.Count;
		}
		
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var speaker = data [indexPath.Row];

			controller.NavigationController.PushViewController (new SpeakerViewController (speaker), true);

			tableView.DeselectRow (indexPath, true);
		}
		
		
		
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (speakerCellId);
			
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, speakerCellId);
			}
			var speaker = data [indexPath.Row];
			
			cell.TextLabel.Text = speaker.Name;
			cell.DetailTextLabel.Text = speaker.Company;
			cell.ImageView.Image = UIImage.FromBundle(speaker.HeadshotUrl);

			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			
			return cell;
		}
	}
}

