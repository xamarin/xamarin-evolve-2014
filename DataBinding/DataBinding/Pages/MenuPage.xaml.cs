using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataBinding.Common;
using Xamarin.Forms;
using DataBinding.Pages;
using DataBinding.ViewModels;

namespace DataBinding
{	
	public partial class MenuPage : ContentPage
	{	
		/// <summary>
		/// Initializes a new instance of the <see cref="DataBinding.MenuPage"/> class.
		/// </summary>
		public MenuPage ()
		{
			InitializeComponent ();

			Title = "Comics";

			CreateBindingContext ();

			BackgroundColor = UIHelper.BackgroundColor;
		}

		/// <summary>
		/// Creates the binding context.
		/// </summary>
		void CreateBindingContext ()
		{
			var viewModel = new ComicBooksViewModel ();
			var menuItems = new List<MenuOption> ();
			foreach (var item in viewModel.ComicBooks.OrderBy(x => x.SeriesNumber)) {
				menuItems.Add (new MenuOption{ 
					Order = item.SeriesNumber, 
					ImageUrl = item.ImageSmall,
					MenuOptionTitle = item.ListName
				});
			}

			menuItems.Add (new MenuOption{ 
				Order = 99, 
				ImageUrl = "",
				MenuOptionTitle = "About"
			});

			_menuOptions = menuItems;

			BindingContext = this;

			MenuList.ItemSelected += (sender, e) =>
			{
				var selectedItem = e.SelectedItem as MenuOption;

				if (selectedItem != null){
					if (selectedItem.Order == 10){
						var mappingByHand = new MappingByHand(
							viewModel.ComicBooks.FirstOrDefault(b => b.SeriesNumber == selectedItem.Order));
						Navigation.PushAsync(mappingByHand);
					}

					if (selectedItem.Order == 11){
						var hardworkPage = new CodeBinding(Mapper.Map<ComicBook, ComicBookViewModel>(
							viewModel.ComicBooks.FirstOrDefault(b => b.SeriesNumber == selectedItem.Order)));
						Navigation.PushAsync(hardworkPage);
					}

					if (selectedItem.Order == 12){
						var hardworkPage = new XamlBinding(Mapper.Map<ComicBook, ComicBookViewModel>(
							viewModel.ComicBooks.FirstOrDefault(b => b.SeriesNumber == selectedItem.Order)));
						Navigation.PushAsync(hardworkPage);
					}
					((ListView)sender).SelectedItem = null;
				}
			};
		}

		List<MenuOption> _menuOptions;

		public List<MenuOption> MenuOptions {
			get{
				return _menuOptions;
			}
			set{
				_menuOptions = value;
			}
		}
	}
}

