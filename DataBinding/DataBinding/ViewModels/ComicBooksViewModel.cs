using DataBinding.Common;
using System.Collections.ObjectModel;

namespace DataBinding.ViewModels
{
	public class ComicBooksViewModel : BaseViewModel
	{
		public ComicBooksViewModel ()
		{
			_comicBooks = new ObservableCollection<ComicBook> (ComicBookFactory.GetComicBooks ());
		}

		ObservableCollection<ComicBook> _comicBooks;

		public ObservableCollection<ComicBook> ComicBooks {
			get {
				return _comicBooks;
			}
			set {
				if (_comicBooks != value) {
					_comicBooks = value;
					OnPropertyChanged ();
				}
			}
		}
	}
}

