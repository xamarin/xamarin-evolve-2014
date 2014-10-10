using System;
using SQLite;

namespace TheBestAppEver
{
	public class TodoItem
	{
		public string Title { get; set; }
		public bool Completed { get; set; }
		[PrimaryKey]
		public string UrlHash {get;set;}
	}
}

