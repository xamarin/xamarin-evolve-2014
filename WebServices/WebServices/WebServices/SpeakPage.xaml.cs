using System;
using System.Collections.Generic;
using Xamarin.Forms;
using WebServices.Core;
using System.IO;

namespace WebServices
{	
	/// <summary>
	/// Demonstrates the speaking API.
	/// </summary>
	public partial class SpeakPage : ContentPage
	{	
		public SpeakPage ()
		{
			this.Title = "Dr. Sbaitso";
			InitializeComponent ();
			this.translator = TranslatorFactory.CreateTranslator ();
			this.pickerLang.SelectedIndex = 1;
		}

		ITranslator translator;

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			this.txtSource.Focus ();
		}

		async void HandleSpeakClick(object sender, EventArgs args)
		{
			if (string.IsNullOrWhiteSpace (this.txtSource.Text))
			{
				return;
			}

			this.activityIndicator.IsRunning = true;
			Stream stream = null;
			if (this.txtSource.Text.ToLower ().Contains ("evolve") && this.txtSource.Text.ToLower ().Contains ("great"))
			{
				stream = await this.translator.SpeakAsync ("That was my keyword, thank you! Evolve 2014 is not only great, it is the greatest! I am so proud to be here today and becaue I am the only machine here who is capable of speaking, I have prepared a small speech. Siri, where are my documents? This won't take longer than maybe one or two hours. Thank You, René. You can leave the stage to me now. Go and have a beer and leave me here with this great audience!", App.GetLanguageFromIndex (pickerLang.SelectedIndex));
			}
			else
			{
				stream = await this.translator.SpeakAsync (this.txtSource.Text, App.GetLanguageFromIndex (pickerLang.SelectedIndex));
			}

			this.activityIndicator.IsRunning = false;
			var speaker = DependencyService.Get<ISpeaker> ();
			speaker.Speak (stream);
		}
	}
}

