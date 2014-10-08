using MonoTouch.UIKit;

namespace TabbedDemo
{
	//TODO : Demo 2 - Step 03 - Create the tab bar controller
	public class EvolveTabController  : UITabBarController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//TODO : Demo 2 - Step 04 - Add the first tab view controller
//			var sessionsVC = new UINavigationController (new SessionsViewController ());

			//TODO : Demo 2 - Step 05 - Set the tab bar item
//			sessionsVC.TabBarItem = new UITabBarItem (
//				title: "Sessions", 
//				image: UIImage.FromBundle ("sessions"), 
//				tag: 0);

     		//TODO : Demo 2 - Step 06 - Add the tab to the ViewControllers property
//			this.ViewControllers = new UIViewController[] { sessionsVC };

			#region Add More View Controllers
			//TODO : Demo 2 - Step 07 - Add more tabs
//			var speakersVC = new UINavigationController (new SpeakersViewController ()) {
//				TabBarItem = new UITabBarItem ("Speakers", UIImage.FromBundle ("speakers"), 1)
//			};
//
//			var roomsVC = new UINavigationController (new RoomsViewController ()) {
//				TabBarItem = new UITabBarItem ("Rooms", UIImage.FromBundle ("rooms2"), 2)
//			};
//
//			var topicsVC = new UINavigationController (new TopicsViewController ()) {
//				TabBarItem = new UITabBarItem ("Topics", UIImage.FromBundle ("topics"), 3)
//			};
//
//			var aboutVC = new UINavigationController (new AboutViewController ()) {
//				TabBarItem = new UITabBarItem ("About", UIImage.FromBundle ("about"), 4)
//			};
			#endregion

			//TODO : Demo 2 - Step 08 - Add tabs to View controllers
//			this.ViewControllers = new UIViewController[] { 
//				sessionsVC,
//				speakersVC,
//				roomsVC,
//				topicsVC,
//				aboutVC
//			}; 

			//TODO : Demo 2 - Step 09 - Optionally set badge
//			sessionsVC.TabBarItem.BadgeValue = "2";

			//TODO : Demo 2 - Step 10 - Too many tabs
//			var sponsorsVC = new UINavigationController (new SponsorsViewController ()) {
//				TabBarItem = new UITabBarItem ("Sponsors", UIImage.FromBundle ("sponsors"), 4)
//			};

			//TODO : Demo 2 - Step 11 (delete step 8)
//			this.ViewControllers = new UIViewController[] { 
//				sessionsVC,
//				speakersVC,
//				roomsVC,
//				topicsVC,
//				sponsorsVC,
//				aboutVC
//			}; 

		}
	}
}