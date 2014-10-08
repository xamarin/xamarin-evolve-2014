using System;
using Xamarin.Forms;

namespace FormsNavPatterns
{
	public class MenuPage : ContentPage
	{
		string[] _menuItems = new string[] { "Sessions", "Speakers", "Rooms", "Topics", "Sponsors", "About" };

		public MenuPage ()
		{
			var listView = new ListView {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				ItemsSource = _menuItems
			};

			listView.ItemSelected += async (sender, e) => {
				var menuItem = e.SelectedItem.ToString ();
				var nextPage = GetNextPage (menuItem);

				//Navigate to next page
				await this.Navigation.PushAsync (nextPage);
			};

			this.Content = listView;
		}

		#region Other Methods
		private Page GetNextPage (string menuItem)
		{
			Page nextPage = null;
			switch (menuItem) {
			case "Sessions":
				nextPage = new SessionsPage ();
				break;
			case "Speakers":
				nextPage = new SpeakersPage ();
				break;
			case "Rooms":
				nextPage = new RoomsPage ();
				break;
			case "Topics":
				nextPage = new TopicsPage ();
				break;
			case "Sponsors":
				nextPage = new SponsorsPage ();
				break;
			case "About":
				nextPage = new AboutPage ();
				break;
			}
			return nextPage;
		}
	
		#endregion
	}	
}