using DataBinding.Common;
using Xamarin.Forms;
using DataBinding.ViewModels;
using AutoMapper;
using System.Linq;

namespace DataBinding.Pages
{
	public class ListPage : ContentPage
	{
		public DataTemplate Cell { get; private set; }

		public ListPage ()
		{
			SetValue(Page.TitleProperty, "Comics");

			var viewModel = new ComicBooksViewModel ();

			BackgroundColor = UIHelper.BackgroundColor;

			var list = new ListView();

			list.ItemsSource = viewModel.ComicBooks.OrderBy(x => x.SeriesNumber).ToList();

			Cell = new DataTemplate(typeof(ImageCell));
			Cell.SetBinding(TextCell.TextProperty, "ListName");
			Cell.SetBinding(ImageCell.ImageSourceProperty, "ImageSmall");

			list.ItemTemplate = Cell;

			list.ItemSelected += (sender, e) =>
			{
				var selectedItem = e.SelectedItem as ComicBook;

				if (selectedItem != null){
					if (selectedItem.SeriesNumber == 10){
						var mappingByHand = new MappingByHand(selectedItem);
						Navigation.PushAsync(mappingByHand);
					}

					if (selectedItem.SeriesNumber == 11){
						var hardworkPage = new CodeBinding(Mapper.Map<ComicBook, ComicBookViewModel>(selectedItem));
						Navigation.PushAsync(hardworkPage);
					}

					if (selectedItem.SeriesNumber == 12){
						var hardworkPage = new XamlBinding(Mapper.Map<ComicBook, ComicBookViewModel>(selectedItem));
						Navigation.PushAsync(hardworkPage);
					}
				}
			};

			Content = list;	
		}
	}
}

