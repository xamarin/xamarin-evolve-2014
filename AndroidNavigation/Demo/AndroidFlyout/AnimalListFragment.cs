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

namespace com.xamarin.university.mobilenav.android.flyout
{
	internal class AnimalListFragment : ListFragment
	{
		private int _currentAnimalId;

		public override void OnActivityCreated (Bundle savedInstanceState)
		{
			base.OnActivityCreated (savedInstanceState);

			var adapter = new ArrayAdapter<String> (Activity, Android.Resource.Layout.SimpleListItem1, EvolveData.AnimalData.Select (evnt => evnt.Name).ToArray ());
			ListAdapter = adapter;

			if (savedInstanceState != null) {
				_currentAnimalId = savedInstanceState.GetInt ("current_animal_id", 0);
			}
		}

		public override void OnSaveInstanceState (Bundle outState)
		{
			base.OnSaveInstanceState (outState);
			outState.PutInt ("current_animal_id", _currentAnimalId);
		}

		public override void OnListItemClick (ListView l, View v, int position, long id)
		{
			ShowDetails (position);
		}

		private void ShowDetails (int animalId)
		{
			_currentAnimalId = animalId;

			// Check what fragment is shown, replace if needed.
			var details = FragmentManager.FindFragmentById (Resource.Id.content_frame) as AnimalDetailsFragment;
			if (details == null || details.ShownAnimalIndex != animalId) {
				// Make new fragment to show this selection.
				details = AnimalDetailsFragment.NewInstance (animalId);

				// Insert the fragment by replacing any existing fragment
				FragmentManager.BeginTransaction ()
					.Replace (Resource.Id.content_frame, details)
					.AddToBackStack (null)
					.Commit ();
			}
		}
	}
}