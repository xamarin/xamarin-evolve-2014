using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsNavPatterns
{	
	public partial class RoomsPage : ContentPage
	{	
		public RoomsPage ()
		{
			var rooms = Repository.GetRooms ();
			this.BindingContext = rooms;

			InitializeComponent ();

			roomsList.ItemTapped += async (sender, e) => {
				var room = e.Item as Room;
				((ListView)sender).SelectedItem = null;
				await this.Navigation.PushAsync(new SessionsPage(room));
			};
		}
	}
}