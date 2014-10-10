using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace People
{
    public class App
    {
        public static Page GetMainPage(string displayText)
        {
            return new ContentPage
            {
                Content = new Label
                {
                    Text = displayText,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                },
            };
        }
    }
}
