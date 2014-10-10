using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Linq;

namespace Xamarin.WebServicesAsync.Soap.iOS.ViewControllers
{
	public class SoapTableViewControllerSource : UITableViewSource
	{

		private const string cellKey = "DrugInformationCell";

		public List<Core.Model.DrugInfo> DrugInformation {get; private set;}

		public SoapTableViewControllerSource (IEnumerable<Core.Model.DrugInfo> drugInformation)
		{
			this.DrugInformation = drugInformation.ToList();
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return DrugInformation.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellKey) as UITableViewCell;

			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, cellKey);

			var drugInfo = DrugInformation [indexPath.Row];

			// TODO: populate the cell with the appropriate data based on the indexPath
            cell.TextLabel.Text = drugInfo.Synonym;
            cell.DetailTextLabel.Text = drugInfo.Name;
			
			return cell;
		}
	}
}

