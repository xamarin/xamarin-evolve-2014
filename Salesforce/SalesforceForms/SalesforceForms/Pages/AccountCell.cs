using System;
using Xamarin.Forms;

namespace SalesforceForms
{
	public class AccountCell : ViewCell 
	{
		public AccountCell ()
		{
			var text = new Label {
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Font = Font.SystemFontOfSize(NamedSize.Small),
				YAlign = TextAlignment.Center
			};
			text.SetBinding (Label.TextProperty, new Binding("Name"));
			var detail = new Label {
				HorizontalOptions = LayoutOptions.End,
				YAlign = TextAlignment.Center
			};
			detail.SetBinding (Label.TextProperty, new Binding("Value"));

			View = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(10, 0, 10, 0),
				Children = {
					text, detail
				}
			};
		}
	}
}

