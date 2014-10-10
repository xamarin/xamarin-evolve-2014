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

namespace com.xamarin.university.mobilenav.android.actionbaritems
{
	/// <summary>
	/// This is a pre-built single-Speaker display screen, to demonstrate 
	/// starting a new activity with an Intent. It's not really part of the
	/// ListView training per se.
	/// </summary>
	[Activity (Label = "Speaker", Icon = "@drawable/ic_action_speakers")]
	public class SpeakerActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.speaker_screen);

			var name = Intent.Extras.GetString ("Name");

			FindViewById<TextView> (Resource.Id.speakerNameTextView).Text = name;
			// Exercise: populate the other fields :)
			// you could pass them all via PutString and GetString, 
			// or look up the Speaker data again from this method
		}
	}
}