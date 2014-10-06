using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.IO;

namespace LionTodo {
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate {
		// class-level declarations
		UIWindow window;
		UINavigationController navController;
		UITableViewController list;

		public static AppDelegate Current { get; private set; }
		public TodoDatabase TodoDB { get; set; }
        
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Current = this;

			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			// make the window visible
			window.MakeKeyAndVisible ();

			TodoDB = new TodoDatabase();

			// create our nav controller
			navController = new UINavigationController ();

			list = new TodoListViewController();

			// push the view controller onto the nav controller and show the window
			navController.PushViewController(list, false);
			window.RootViewController = navController;
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}