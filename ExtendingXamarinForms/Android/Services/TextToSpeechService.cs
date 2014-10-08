using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Speech.Tts;
using Xamarin.Forms;
using ExtendingXamarinForms.Android;

[assembly: Dependency(typeof(TextToSpeechDroid))]

namespace ExtendingXamarinForms.Android
{
	public class TextToSpeechDroid : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
	{
		TextToSpeech speech;
		string lastText;

		public void Speak(string text)
		{
			if (speech == null) {
				lastText = text;
				speech = new TextToSpeech(Application.Context, this);
			}
			else {
				speech.Speak(text, QueueMode.Flush, new Dictionary<string, string>());
			}
		}

		public void OnInit(OperationResult status)
		{
			if (status == OperationResult.Success) {
				speech.Speak(lastText, QueueMode.Flush, new Dictionary<string,string>());
				lastText = null;
			}
		}
	}
}

