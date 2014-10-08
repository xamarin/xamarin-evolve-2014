using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsNavPatterns
{
	public class SpeakersCarouselPage : CarouselPage
	{
		public SpeakersCarouselPage ()
		{
			this.Title = "Speakers";
			Icon = "speakers.png";

			var speakers = Repository.GetSpeakers();
			foreach (var speaker in speakers) {
				var page = new ContentPage();
				page.Content = new Label { Text = speaker.Name, VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand };
				this.Children.Add(page);
			}
		}
	}
}