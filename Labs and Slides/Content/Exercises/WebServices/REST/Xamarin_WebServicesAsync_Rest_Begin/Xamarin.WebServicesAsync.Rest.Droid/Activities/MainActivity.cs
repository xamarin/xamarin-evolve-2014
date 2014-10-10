using System;

using Android.App;
using Android.Content;
using Android.OS;

namespace Xamarin.WebServicesAsync.Droid.Activities
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher")]
    public class MainActivity : TabActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			SetContentView(Resource.Layout.main);
			CreateTab(typeof(RestActivity), "REST", Resource.String.activity_rest_label);
			CreateTab(typeof(SoapActivity), "SOAP", Resource.String.activity_soap_label);
        }

        private void CreateTab(Type activityType, string tag, int labelId)
        {
            // Load the string resource for the label
            var label = Resources.GetString(labelId);

            var intent = new Intent(this, activityType);
            intent.AddFlags(ActivityFlags.NewTask);

            var spec = TabHost.NewTabSpec(tag);
			spec.SetIndicator (label);
            spec.SetContent(intent);

            TabHost.AddTab(spec);
        }

    }
}
