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
using Evolve.Core;

namespace com.xamarin.university.mobilenav.android.actionbaritems
{
	[Activity (Label = "Speakers", Icon = "@drawable/ic_action_speakers")]
	//	[IntentFilter (new string [] { Intent.ActionMain },
//	Categories = new string [] { Constants.DemoCategory })]
	public class SpeakersActivity : ListActivity
	{
		private SpeakersAdapter adapter;
		private List<Speaker> speakers;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			speakers = EvolveData.SpeakerData;
			adapter = new SpeakersAdapter (this, speakers);
			ListView.Adapter = adapter;

			ListView.FastScrollEnabled = true;
		}

		/// <summary>
		/// Demonstrates how to handle a row click
		/// </summary>
		protected override void OnListItemClick (ListView l, View v, int position, long id)
		{
			var speakerName = adapter [position].Name;
			// This is how we start the next screen
			var intent = new Intent (this, typeof(SpeakerActivity));
			intent.PutExtra ("Name", speakerName);
			StartActivity (intent);
		}
	}
}