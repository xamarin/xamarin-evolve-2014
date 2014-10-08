using System;
using Xamarin.Media;
using Xamarin.Forms;
using Android.Content;

namespace PhotoApp.Shared
{
    public partial class MainPage
    {
		async partial void OnTakePhoto()
		{
            var picker = new MediaPicker(Forms.Context);
            if (!picker.IsCameraAvailable)
                await DisplayAlert("Error", "No Camera Available!", "OK", null);
            else 
            {
                var intent = new Intent(
                                 Forms.Context, 
                                 typeof(PhotoApp.Android.PhotoActivity));

                var context = Forms.Context;

                Action<string> cb = null;
                cb = (file) => {
                    PhotoApp.Android.PhotoActivity.ImageComplete -= cb;

                    if (string.IsNullOrEmpty(file)) {
                        Image image = new Image() { Source = new FileImageSource { File = file } };
                        this.Content = image;
                    }
                };

                PhotoApp.Android.PhotoActivity.ImageComplete += cb;
                context.StartActivity(intent);
            }
		}
    }
}

