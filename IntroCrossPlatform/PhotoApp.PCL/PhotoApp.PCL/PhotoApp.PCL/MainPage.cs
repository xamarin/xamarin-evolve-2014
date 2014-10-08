using System;
using Xamarin.Forms;

namespace PhotoApp.PCL
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

		async void OnTakePhoto()
		{
			ITakePhoto takePhoto = DependencyService.Get<ITakePhoto>();
			if (takePhoto != null 
				&& takePhoto.IsAvailable)
			{
				string filename = await takePhoto.TakePhoto();
				Image image = new Image() { Source = ImageSource.FromFile(filename) };
				this.Content = image;
			}
		}
    }
}

