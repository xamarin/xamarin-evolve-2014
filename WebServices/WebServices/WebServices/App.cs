using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace WebServices
{
	public class App
	{
		public static Page GetMainPage()
		{
			return new NavigationPage (new MenuPage ());
		}

		public static string GetLanguageFromIndex(int index)
		{
			switch (index)
			{
			case 0 : return "en";
			case 1 : return "de";
			case 2 : return "fr";
			default : return "en";
			}
		}
	}
}
