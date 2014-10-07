using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Salesforce;
using Xamarin.Auth;
using System.Linq;
using System.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;

namespace SalesforceSample.iOS
{
	public class ContactSource : UITableViewSource
	{
		private const string CellIdentifier = "AddContactRow";

		public UITableViewController Controller { get; private set; }

		public ContactSource(UITableViewController controller)
		{
			Controller = controller;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (CellIdentifier) as ContactRowCell;
			if (cell == null) {
				cell = new ContactRowCell ();
			}

			switch (indexPath.Row) {
			case 0:
				cell.Label.Text = "Name";
				break;
			case 1:
				cell.Label.Text = "Industry";
				break;
			case 2:
				cell.Label.Text = "Phon";
				break;
			case 3:
				cell.Label.Text = "Website";
				break;
			case 4:
				cell.Label.Text = "Account#";
				break;
			}
			return cell;
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection (UITableView tableView, int section)
		{
			return 5;
		}
	}

}
