using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsNavPatterns
{	
	public partial class SessionDetailPage : ContentPage
	{	
		public SessionDetailPage ()
		{
			
		}
		public SessionDetailPage (Session session)
		{
			this.BindingContext = session;
			InitializeComponent ();
		}
	}
}