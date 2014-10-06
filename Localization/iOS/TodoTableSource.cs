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
		TodoListViewController viewController;

		public TodoTableSource (IList<Todo> tasks, TodoListViewController viewController) {
			taskList = tasks;
			this.viewController = viewController;
		}

		public override int RowsInSection (UITableView tableview, int section) {
			return taskList.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellIdentifier);
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);

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

		TodoViewController todoVC;
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var t = taskList[indexPath.Row];
			todoVC = new TodoViewController (t);

			viewController.NavigationController.PushViewController (todoVC, true);
			tableView.DeselectRow (indexPath, true);
		}
	}
}

