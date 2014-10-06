using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace LionTodo
{
	public class TodoTableSource : UITableViewSource
	{
		IList<Todo> taskList;
		string cellIdentifier = "todocell";

		public TodoTableSource (IList<Todo> tasks) {
			taskList = tasks;
		}

		public override int RowsInSection (UITableView tableview, int section) {
			return taskList.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellIdentifier);

			cell.TextLabel.Text = taskList [indexPath.Row].Title;

			if (taskList [indexPath.Row].Done)
				cell.Accessory = UITableViewCellAccessory.Checkmark;
			else
				cell.Accessory = UITableViewCellAccessory.None;

			return cell;
		}

		public Todo GetItem(int id) {
			return taskList[id];
		}
	}
}
