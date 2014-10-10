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

			// TODO: Step 1 Add .ToList() to force this to evaluate and cache off to a list.
			var items = Database.Contacts.Table<Person> ().ToList();
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

