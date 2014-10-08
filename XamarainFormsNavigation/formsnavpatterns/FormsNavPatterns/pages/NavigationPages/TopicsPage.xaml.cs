using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsNavPatterns
{	
	public partial class TopicsPage : ContentPage
	{	
		public TopicsPage ()
		{
			var topics = Repository.GetTopics ();
			this.BindingContext = topics;

			InitializeComponent ();

			topicsList.ItemTapped += async (sender, e) => {
				var topic = e.Item as Topic;
				((ListView)sender).SelectedItem = null;
				await this.Navigation.PushAsync(new SessionsPage(topic));
			};
		}
	}
}