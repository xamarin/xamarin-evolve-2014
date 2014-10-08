using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Media;
using PhotoApp.PCL.iOS;

[assembly:Dependency(typeof(TakePhotoService))]

namespace PhotoApp.PCL.iOS
{
	public class TakePhotoService : ITakePhoto
    {
		public bool IsAvailable {
			get {
				return picker.IsCameraAvailable;
			}
		}

		readonly MediaPicker picker;

		public TakePhotoService()
		{
			picker = new MediaPicker();
		}

		public async Task<string> TakePhoto()
		{
			var file = await picker.TakePhotoAsync(
				new StoreCameraMediaOptions {
					Directory = "photos",
					Name = "photo.jpg",
					DefaultCamera = CameraDevice.Rear,
				});

			return file.Path;
		}
    }
}

		