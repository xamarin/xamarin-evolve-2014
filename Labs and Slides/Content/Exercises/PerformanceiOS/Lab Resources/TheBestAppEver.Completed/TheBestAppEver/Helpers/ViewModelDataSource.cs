using System;
using MonoTouch.UIKit;

namespace TheBestAppEver
{
	public class ViewModelDataSource<T> : UITableViewSource
	{
		public Func<UITableView,T,UITableViewCell> CellForItem;
		public ViewModel<T> ViewModel = new EmptyViewModel<T> ();

		public ViewModelDataSource ()
		{
		}

		#region implemented abstract members of UITableViewSource

		public override int RowsInSection (UITableView tableview, int section)
		{
			return ViewModel.RowCount (section);
		}
		public override int NumberOfSections (UITableView tableView)
		{
			return ViewModel.SectionCount ();
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			if (CellForItem != null)
				return CellForItem (tableView, ViewModel.ItemForRow (indexPath.Section, indexPath.Row));

			throw new Exception ("Event CellForItem is required for ViewModelDatasource");
		}

		public override string TitleForHeader (UITableView tableView, int section)
		{
			return ViewModel.HeaderTitle (section);
		}

		#endregion
	}
}

