using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Linq;

namespace TheBestAppEver
{
	public class ContactsViewController : UITableViewController
	{
		EnumerableViewModel<Person> viewModel;
		ViewModelDataSource<Person> DataSource;
		public ContactsViewController ()
		{
			Title = "Contacts";
			var items = Database.Contacts.Table<Person> ();
			TableView.Source = DataSource = new ViewModelDataSource<Person>{
				CellForItem = (tv,item)=>{
					var cell = tv.DequeueReusableCell<ContactCell>(ContactCell.Key);
					cell.Contact = item;
					return cell;
				},
				ViewModel = (viewModel = new EnumerableViewModel<Person>{
					Items = items,
				}),
			};
		}
	}
}

