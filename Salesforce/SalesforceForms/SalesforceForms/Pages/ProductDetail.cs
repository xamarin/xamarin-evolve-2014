using System;
using Xamarin.Forms;
using Salesforce;

namespace SalesforceForms
{
	public class ProductDetail : ContentPage
	{
		Label name, code;
		Entry description;
		Button save, cancel;

		public ProductDetail ()
		{
			name = new Label ();
			name.SetBinding (Label.TextProperty, new Binding("Name"));

			code = new Label {
				TextColor = Color.Gray
			};
			code.SetBinding (Label.TextProperty, new Binding("ProductCode"));

			description = new Entry {
				Placeholder = "description"
			};
			description.SetBinding (Entry.TextProperty, new Binding("Description"));

			save = new Button { Text = "Save" };
			save.Clicked += async (sender, e) => {
				var product = BindingContext as ProductObject;
				await RootPage.Current.Client.UpdateAsync (product);
				RootPage.Current.LoadProducts ();
				await Navigation.PopAsync();
			};
			cancel = new Button { Text = "Cancel" };
			cancel.Clicked += async (sender, e) => {
				await Navigation.PopAsync();
			};

			Content = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(10, 10, 10, 0),
				Children = {
					name,
					code,
					description,
					save
				}

			};

		}
	}
}

