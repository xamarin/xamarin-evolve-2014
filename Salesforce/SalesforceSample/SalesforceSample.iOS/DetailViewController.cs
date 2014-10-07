using System;
using System.Drawing;
using System.Collections.Generic;
using System.Json;
using System.Net;
using System.Threading.Tasks;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SalesforceSample.iOS
{
	public class AddViewController : DetailViewController
	{
		public AddViewController ()
		{
			Title = NSBundle.MainBundle.LocalizedString ("New Account", "New Account");
			SetDetailItem (new AccountObject ());
		}
	}
	public class DetailViewController : UITableViewController
	{
		AccountObject detailItem;
		DetailSource source;

		public event EventHandler<AccountObject> ItemUpdated;
		public event EventHandler Canceled;

		public DetailViewController () : base (UITableViewStyle.Grouped)
		{
			Title = NSBundle.MainBundle.LocalizedString ("Account Details", "Account Details");
		}

		public void SendUpdate ()
		{
			if (ItemUpdated != null)
				ItemUpdated (this, detailItem);
		}

		public void SendCanceled ()
		{
			if (Canceled != null)
				Canceled (this, EventArgs.Empty);
		}

		public void SetDetailItem (AccountObject newDetailItem)
		{
			if (detailItem == newDetailItem)
				return;
			detailItem = newDetailItem;
			ConfigureView (detailItem);
		}

		void ConfigureView (AccountObject target)
		{
			if (TableView == null)
				return;

			if (TableView.Source == null)
				TableView.Source = source = new DetailSource (this);

			source.Data = target;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			ConfigureView (detailItem);
		}
	}
}

