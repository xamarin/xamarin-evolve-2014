using System;
using Xamarin.Forms;

namespace SalesforceForms
{
	public class Search : ContentPage 
	{
		Label label;
		Entry query;
		Button search;
		ListView list;

		public Search ()
		{
			label = new Label { Text="Enter search query (use * wildcard)" };
			query = new Entry { Placeholder = "search for"};
			search = new Button { Text = "Search" };
			list = new ListView ();
			list.ItemTemplate = new DataTemplate(typeof(TextCell));
			list.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
			list.ItemTemplate.SetBinding(TextCell.DetailProperty, "AccountNumber");

			list.ItemTapped += async (sender, e) => {
				list.SelectedItem = null; // clear highlight
				var account = e.Item as AccountObject;
				var accountDetail = new AccountDetail();
				accountDetail.BindingContext = new AccountViewModel(account);
				await Navigation.PushAsync (accountDetail); 
			};


			search.Clicked += async (sender, e) => {
				var results = await RootPage.Current.Search (query.Text);

				list.ItemsSource = results;

			};

			Content = new StackLayout {
				Padding = new Thickness(0,20,0,0),
				Children = {
					label,
					query,
					search,
					list
				}
			};
		}
	}
}

