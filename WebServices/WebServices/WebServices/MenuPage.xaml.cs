using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace WebServices
{	
	public partial class MenuPage : ContentPage
	{	
		public MenuPage ()
		{
			InitializeComponent ();
			this.Title = "Web Services";
		}

		void HandleMenuClick(object sender, EventArgs args)
		{
			if (sender == this.btnTranslatePage)
			{
				this.Navigation.PushAsync (new TranslatePage());
			}
			else if (sender == this.btnDetectLanguagePage)
			{
				this.Navigation.PushAsync (new DetectLanguagePage());
			}
			else if (sender == this.btnSpeakPage)
			{
				this.Navigation.PushAsync (new SpeakPage());
			}
		}
	}
}

