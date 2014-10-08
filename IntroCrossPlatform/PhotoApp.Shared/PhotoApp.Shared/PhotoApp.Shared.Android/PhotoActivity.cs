using System;
using Android.App;
using Android.Content;
using Android.OS;
using System.Threading.Tasks;
using Xamarin.Media;

namespace PhotoApp.Android
{
	[Activity(Label = "PhotoActivity")]            
	public class PhotoActivity : Activity
	{
		public static event Action<string> ImageComplete;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			var picker = new MediaPicker(this);
			var intent = picker.GetTakePhotoUI(
				             new StoreCameraMediaOptions {
					Name = "test.jpg",
					Directory = "photos"
				});
			StartActivityForResult(intent, 1);
		}

		protected override void OnActivityResult(int requestCode, 
								Result resultCode, Intent data)
		{
			if (data != null) {
				data.GetMediaFileExtraAsync(this)
					.ContinueWith(t => {
						if (ImageComplete != null)
							ImageComplete((resultCode == Result.Ok) ? t.Result.Path : "");
					}, TaskScheduler.FromCurrentSynchronizationContext())
					.ContinueWith(tr => Console.WriteLine(tr.Exception.Message),
						TaskContinuationOptions.NotOnRanToCompletion);
			} else {
				Console.WriteLine("No camera.");
			}

			// Return to parent activity (Forms)
			this.Finish();
		}
	}
}