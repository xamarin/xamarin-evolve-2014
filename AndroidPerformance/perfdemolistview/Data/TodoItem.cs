using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using Android.Content;
using System.IO;

namespace PerfDemoListView
{
	public class TodoItem
	{
		public string Title { get; set; }

		public bool Completed { get; set; }

		public string Notes { get; set; }

		public override string ToString ()
		{
			return string.Format ("{0}{1}", Title, Completed ? " - Completed" : "");
		}
	}
}