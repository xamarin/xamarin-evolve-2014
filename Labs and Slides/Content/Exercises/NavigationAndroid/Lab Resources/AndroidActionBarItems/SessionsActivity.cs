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
	/// <summary>
	/// Add an index and fast-scrolling
	/// </summary>
	[Activity (Label = "Sessions", Icon = "@drawable/ic_action_sessions")]
	//	[IntentFilter (new string [] { Intent.ActionMain },	Categories = new string [] { Constants.DemoCategory }) ]
	public class SessionsActivity : ListActivity
	{
		private SessionsAdapter adapter;
		private List<Session> sessions;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			sessions = EvolveData.SessionData;
			adapter = new SessionsAdapter (this, sessions);
			ListView.Adapter = adapter;
			ListView.FastScrollEnabled = true;
		}

		/// <summary>
		/// Demonstrates how to handle a row click
		/// </summary>
		protected override void OnListItemClick (ListView l, View v, int position, long id)
		{
			var title = adapter [position].Title;
			// This is how we start the next screen
			var intent = new Intent (this, typeof(SessionActivity));
			intent.PutExtra ("Title", title);
			StartActivity (intent);
		}
	}
}