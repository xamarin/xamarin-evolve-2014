using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsNavPatterns
{	
	public partial class SponsorDetailPage : ContentPage
	{	
		public SponsorDetailPage ()
		{
			
		}
		public SponsorDetailPage (Sponsor sponsor)
		{
			this.BindingContext = sponsor;
			InitializeComponent ();
		}
	}
}