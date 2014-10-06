using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SQLite;

namespace LionTodo
{
	public class TodoDatabase
	{
		SQLiteConnection conn;

		public TodoDatabase () 
		{
			string folder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			conn = new SQLiteConnection (System.IO.Path.Combine (folder, "todolist.db"));
			conn.CreateTable<Todo> ();
		}

		public IList<Todo> GetAll() {
			return (from i in conn.Table<Todo> () orderby i.Id select i).ToList ();
		}

		public Todo Get(int id) {
			return conn.Table<Todo>().FirstOrDefault(x => x.Id == id);
		}

		public int Save(Todo t) {
			if (t.Id != 0) {
				conn.Update (t);
				return t.Id;
			} else {
				return conn.Insert (t);
			}
		}

		public int Delete(Todo t) {
			return conn.Delete (t);
		}
	}
}
