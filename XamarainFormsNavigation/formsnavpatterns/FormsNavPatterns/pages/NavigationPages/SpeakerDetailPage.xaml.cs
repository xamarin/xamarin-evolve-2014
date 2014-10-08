using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsNavPatterns
{	
	public partial class SpeakerDetailPage : ContentPage
	{	
		public SpeakerDetailPage ()
		{
			InitializeComponent ();

		}

		public SpeakerDetailPage (Speaker speaker)
		{
			this.BindingContext = speaker;
			InitializeComponent ();

			showSessions.Clicked += async (sender, e) => {
				await this.Navigation.PushAsync(new SessionsPage(speaker));
			};
		}
	}
}