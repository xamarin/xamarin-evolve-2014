using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace SalesforceForms
{
	public class ProductList : ContentPage
	{
		ListView list;
		public ProductList ()
		{
			list = new ListView ();
			list.ItemTemplate = new DataTemplate(typeof(TextCell));
			list.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
			list.ItemTemplate.SetBinding(TextCell.DetailProperty, "ProductCode");
			list.ItemTapped += async (sender, e) => {
				list.SelectedItem = null;
				var product = e.Item as ProductObject;
				var productDetail = new ProductDetail ();
				productDetail.BindingContext = product;
				await Navigation.PushAsync (productDetail); 
			};
			var layout = new StackLayout {
				Children = {
					list
				}
			};

			Content = layout;
		}

		List<ProductObject> items;
		public List<ProductObject> Items {
			get { return items;}
			set { 
				items = value;
				list.ItemsSource = items;
			}
		}
	}
}

