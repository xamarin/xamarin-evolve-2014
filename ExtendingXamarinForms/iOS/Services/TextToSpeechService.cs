using Xamarin.Forms;
using MonoTouch.AVFoundation;
using ExtendingXamarinForms.iOS;

[assembly: Dependency(typeof(TextToSpeechService))]

namespace ExtendingXamarinForms.iOS
{
	public class TextToSpeechService : ITextToSpeech
	{
		public void Speak(string text)
		{
			var speechSynthesizer = new AVSpeechSynthesizer();
			speechSynthesizer.SpeakUtterance(new AVSpeechUtterance(text) {
				Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
				Voice = AVSpeechSynthesisVoice.FromLanguage ("en-US"),
				Volume = .5f,
				PitchMultiplier = 1.0f
			});
		}
	}
}

