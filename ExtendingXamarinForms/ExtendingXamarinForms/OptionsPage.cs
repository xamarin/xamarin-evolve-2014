using System;
using Xamarin.Forms;

namespace ExtendingXamarinForms
{
	public class OptionsPage : ContentPage
	{
		public OptionsPage ()
		{
			Title = "Extending";

			var pagesList = new string[] {
				"Service Example",
				"Markup Example",
				"Custom Control Renderer",
				"Gesture Page"
			};

			var listView = new ListView {
				ItemsSource = pagesList,
				ItemTemplate = new DataTemplate (typeof(TextCell)) {
					Bindings = {
						{ TextCell.TextProperty, new Binding (".") },
					}
				}
			};

			listView.ItemTapped += async (s, e) => {
				var item = e.Item.ToString ();

				switch (item)
				{
					case "Service Example":
						await Navigation.PushAsync (new SaySomethingPage());
						break;
					case "Markup Example":
						await Navigation.PushAsync (new MarkupExtensionExamplePage());
						break;
					case "Custom Control Renderer":
						await Navigation.PushAsync (new ExampleDisplay());
						break;
					case "Gesture Page":
						await Navigation.PushAsync(new DisplayCurrentSwipeActionPage());
						break;
				}
			};

			Content = listView;
		}
	}
}

