using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace TheBestAppEver
{
	public class TodoViewModel : ViewModel<TodoItem>
	{
		List<TodoItem> completed = new List<TodoItem> ();
		List<TodoItem> remaining = new List<TodoItem> ();

		public List<TodoItem> Completed {
			get { return completed;	}
			set {
				completed = value;
				ProcItemsChanged ();
			}
		}

		public List<TodoItem> Remaining {
			get { return remaining; }
			set {
				remaining = value;
				ProcItemsChanged ();
			}
		}

		async Task refreshOffline()
		{
			var remainingTasks = getLocalTasks (false);
			var completedTasks = getLocalTasks (true);

			await Task.WhenAll (remainingTasks, completedTasks);

			Remaining = remainingTasks.Result;
			Completed = completedTasks.Result;

			ProcItemsChanged ();
		}

		public async Task Refresh ()
		{
			await refreshOffline ();
			var items = await WebService.Shared.GetItems ();

			Database.TodoItems.InsertAll (items, "OR REPLACE");

			await refreshOffline ();
		}

		Task<List<TodoItem>> getLocalTasks (bool completed)
		{
			return Task.Run(() => {
				return Database.TodoItems.Table<TodoItem> ().Where (x => x.Completed == completed).ToList ();
			});
		}

		#region implemented abstract members of ViewModel

		public override int RowCount ()
		{
			return Completed.Count + remaining.Count;
		}

		public override int RowCount (int section)
		{
			return section == 0 ? remaining.Count : Completed.Count;
		}

		public override int SectionCount ()
		{
			return 2;
		}

		public override TodoItem ItemForRow (int row)
		{
			if (row < remaining.Count)
				return remaining [row];
			return Completed [row - remaining.Count];
		}

		public override TodoItem ItemForRow (int section, int row)
		{
			if (section == 0)
				return remaining [row];
			return Completed [row];
		}

		public override string HeaderTitle (int section)
		{
			return section == 0 ? "Remaining" : "Completed";
		}

		#endregion
	}
}

