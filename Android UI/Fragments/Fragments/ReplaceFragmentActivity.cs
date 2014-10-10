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

namespace Fragments
{
    [Activity(Label = "Add Fragment")]
    public class ReplaceFragmentActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.ReplaceFragment);

            var replaceFragment = FindViewById<Button>(Resource.Id.replaceFragment);

            replaceFragment.Click += (sender, args) =>
            {

                //TODO: Start a new transaction
using (var transaction = FragmentManager.BeginTransaction())
{
    transaction.SetCustomAnimations(
        Android.Resource.Animator.FadeIn,
        Android.Resource.Animator.FadeOut);
						
    transaction.Replace(Resource.Id.container, new FragmentToAdd());

    transaction.Commit();
}

            };
        }
    }
}