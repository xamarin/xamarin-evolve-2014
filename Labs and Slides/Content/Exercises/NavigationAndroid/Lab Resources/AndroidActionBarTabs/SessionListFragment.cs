using System;
using System.Linq;
using Android.OS;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Content;
using Evolve.Core;
using ListFragment = Android.Support.V4.App.ListFragment;

namespace com.xamarin.university.mobilenav.android.actionbartabs
{
	internal class SessionListFragment : ListFragment
	{
		private int _currentSessionId;

		public override void OnActivityCreated (Bundle savedInstanceState)
		{
			base.OnActivityCreated (savedInstanceState);

			var adapter = new ArrayAdapter<String> (Activity, Android.Resource.Layout.SimpleListItem1, EvolveData.SessionData.Select (session => session.Title).ToArray ());
			ListAdapter = adapter;

			if (savedInstanceState != null) {
				_currentSessionId = savedInstanceState.GetInt ("current_session_id", 0);
			}
		}

		public override void OnSaveInstanceState (Bundle outState)
		{
			base.OnSaveInstanceState (outState);
			outState.PutInt ("current_session_id", _currentSessionId);
		}

		public override void OnListItemClick (ListView l, View v, int position, long id)
		{
			ShowDetails (position);
		}

		private void ShowDetails (int sessionId)
		{
			_currentSessionId = sessionId;

			// Check what fragment is shown, replace if needed.
			var details = FragmentManager.FindFragmentById (Resource.Id.content_frame) as SessionDetailsFragment;
			if (details == null || details.ShownSessionIndex != sessionId) {
				// Make new fragment to show this selection.
				details = SessionDetailsFragment.NewInstance (sessionId);

				// Insert the fragment by replacing any existing fragment
				FragmentManager.BeginTransaction ()
					.Replace (Resource.Id.content_frame, details)
					.AddToBackStack (null)
					.Commit ();
			}
		}
	}
}