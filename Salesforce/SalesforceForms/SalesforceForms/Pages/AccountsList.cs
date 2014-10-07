using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace SalesforceForms
{
	public class AccountsList : ContentPage
	{
		readonly ListView list;
		public AccountsList ()
		{
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
			var layout = new StackLayout {
				Children = {
					list
				}
			};

			Content = layout;
		}

		List<AccountObject> items;
		public List<AccountObject> Items {
			get { return items;}
			set { 
				items = value;
				list.ItemsSource = items;
			}
		}
	}
}

