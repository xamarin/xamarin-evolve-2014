using System;
using SQLite;

namespace LionTodo {
	/// <summary>
	/// Represents a Task.
	/// </summary>
	public class Todo {
		public Todo ()
		{
		}
		[PrimaryKey,AutoIncrement]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Notes { get; set; }
		public bool Done { get; set; }
	}
}