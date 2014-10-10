using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using WcfServiceHost.Model;

namespace Xamarin.EnterpriseWcf.iOS.TableViewSource
{
    class MonkeyInformationSource : UITableViewSource
    {
        private readonly NSString monkeyCellIdentifier = new NSString("MonkeyCell");

        private List<MonkeyInformation> monkeyInformation;

        public MonkeyInformationSource(IEnumerable<MonkeyInformation> monkeyInformation) : base()
        {
            this.monkeyInformation = new List<MonkeyInformation>(monkeyInformation);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell =
                tableView.DequeueReusableCell(monkeyCellIdentifier)
                ?? new UITableViewCell(UITableViewCellStyle.Subtitle, monkeyCellIdentifier);

            var monkeyOfInterest = monkeyInformation[indexPath.Row];

            cell.TextLabel.Text = monkeyOfInterest.CommonName;
            cell.DetailTextLabel.Text = monkeyOfInterest.ScientificName;

            return cell;
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return monkeyInformation.Count;
        }

        public void RefreshData(UITableView tableview, IEnumerable<MonkeyInformation> updatedMonkeyInfo)
        {
            this.monkeyInformation.Clear();
            this.monkeyInformation.AddRange(updatedMonkeyInfo);

            BeginInvokeOnMainThread(() => tableview.ReloadData());
        }
    }
}