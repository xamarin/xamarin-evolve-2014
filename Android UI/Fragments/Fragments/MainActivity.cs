using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Fragments
{
    [Activity(Label = "Evolve 2014 - Fragments", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class MainActivity : Activity, IDisplayDetail
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //TODO: There is nothing else to do in our activity...controls are provided by the fragment
        }

		#region IDisplayDetail implementation

		public bool CanDisplayDetail {
			get {
				var container = FindViewById<FrameLayout> (Resource.Id.container);
				return container != null && container.Visibility == ViewStates.Visible;
			}
		}

		public void DisplayDetail (Fragment fragmentToDisplay)
		{
			if (fragmentToDisplay == null)
				return;

			using(var transaction = FragmentManager.BeginTransaction ()){
				transaction
					.SetCustomAnimations(Android.Resource.Animator.FadeIn, Android.Resource.Animator.FadeOut)
					.Replace (Resource.Id.container, fragmentToDisplay)
					.Commit ();
			}
		}

		#endregion
    }
}

