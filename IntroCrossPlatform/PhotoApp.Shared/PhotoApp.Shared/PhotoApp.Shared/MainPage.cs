using System;
using System.IO;
using Xamarin.Forms;

namespace PhotoApp.Shared
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            Content = new Label
            {
                Text = "Take a Picture!",
                Font = Font.SystemFontOfSize(24.0, FontAttributes.Bold),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            ToolbarItems.Add(
                new ToolbarItem("Take Photo", null, OnTakePhoto));
        }

        async partial void OnTakePhoto();
}
