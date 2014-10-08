using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FormsNavPatterns
{
	public static class App
	{
		//TODO : Step 01 - Navigation Page
		//		public static Page GetMainPage ()
		//		{
		//			//NavigationPage controls the hierarchy
		//			return new NavigationPage (new MenuPage ());
		//		}

		//TODO : Step 02 - Tabbed Page
		//		public static Page GetMainPage ()
		//		{
		//			//TODO : Step 02-1 - Create tabbed page
		//			var tabbedMenuPage = new TabbedPage ();
		//
		//			//TODO : Step 02-2 - Add tab
		//			tabbedMenuPage.Children.Add (
		//				new NavigationPage (new SessionsPage ()) {
		//					Title = "Sessions",
		//					Icon = "sessions.png"
		//				}
		//			);
		//
		//			//TODO : Step 02-3 - Add more tabs
		//			tabbedMenuPage.Children.Add (new NavigationPage (new SpeakersPage ()){ Title = "Speakers", Icon = "speakers.png" });
		//			tabbedMenuPage.Children.Add (new NavigationPage (new RoomsPage ()){ Title = "Rooms", Icon = "rooms2.png" });
		//			tabbedMenuPage.Children.Add (new NavigationPage (new TopicsPage ()){ Title = "Topics", Icon = "topics.png" });
		//			tabbedMenuPage.Children.Add (new NavigationPage (new SponsorsPage ()){ Title = "Sponsors", Icon = "sponsors.png" });
		//			tabbedMenuPage.Children.Add (new NavigationPage (new AboutPage ()){ Title = "About", Icon = "about.png" });
		//
		//			return tabbedMenuPage;
		//		}

		//TODO : Step 03 - MasterDetailPage
//		public static Page GetMainPage ()
//		{
//			return new EvolveMasterDetailPage ();
//		}

		//TODO : Step 04 - CarouselPage
		//		public static Page GetMainPage ()
		//		{
		//			//TODO : Step 04-1 - Show carousel page
		// //			return new SessionsCarouselPage ();
		//
		//			//TODO : Step 04-4 - Wrap it in tabs
		//			//			var tabbedMenuPage = new TabbedPage ();
		//			//
		//			//			tabbedMenuPage.Children.Add (new SessionsCarouselPage ());
		//			//			tabbedMenuPage.Children.Add (new SpeakersCarouselPage ());
		//			//			tabbedMenuPage.Children.Add (new RoomsCarouselPage ());
		//			//			tabbedMenuPage.Children.Add (new TopicsCarouselPage ());
		//			//			tabbedMenuPage.Children.Add (new SponsorsCarouselPage ());
		//			//
		//			//			return tabbedMenuPage;
		//		}


	}
}