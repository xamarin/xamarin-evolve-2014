using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace XamarinFormsIntro
{
	public class MainPage : ContentPage
	{
		public MainPage ()
		{
			// This collection holds the data the list will show.
			// Adding elements here will automatically update the list.
			var awesomeItems = new ObservableCollection<string>
			{ 
				"Evolve 2014 is great...",
				"and fantastic",
			};

			// A button to add elements to the list.
			var btn = new Button
			{ 
				// This will appear as the button's title.
				Text = "Add awesomeness"
			};

			// A list, displaying some data.
			var listView = new ListView {
				// The source can be anything that is IEnumerable.
				ItemsSource = awesomeItems
			};

			// Because a ContentPage can only hold one content element, we have 
			// a StackLayout to hold the button and the list.
			var stackLayout = new StackLayout
			{ 
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(20)
			};

			// Add child controls to the layout.
			stackLayout.Children.Add (btn);
			stackLayout.Children.Add (listView);

			// TODO: Add some action when the button is clicked.
			// Copy from Demo Files / Button Click.txt
		
			// Return the completed page.
			this.Content = stackLayout;
		}

		// Some data we can dynamically add to the list.
		static string[] data = new string[] {
			"and fun",
			"and unique",
			"and better than great",
			"and better than anything you can imagine!",
			"That's it.",
			"Really.",
			"Stop clicking!",
			"CONTINUE THE TALK, OK!?"
		};
		static int index = 0;
	}
}

