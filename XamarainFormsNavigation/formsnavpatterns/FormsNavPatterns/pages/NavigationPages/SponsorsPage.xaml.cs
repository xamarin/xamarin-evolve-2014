using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsNavPatterns
{	
	public partial class SponsorsPage : ContentPage
	{	
		public SponsorsPage ()
		{
			var sponsors = Repository.GetSponsors ();
			this.BindingContext = sponsors;

			InitializeComponent ();

			sponsorsList.ItemTapped += async (sender, e) => {
				var sponsor = e.Item as Sponsor;
				((ListView)sender).SelectedItem = null;
				await this.Navigation.PushAsync(new SponsorDetailPage(sponsor));
			};
		}
	}
}