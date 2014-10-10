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

namespace com.xamarin.university.mobilenav.android.stack
{
	internal class SpeakerListFragment : ListFragment
	{
		private int _currentSpeakerId;
		private bool _isDualPane;

		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState);

			var detailsFrame = Activity.FindViewById<View>(Resource.Id.details);

			// If running on a tablet, then the layout in Resources/layout-large will be loaded. 
			// That layout uses fragments, and defines the detailsFrame. We use the visiblity of 
			// detailsFrame as this distinguisher between tablet and phone.
			_isDualPane = detailsFrame != null && detailsFrame.Visibility == ViewStates.Visible;

			var adapter = new ArrayAdapter<String>(Activity, Android.Resource.Layout.SimpleListItemChecked, EvolveData.SpeakerData.Select(speaker => speaker.Name).ToArray());
			ListAdapter = adapter;

			if (savedInstanceState != null)
			{
				_currentSpeakerId = savedInstanceState.GetInt("current_speaker_id", 0);
			}

			if (_isDualPane)
			{
				ListView.ChoiceMode = ChoiceMode.Single;
				ShowDetails(_currentSpeakerId);
			}
		}

		public override void OnSaveInstanceState(Bundle outState)
		{
			base.OnSaveInstanceState(outState);
			outState.PutInt("current_speaker_id", _currentSpeakerId);
		}

		public override void OnListItemClick(ListView l, View v, int position, long id)
		{
			ShowDetails(position);
		}

		private void ShowDetails(int speakerId)
		{
			_currentSpeakerId = speakerId;
			if (_isDualPane)
			{
				// We can display everything in-place with fragments.
				// Have the list highlight this item and show the data.
				ListView.SetItemChecked(speakerId, true);

				// Check what fragment is shown, replace if needed.
				var details = FragmentManager.FindFragmentById(Resource.Id.details) as SpeakerDetailsFragment;
				if (details == null || details.ShownSpeakerIndex != speakerId)
				{
					// Make new fragment to show this selection.
					details = SpeakerDetailsFragment.NewInstance(speakerId);

					// Execute a transaction, replacing any existing
					// fragment with this one inside the frame.
					var ft = FragmentManager.BeginTransaction();
					ft.Replace(Resource.Id.details, details);
					ft.SetTransition(FragmentTransaction.TransitFragmentFade);
					ft.Commit();
				}
			}
			else
			{
				// Otherwise we need to launch a new activity to display
				// the dialog fragment with selected text.
				var intent = new Intent();

				intent.SetClass(Activity, typeof (SpeakerDetailsActivity));
				intent.PutExtra("current_speaker_id", speakerId);
				StartActivity(intent);
			}
		}
	}
}