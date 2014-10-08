using MonoTouch.UIKit;

namespace MasterDetailDemo
{
	//TODO - Demo 3 - Step 03 - Create the derived class
	public class EvolveSplitViewController : UISplitViewController
	{
		private MasterViewController masterView;
		private DetailViewController detailView;

		public EvolveSplitViewController () : base ()
		{
			//TODO - Demo 3 - Step 04 - Create master and detail
//			masterView = new MasterViewController ();
//			detailView = new DetailViewController ();

			//TODO - Demo 3 - Step 08 - Listen for RowClicked event, pass data
			//			masterView.RowClicked += (sender, e) => {
			//				detailView.Update (e.Session);
			//			};

			//TODO - Demo 3 - Step 05 - Set ViewControllers property
//			ViewControllers = new UIViewController[] { masterView, detailView };

			//TODO - Demo 3 - Step 15
//			Delegate = new EvolveSplitViewDelegate ();
		}

		#region Other Methods
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
		#endregion
	}
}