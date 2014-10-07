using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;

namespace SalesforceForms.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Forms.Init ();

			window = new UIWindow (UIScreen.MainScreen.Bounds);

			var page = App.GetMainPage () as RootPage;
			var vc = page.CreateViewController ();

			window.RootViewController = vc;
			window.MakeKeyAndVisible ();

			page.InitializeSalesforce (vc);

			return true;
		}
	}
}

