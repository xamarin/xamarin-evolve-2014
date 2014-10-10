using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace com.xamarin.university.mobilenav.ios.stack
{
	public class MenuTableViewController : UITableViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Title = "Evolve 2013";
			string[] items = new string[] { "Sessions", "Speakers", "About" };
			TableView.Source = new MenuTableSource (items, this);
		}

		class MenuTableSource : UITableViewSource
		{
			static readonly string speakerCellId = "SpeakerCell";
			string[] data;
			UITableViewController controller;

			public MenuTableSource (string[] speakers, UITableViewController tvc)
			{
				data = speakers;
				controller = tvc;
			}

			public override int RowsInSection (UITableView tableview, int section)
			{
				return data.Length; // only one section
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (speakerCellId);
				if (cell == null)
					cell = new UITableViewCell (UITableViewCellStyle.Default, speakerCellId);
				cell.TextLabel.Text = data [indexPath.Row];
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				return cell;
			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				if (indexPath.Row == 0)
					controller.NavigationController.PushViewController (new SessionsViewController (), true);
				else if (indexPath.Row == 1)
					controller.NavigationController.PushViewController (new SpeakersViewController (), true);
				else
					controller.NavigationController.PushViewController (new AboutViewController (), true);

				tableView.DeselectRow (indexPath, true);
			}
		}
	}
}