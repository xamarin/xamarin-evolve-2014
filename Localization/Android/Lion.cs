using System;
using System.Collections.Generic;
using Android.App;


namespace NDCTodo
{
	class Lion
	{
		public static string Locale (Activity context)
		{
			return context.Resources.Configuration.Locale.DisplayName;
		}

		public static string Language (Activity context)
		{
			return context.Resources.Configuration.Locale.Language;
		}
	}
}

