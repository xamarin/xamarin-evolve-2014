using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ExtendingXamarinForms
{	
	public partial class SaySomethingPage : ContentPage
	{	
		public SaySomethingPage ()
		{
			InitializeComponent ();
		}

		void SayTheText(object sender, EventArgs e)
		{
			var speech = DependencyService.Get<ITextToSpeech> ();
			speech.Speak (TextToSay.Text);
		}
	}
}

