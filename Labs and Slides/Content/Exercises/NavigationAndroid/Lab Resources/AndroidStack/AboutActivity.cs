using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Android.Webkit;

namespace com.xamarin.university.mobilenav.android.stack
{
	[Activity (Label = "About")]
	public class AboutActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			
			// set our layout to be the home screen
			this.SetContentView(Resource.Layout.about);
			
			var web = FindViewById<WebView>(Resource.Id.aboutwebview);
			web.LoadUrl("file:///android_asset/about.html");
		}
	}
}

