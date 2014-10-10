using System;
using MonoTouch.UIKit;

namespace TheBestAppEver
{
	public static class TableViewExtensions
	{
		public static T DequeueReusableCell<T> (this UITableView tv, string key) where T : UITableViewCell, new()
		{
			var cell = tv.DequeueReusableCell (key);
			if (cell is T)
				return (T)cell;
			return new T ();
		}
	}
}

