using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Android.Content;
using Xamarin.Media;
using PhotoApp.PCL.Droid;

[assembly:Dependency(typeof(TakePhotoService))]

namespace PhotoApp.PCL.Droid
{
	public class TakePhotoService : ITakePhoto
    {
		public bool IsAvailable {
			get {
				return new MediaPicker(Forms.Context).IsCameraAvailable;
			}
		}

		public Task<string> TakePhoto()
		{
			var tcs = new TaskCompletionSource<string>();

			var context = Forms.Context;
			var intent = new Intent(
				Forms.Context, 
				typeof(PhotoActivity));

			Action<string> cb = null;
			cb = (file) => {
				PhotoActivity.ImageComplete -= cb;
				if (!string.IsNullOrEmpty(file)) {
					tcs.SetResult(file);
				} else
					tcs.SetCanceled();
			};

			PhotoActivity.ImageComplete += cb;
			context.StartActivity(intent);

			return tcs.Task;
		}
    }
}

		