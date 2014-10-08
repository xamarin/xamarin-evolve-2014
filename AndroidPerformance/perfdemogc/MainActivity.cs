using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PerfDemoGC
{
	[Activity (Label = "PerfDemoGC", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.NewMain);

			var layout = FindViewById<LinearLayout> (Resource.Id.mainLayout);
			var blackbirdImage = new MyImageView (this) {};

			blackbirdImage.SetImageResource (Resource.Drawable.blackbird);
			layout.AddView (blackbirdImage);

			var removeImageButton = FindViewById<Button> (Resource.Id.removeImageButton);

			removeImageButton.Click += (sender, e) => {
				ViewGroup parent = (ViewGroup)blackbirdImage.Parent;
				parent.RemoveView (blackbirdImage);

				//TODO : Demo 2 - Step 1
				//blackbirdImage.Dispose();
			};
		}
	}
}