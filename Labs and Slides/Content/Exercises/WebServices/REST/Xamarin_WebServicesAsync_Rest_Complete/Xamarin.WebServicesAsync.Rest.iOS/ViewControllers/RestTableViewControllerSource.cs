using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Linq;

namespace Xamarin.WebServicesAsync.Rest.iOS.ViewControllers
{
	public class RestTableViewControllerSource : UITableViewSource
	{

		private const string cellKey = "DrugInfoCell";

		public List<Core.Model.DrugInfo> DrugInformation {get; private set;}

		public RestTableViewControllerSource (IEnumerable<Core.Model.DrugInfo> drugInformation)
		{
            this.DrugInformation = new List<Core.Model.DrugInfo>(drugInformation);
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
			var cell = tableView.DequeueReusableCell (cellKey) as UITableViewCell 
                ?? new UITableViewCell (UITableViewCellStyle.Subtitle, cellKey);

            var drugInfo = DrugInformation[indexPath.Row];

            cell.TextLabel.Text = drugInfo.Synonym;
            cell.DetailTextLabel.Text = drugInfo.Name;
			
			return cell;
		}

        public void ReloadData(UITableView tableView, IEnumerable<Core.Model.DrugInfo> drugInformation)
        {
            DrugInformation.Clear();
            DrugInformation.AddRange(drugInformation);

            tableView.ReloadData();
        }
	}
}

