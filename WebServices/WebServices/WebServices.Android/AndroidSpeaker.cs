using System;
using Xamarin.Forms;
using System.Diagnostics;
using Android.Media;
using WebServices.Droid;
using System.IO;
using WebServices;

[assembly: Dependency(typeof(AndroidSpeaker))]

namespace WebServices.Droid
{
	public class AndroidSpeaker : ISpeaker
	{
		public AndroidSpeaker ()
		{
		}

		public async void Speak (System.IO.Stream stream)
		{
			if (stream == null)
			{
				Debug.WriteLine ("Cannot playback empty stream!");
				return;
			}

			// Copy stream into a file and play it with MediaPlayer.
			string path = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), "temp.mp3");

			using (stream)
			{
				using (var file = File.Open (path, FileMode.Create, FileAccess.Write, FileShare.None))
				{
					stream.CopyTo (file);
				}
			}

			var player = MediaPlayer.Create (Forms.Context, Android.Net.Uri.FromFile (new Java.IO.File (path)));
			player.Start();
		}
	}
}

