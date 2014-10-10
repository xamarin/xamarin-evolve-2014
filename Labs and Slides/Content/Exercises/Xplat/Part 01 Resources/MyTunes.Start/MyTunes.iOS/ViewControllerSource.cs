using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace MyTunes
{

	public class ViewControllerSource<T> 
		: UITableViewSource
	{
		public readonly string CellStyleName = "ViewControllerSource~"+typeof(T).Name;

		IList<T> dataSource;
		UITableView tableView;

		public IList<T> DataSource {
			get {
				return dataSource;
			}
			set {
				dataSource = value;
				tableView.ReloadData();
			}
		}
		public Func<T,string> TextProc { get; set; }
		public Func<T,string> DetailTextProc { get; set; }

		public ViewControllerSource(UITableView tableView)
		{
			this.tableView = tableView;
		}

		public override int NumberOfSections(UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection(UITableView tableview, int section)
		{
			return DataSource.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(CellStyleName);
			if (cell == null) {
				cell = new UITableViewCell(
					(DetailTextProc == null) 
						? UITableViewCellStyle.Default 
						: UITableViewCellStyle.Subtitle, 
					CellStyleName);
			}

			T item = DataSource[indexPath.Row];

			cell.TextLabel.Text = TextProc == null ? item.ToString() : TextProc(item);
			if (DetailTextProc != null) {
				cell.DetailTextLabel.Text = DetailTextProc(item);
			}

			return cell;
		}
	}
}
