using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

namespace FormsNavPatterns
{	
	public partial class SessionsPage : ContentPage
	{	
		private void Initialize(List<Session> sessions)
		{
			InitializeComponent ();

			sessionsList.ItemTapped += async (sender, e) => {
				var session = e.Item as Session;
				((ListView)sender).SelectedItem = null;

				//Navigate to detail screen
				await this.Navigation.PushAsync(new SessionDetailPage(session));
			};
		}

		#region Other Methods
		public SessionsPage ()
		{
			var sessions = Repository.GetSessions ();
			this.BindingContext = sessions;

			Initialize (sessions);
		}

		public SessionsPage (Topic topic)
		{
			var sessions = Repository.GetSessions ().Where(x => x.Topic == topic.Name).ToList();
			this.BindingContext = sessions;

			Initialize (sessions);
		}

		public SessionsPage (Room room)
		{
			var sessions = Repository.GetSessions ().Where(x => x.Room == room.Name).ToList();
			this.BindingContext = sessions;

			Initialize (sessions);
		}

		public SessionsPage (Speaker speaker)
		{
			var sessions = Repository.GetSessions ().Where(x => x.SpeakerName == speaker.Name).ToList();
			this.BindingContext = sessions;

			Initialize (sessions);
		}
		#endregion
	}
}