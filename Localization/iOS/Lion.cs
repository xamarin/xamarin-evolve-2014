using System;
using MonoTouch.Foundation;

namespace LionTodo
{
	public class Lion
	{
		public Lion ()
		{
		}

		public static string Localize(string key, string comment) {
			// TODO: iOS native method
			return NSBundle.MainBundle.LocalizedString (key, comment);
		}
	}
}

