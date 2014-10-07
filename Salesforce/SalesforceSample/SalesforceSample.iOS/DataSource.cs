using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Salesforce;

namespace SalesforceSample.iOS
{
	public class DataSource : UITableViewSource
	{
		static readonly NSString CellIdentifier = new NSString ("DataSourceCell");
		List<AccountObject> objects = new List<AccountObject> ();
		readonly RootViewController controller;

		public DataSource (RootViewController controller)
		{
			this.controller = controller;
		}

		public List<AccountObject> Objects
		{
			get { return objects; }
			set
			{
				objects = value;
				controller.TableView.ReloadData ();
			}
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return objects.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (CellIdentifier);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, CellIdentifier) {
					Accessory = UITableViewCellAccessory.DisclosureIndicator
				};
			}
			var o = objects[indexPath.Row];
			cell.TextLabel.Text = o.Name;
			cell.DetailTextLabel.Text = o.AccountNumber;
			return cell;
		}

		public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath)
		{
			return true;
		}

		public async override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle,	NSIndexPath indexPath)
		{
			if (editingStyle == UITableViewCellEditingStyle.Delete) {
				var selectedObject = controller.DataSource.Objects.ElementAtOrDefault (indexPath.Row);

				try 
				{
					RootViewController.SetLoadingState(true);
					var deleted = await controller.Client.DeleteAsync (selectedObject);
					if (deleted)
						objects.Remove (selectedObject);
				}
				catch (InsufficientRightsException) 
				{
					ShowInsuffientRightsMessage (tableView);
				}
				catch (DeleteFailedException ex) 
				{
					ShowDeleteFailedMessage (tableView, ex);
				}
				finally
				{
					RootViewController.SetLoadingState(false);
					tableView.ReloadData ();
				}
			}
		}

		static void ShowDeleteFailedMessage (UITableView tableView, DeleteFailedException ex)
		{
			var message = string.Format ("Well, that didn't work for {0} reason{2}: {1}",
			                             ex.FailureReasons.Count (),
			                             string.Join ("; and ", ex.FailureReasons.Select (r => r.Message + ": " + string.Join (", ", r.RelatedIds))),
			                             ex.FailureReasons.Count () == 1 ? string.Empty : "s");
			var alertView = new UIAlertView ("Oops!", message, null, "Dismiss", null);
			alertView.Show ();
			tableView.ReloadData ();
		}

		static void ShowInsuffientRightsMessage (UITableView tableView)
		{
			const string message = "Looks like either you don't have permission to delete that, or someone made it readonly.";
			var alertView = new UIAlertView ("Oops!", message, null, "Dismiss", null);
			alertView.Show ();
			tableView.ReloadData ();
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			controller.DetailViewController.SetDetailItem (objects[indexPath.Row]);
			controller.NavigationController.PushViewController (controller.DetailViewController, true);
		}
	}
}