using System;
using Xamarin.Forms;

namespace MobileData
{
    public class App
    {
        public static Page GetMainPage()
        {   
			return new NavigationPage(new MainPage());
        }
    }
}

