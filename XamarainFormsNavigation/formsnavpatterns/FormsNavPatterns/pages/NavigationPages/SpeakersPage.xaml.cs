using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsNavPatterns
{	
	public partial class SpeakersPage : ContentPage
	{	
		public SpeakersPage ()
		{
			var speakers = Repository.GetSpeakers ();
			this.BindingContext = speakers;

			InitializeComponent ();

			speakersList.ItemTapped += async (sender, e) => {
				var speaker = e.Item as Speaker;
				((ListView)sender).SelectedItem = null;
				await this.Navigation.PushAsync(new SpeakerDetailPage(speaker));
			};
		}
	}
}