using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace WebServices
{
	public partial class ConnectivityView : ContentView
	{
		public ConnectivityView ()
		{
			InitializeComponent ();
		}

		public bool HasConnectivity {
			get
			{
				return this.hasConnectivity;
			}
			set
			{ 
				this.hasConnectivity = value;
				Device.BeginInvokeOnMainThread (() =>
				{
					this.connectivityIndicator.IsVisible = !hasConnectivity;
					this.connectivityIndicator.HeightRequest = value ? 0 : 50;
				});

			}
		}
		bool hasConnectivity;
	}
}

