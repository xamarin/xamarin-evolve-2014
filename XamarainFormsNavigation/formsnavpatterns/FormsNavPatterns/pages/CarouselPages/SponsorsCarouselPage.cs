using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsNavPatterns
{
	public class SponsorsCarouselPage : CarouselPage
	{
		public SponsorsCarouselPage ()
		{
			this.Title = "Sponsors";
			Icon = "sponsors.png";

			var sponsors = Repository.GetSponsors();

			foreach (var sponsor in sponsors) {
				var page = new ContentPage();
				page.Content = new Label { Text = sponsor.Name, VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand };
				this.Children.Add(page);
			}
		}
	}
}