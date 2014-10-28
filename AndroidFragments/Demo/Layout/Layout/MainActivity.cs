using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Layout
{
    [Activity(Label = "Layout", MainLauncher = true, Icon = "@drawable/ic_launcher")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.LayoutWithPixels);

            //SetContentView(Resource.Layout.LinearLayoutWithWeight);

            //SetContentView(Resource.Layout.RelativeLayout);
        }
    }
}

