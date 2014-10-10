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
using Android.Graphics;

namespace Fragments
{
	class NavigationFragment : Fragment
	{
		private Button addFragmentViaCode, replaceFragment, sendDataToFragment;

		//TODO: Setup View for fragment
		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate (Resource.Layout.Navigation, null);

			addFragmentViaCode = view.FindViewById<Button> (Resource.Id.addFragmentViaCode);
			replaceFragment = view.FindViewById<Button> (Resource.Id.replaceFragment);
			sendDataToFragment = view.FindViewById<Button> (Resource.Id.sendDataToFragment);

			return view;
		}

		//TODO: We can leverage lifecycle methods just like an activity
		public override void OnResume ()
		{
			base.OnResume ();

			addFragmentViaCode.Click += AddFragmentViaCodeOnClick;
			replaceFragment.Click += ReplaceFragmentOnClick;
			sendDataToFragment.Click += SendDataToFragmentOnClick;
		}

		public override void OnPause ()
		{
			base.OnPause ();

			addFragmentViaCode.Click -= AddFragmentViaCodeOnClick;
			replaceFragment.Click -= ReplaceFragmentOnClick;
			sendDataToFragment.Click -= SendDataToFragmentOnClick;
		}

		private void AddFragmentViaCodeOnClick (object sender, EventArgs eventArgs)
		{
			var displayDetailActivity = Activity as IDisplayDetail;

			if (displayDetailActivity != null && displayDetailActivity.CanDisplayDetail)
				displayDetailActivity.DisplayDetail (new FragmentToAdd ());
			else
				StartActivity (new Intent (this.Activity, typeof(AddFragmentActivity)));
		}

		private void ReplaceFragmentOnClick (object sender, EventArgs eventArgs)
		{
			var displayDetailActivity = Activity as IDisplayDetail;

			if (displayDetailActivity != null && displayDetailActivity.CanDisplayDetail)
				displayDetailActivity.DisplayDetail (new FragmentToAdd ());
			else
				StartActivity (new Intent (this.Activity, typeof(ReplaceFragmentActivity)));
		}

		private void SendDataToFragmentOnClick (object sender, EventArgs eventArgs)
		{
			var displayDetailActivity = Activity as IDisplayDetail;

			if (displayDetailActivity != null && displayDetailActivity.CanDisplayDetail) {

				var randomColorValue = new Random ();
				var randomColor = new Color (
					                  randomColorValue.Next (0, 255), 
					                  randomColorValue.Next (0, 255),
					                  randomColorValue.Next (0, 255));

				displayDetailActivity.DisplayDetail (FragmentToAdd.CreateFragmentToAdd (randomColor));
			} else
				StartActivity (new Intent (this.Activity, typeof(SendDataToFragmentActivity)));
		}

	}
}