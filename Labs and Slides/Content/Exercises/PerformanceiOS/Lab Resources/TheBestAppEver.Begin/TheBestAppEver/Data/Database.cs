using System;
using System.IO;

namespace TheBestAppEver
{
	public class Database : SQLite.SQLiteConnection
	{
		static Database contacts;
		public static Database Contacts {
			get {
				return contacts ?? (contacts = new Database("contacts.db"));
			}
		}


		static Database todoItems;
		public static Database TodoItems {
			get {
				return todoItems ?? (todoItems = CreateToDoDatabase());
			}
		}


		static Database artists;
		public static Database Artists {
			get {
				return todoItems ?? (todoItems = new Database("todoItems.db"));
			}
		}

		static Database songs;
		public static Database Songs {
			get {
				return songs ?? (songs = CreateSongsDatabase());
			}
		}

		static Database CreateSongsDatabase()
		{
			var db = new Database ("songs.db");
			db.CreateTable<Song> ();
			return db;
		}

		static Database CreateToDoDatabase()
		{
			var db = new Database ("todoItems.db");
			db.CreateTable<TodoItem> ();
			return db;
		}


		public static readonly string basePath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
		public Database (string database) : base (getDbPath(database))
		{

		}

		static string getDbPath(string database)
		{
			var path = Path.Combine (basePath, database);
			if (!File.Exists (path) && File.Exists (database))
				File.Copy (database, path, true);
			return path;
		}


	}
}

