using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Telephony;
using Phoneword.Core;
using Xamarin.Forms;
using PhonewordXaml.Droid;

[assembly: Dependency(typeof(PhoneDialer))]

namespace PhonewordXaml.Droid
{
	public class PhoneDialer : IDialer
	{
		public static Activity Activity { get; set; }

		public bool Dial(string number)
		{
			if (Activity == null)
				return false;

			var intent = new Intent(Intent.ActionCall);
			intent.SetData(Android.Net.Uri.Parse("tel:" + number));

			if (IsIntentAvailable(Activity, intent)) {
				Activity.StartActivity(intent);
				return true;
			}

			return false;
		}

		public static bool IsIntentAvailable(Context context, Intent intent)
		{
			var packageManager = context.PackageManager;

			var list = packageManager.QueryIntentServices(intent, 0)
				.Union(packageManager.QueryIntentActivities(intent, 0));
			if (list.Any())
				return true;

			var mgr = TelephonyManager.FromContext(context);
			return mgr.PhoneType != PhoneType.None;
		}
	}

}

