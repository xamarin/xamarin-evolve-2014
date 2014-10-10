using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phoneword.Core;
using Xamarin.Forms;
using Phoneword.UI.XamForms.Views;

namespace Phoneword.UI.XamForms
{
    public class App
    {
        public static MainViewModel AppViewModel = null;

        public static Page GetMainPage()
        {
			var dialer = DependencyService.Get<IDialer> ();
            AppViewModel = new MainViewModel(dialer);

            return new NavigationPage(new PhoneTranslatePage());
        }
    }
}
