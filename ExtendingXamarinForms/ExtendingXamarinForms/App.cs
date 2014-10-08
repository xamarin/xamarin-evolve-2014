using System;
using Xamarin.Forms;

namespace ExtendingXamarinForms
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new NavigationPage(new OptionsPage ());
		}
	}
}

