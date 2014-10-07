using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace SalesforceForms
{
	public class MonkeyList : ContentPage
	{
		ListView list;
		public MonkeyList ()
		{
			list = new ListView ();
			list.ItemTemplate = new DataTemplate(typeof(TextCell));
			list.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
			list.ItemTemplate.SetBinding(TextCell.DetailProperty, "Expertise");
			list.ItemTapped += async (sender, e) => {
				list.SelectedItem = null;
				var monkey = e.Item as MonkeyObject;
				await DisplayAlert ("CustomObject!", "Clicked on " + monkey.Name + " who is a " + monkey.Species , "OK");
			};
			var layout = new StackLayout {
				Children = {
					list
				}
			};

			Content = layout;
		}

		List<MonkeyObject> items;
		public List<MonkeyObject> Items {
			get { return items;}
			set { 
				items = value;
				list.ItemsSource = items;
			}
		}
	}
}

