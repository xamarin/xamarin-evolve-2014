using MonoTouch.UIKit;

namespace MasterDetailDemo
{
	//TODO - Demo 3 - Step 14
//	public class EvolveSplitViewDelegate : UISplitViewControllerDelegate
//	{
//		public override bool ShouldHideViewController (UISplitViewController svc, UIViewController viewController, UIInterfaceOrientation inOrientation)
//		{
//			return inOrientation == UIInterfaceOrientation.Portrait
//				|| inOrientation == UIInterfaceOrientation.PortraitUpsideDown;
//		}
//
//		public override void WillHideViewController (UISplitViewController svc, UIViewController aViewController, UIBarButtonItem barButtonItem, UIPopoverController pc)
//		{
//			DetailViewController detailView = svc.ViewControllers[1] as DetailViewController;
//			detailView.AddContentsButton (barButtonItem);
//
//			//TODO - Demo 3 - Step 17
//			//detailView.Popover = pc;
//		}
//
//		public override void WillShowViewController (UISplitViewController svc, UIViewController aViewController, UIBarButtonItem button)
//		{
//			DetailViewController detailView = svc.ViewControllers[1] as DetailViewController;
//			detailView.RemoveContentsButton ();
//
//			//TODO - Demo 3 - Step 18
//			//detailView.Popover = null;
//		}
//	}
}