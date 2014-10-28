using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Fragments
{
    [Activity(Label = "Send Data to Fragment")]
    public class SendDataToFragmentActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.SendDataToFragment);

			var sendDataToFragment = FindViewById<Button>(Resource.Id.sendDataToFragment);

			sendDataToFragment.Click += (sender, args) =>
            {

                //TODO: Start a new transaction
                using (var transaction = FragmentManager.BeginTransaction())
                {
                    //TODO: use animations to transition between fragments
                    transaction.SetCustomAnimations(
                        Android.Resource.Animator.FadeIn,
                        Android.Resource.Animator.FadeOut);

                    var randomColorValue = new Random();
                    var randomColor = new Color(
                        randomColorValue.Next(0, 255), 
                        randomColorValue.Next(0, 255),
                        randomColorValue.Next(0, 255));

                    var fragmentToAdd = FragmentToAdd.CreateFragmentToAdd(randomColor);


                    //TODO: replace the fragment on click
                    transaction.Replace(Resource.Id.container, fragmentToAdd);

                    //Commit your changes
                    transaction.Commit();
                }

            };
        }
    }
}