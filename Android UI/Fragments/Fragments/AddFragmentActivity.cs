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
    public class AddFragmentActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.AddFragment);

			//TODO: Start a new transaction
			using (var transaction = FragmentManager.BeginTransaction())
			{
			    //TODO: use the fragment transaction to replace the current fragment with the one specified
			    transaction.Add(Resource.Id.container, new FragmentToAdd());

			    //Commit your changes
			    transaction.Commit();
			}
        }
    }
}