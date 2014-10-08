using Xamarin.Forms;

namespace FormsNavPatterns
{
	public class SessionsMenuPage : ContentPage
	{
		public SessionsMenuPage ()
		{
			//TODO : Step 03-3 - Add menu button
			//Title = "Menu";

			//TODO : Step 03-8 - Add menu button
			//Icon = "sessions.png";

			#region Initialize Page
			this.Padding = new Thickness (0, Device.OnPlatform (40, 0, 0), 0, 0);

			var sessions = Repository.GetSessions ();

			var cell = new DataTemplate (typeof(TextCell));
			cell.SetBinding (TextCell.TextProperty, "Title");

			var listView = new ListView {
				ItemsSource = sessions,
				ItemTemplate = cell
			};
			#endregion

			//TODO : Step 03-4 - Send event when item selected
//			listView.ItemSelected += (sender, args) => {
//				if (args.SelectedItem != null) {
//					MessagingCenter.Send (new SessionSelected (args.SelectedItem as Session), "SessionSelected");
//					listView.SelectedItem = null;
//				}
//			};

			Content = listView;
		}
	}
}