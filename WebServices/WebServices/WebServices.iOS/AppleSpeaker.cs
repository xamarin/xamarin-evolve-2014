using System;
using Xamarin.Forms;
using WebServices.iOS;
using MonoTouch.AVFoundation;
using MonoTouch.Foundation;
using System.Diagnostics;
using System.IO;

[assembly: Dependency(typeof(AppleSpeaker))]

namespace WebServices.iOS
{
	public class AppleSpeaker : ISpeaker
	{
		public AppleSpeaker ()
		{
		}

		public void Speak (System.IO.Stream stream)
		{
			if (stream == null)
			{
				Debug.WriteLine ("Cannot playback empty stream!");
				return;
			}

			// Save the stream to a file and play it.
			string path = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), "temp.mp3");

			using (stream)
			using (var file = File.Open (path, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				stream.CopyTo (file);
			}

			// The AVAudioPlayer instance has to be class scope, otherwise it will stop playing as soon
			// as it gets collected.
			this.player = AVAudioPlayer.FromUrl (NSUrl.FromFilename (path));
			this.player.FinishedPlaying += (sender, e) => {
				player = null;
			};
			this.player.PrepareToPlay ();
			this.player.Play ();
		}

		AVAudioPlayer player;
	}
}

