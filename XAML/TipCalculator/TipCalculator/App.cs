using System;
using Xamarin.Forms;

namespace TipCalculator
{
    public class App
    {
        public static Page GetMainPage()
        {    
			return new NavigationPage(new MainPage());
        }
    }
}

