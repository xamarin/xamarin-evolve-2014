using Xamarin.Forms;

namespace FormsNavPatterns
{
	public class DetailPage : ContentPage
	{
		public DetailPage ()
		{
			Title = "Session Detail";

			var layout = new StackLayout {
				Padding = new Thickness (0, 50, 0, 0)
			};
			
			var titleLabel = new Label {
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			titleLabel.SetBinding (Label.TextProperty, "Title");
			
			var speakerNameLabel = new Label {
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			speakerNameLabel.SetBinding (Label.TextProperty, "SpeakerName");
			
			layout.Children.Add (titleLabel);
			layout.Children.Add (speakerNameLabel);

			Content = layout;
		}

		public void UpdateSession(Session session)
		{
			this.BindingContext = session;
		}
	}
}