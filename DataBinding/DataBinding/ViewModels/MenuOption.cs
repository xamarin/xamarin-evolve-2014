using System;

namespace DataBinding.ViewModels
{
	public class MenuOption : BaseViewModel
	{
		int _order;

		public int Order { 
			get { return _order; }
			set {
				if (_order != value) {
					_order = value;
					OnPropertyChanged ();
				}
			}
		}

		string _menuOptionTitle;

		public string MenuOptionTitle { 
			get { return _menuOptionTitle; }
			set {
				if (_menuOptionTitle != value) {
					_menuOptionTitle = value;
					OnPropertyChanged ();
				}
			}
		}

		string _imageUrl;

		public string ImageUrl { 
			get { return _imageUrl; }
			set {
				if (_imageUrl != value) {
					_imageUrl = value;
					OnPropertyChanged ();
				}
			}
		}
	}
}

