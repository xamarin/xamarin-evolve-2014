using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Linq;
using NavPatterns.Core;

namespace TabbedDemo
{
	partial class SponsorsViewController : UITableViewController
	{
		private List<Sponsor> _sponsors;

		public override void ViewDidLoad ()
		{
			this.Title = "Sponsors";
			_sponsors = Repository.GetSponsors ();
			base.ViewDidLoad ();
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _sponsors.Count ();
		}

		private const string cellId = "sponsorsCell";
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellId);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellId);
			}

			var sponsor = _sponsors [indexPath.Row];
			cell.TextLabel.Text = sponsor.Name;
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var selectedRow = tableView.IndexPathForSelectedRow;
			var selectedSponsor = _sponsors [selectedRow.Row];

			var sponsorDetailVC = new SponsorDetailViewController (selectedSponsor);

			this.NavigationController.PushViewController (sponsorDetailVC, animated:true);
		}
	}
}