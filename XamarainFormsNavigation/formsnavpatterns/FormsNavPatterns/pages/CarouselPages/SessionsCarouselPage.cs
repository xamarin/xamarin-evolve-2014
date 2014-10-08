using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsNavPatterns
{
	//TODO : Step 04-2 - Derive from CarouselPage
	public class SessionsCarouselPage : CarouselPage
	{
		public SessionsCarouselPage ()
		{
			this.Title = "Sessions";
			Icon = "sessions.png";

			var sessions = Repository.GetSessions ();

			//TODO : Step 04-3 - Loop through sessions to create pages
//			foreach (var session in sessions) {
//
//				var page = new ContentPage () {
//					Padding = new Thickness (0, 50, 0, 0)
//				};
//				var stackLayout = new StackLayout ();
//
//				var titleLabel = new Label { 
//					Text = session.Title, 
//					HorizontalOptions = LayoutOptions.CenterAndExpand 
//				};
//
//				var speakerNameLabel = new Label {
//					Text = session.SpeakerName,
//					HorizontalOptions = LayoutOptions.CenterAndExpand 
//				};
//
//				stackLayout.Children.Add (titleLabel);
//				stackLayout.Children.Add (speakerNameLabel);
//
//				page.Content = stackLayout;
//
//				//Add content page to cycle through
// //				this.Children.Add (page);
//			}
		}
	}
}