using System;
using Xamarin.Forms;

namespace SalesforceForms
{
	public class AccountDetail : ContentPage
	{
		AccountObject account;
		ListView list;

		public AccountDetail ()
		{
			SetBinding (TitleProperty, new Binding("Account.Name"));

			list = new ListView ();
			list.IsGroupingEnabled = true;
			list.SetBinding (ListView.ItemsSourceProperty, new Binding("PropertyGroups"));

			list.GroupDisplayBinding = new Binding ("Title");

			list.ItemTemplate = new DataTemplate(typeof(AccountCell));
//			list.ItemTemplate.SetBinding(ViewCell.BindingContextProperty, ".");
//			list.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
//			list.ItemTemplate.SetBinding(TextCell.DetailProperty, "Value");
			list.ItemTapped += async (sender, e) => {
				list.SelectedItem = null;
				var property = e.Item as Property;
				System.Diagnostics.Debug.WriteLine ("Property clicked " + property.Type + " " + property.Value);

				switch (property.Type) {
				case PropertyType.Url:
					var url = property.Value;
					if (!url.StartsWith("http")) url = "http://" + url;
					Device.OpenUri (new Uri(url));
					break;
				case PropertyType.Phone:
					if (await DisplayAlert("Make a call?", "Call " + property.Value + " now?", "Call", "Cancel")) {
						//Device.OpenUri (new Uri("call://" + property.Value));
					}
					break;
				}
			};
			var layout = new StackLayout {
				Children = {
					list
				}
			};

			Content = layout;
		}
	}
}

