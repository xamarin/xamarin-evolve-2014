using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Evolve.Core;

namespace com.xamarin.university.mobilenav.android.stack
{
	[Activity (Label = "Speakers", Icon = "@drawable/ic_action_speakers")]
	public class SpeakersActivity : FragmentActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.speakers_screen);
		}
	}
}