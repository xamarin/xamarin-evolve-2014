using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsNavPatterns
{
	public class RoomsCarouselPage : CarouselPage
	{
		public RoomsCarouselPage ()
		{
			this.Title = "Rooms";
			Icon = "rooms2.png";

			var rooms = Repository.GetRooms();

			foreach (var room in rooms) {
				var page = new ContentPage();
				page.Content = new Label { Text = room.Name, VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand };
				this.Children.Add(page);
			}
		}
	}
}