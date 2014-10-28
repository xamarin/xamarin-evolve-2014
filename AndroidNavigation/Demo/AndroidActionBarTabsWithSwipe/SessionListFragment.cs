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
	internal class EventListFragment : ListFragment
	{
		private int _currentEventId;

		public override void OnActivityCreated (Bundle savedInstanceState)
		{
			base.OnActivityCreated (savedInstanceState);

			var adapter = new ArrayAdapter<String> (Activity, Android.Resource.Layout.SimpleListItem1, EvolveData.EventData.Select (evnt => evnt.Title).ToArray ());
			ListAdapter = adapter;

			if (savedInstanceState != null) {
				_currentEventId = savedInstanceState.GetInt ("current_event_id", 0);
			}
		}

		public override void OnSaveInstanceState (Bundle outState)
		{
			base.OnSaveInstanceState (outState);
			outState.PutInt ("current_event_id", _currentEventId);
		}

		public override void OnListItemClick (ListView l, View v, int position, long id)
		{
			ShowDetails (position);
		}

		private void ShowDetails (int eventId)
		{
			_currentEventId = eventId;

			// Check what fragment is shown, replace if needed.
			var details = FragmentManager.FindFragmentById (Resource.Id.content_frame) as EventDetailsFragment;
			if (details == null || details.ShownEventIndex != eventId) {
				// Make new fragment to show this selection.
				details = EventDetailsFragment.NewInstance (eventId);

				// Insert the fragment by replacing any existing fragment
				FragmentManager.BeginTransaction ()
					.Replace (Resource.Id.content_frame, details)
					.AddToBackStack (null)
					.Commit ();
			}
		}
	}
}