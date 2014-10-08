using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsNavPatterns
{
	public class TopicsCarouselPage : CarouselPage
	{
		public TopicsCarouselPage ()
		{
			this.Title = "Topics";
			Icon = "topics.png";

			var topics = Repository.GetTopics();
			foreach (var topic in topics) {
				var page = new ContentPage();
				page.Content = new Label { Text = topic.Name, VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand };
				this.Children.Add(page);
			}
		}
	}
}