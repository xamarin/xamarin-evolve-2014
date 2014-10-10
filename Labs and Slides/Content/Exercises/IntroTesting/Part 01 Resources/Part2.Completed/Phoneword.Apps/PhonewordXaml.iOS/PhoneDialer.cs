using System;
using Phoneword.Core;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Xamarin.Forms;
using PhonewordXaml.iOS;

[assembly: Dependency(typeof(PhoneDialer))]

namespace PhonewordXaml.iOS
{
	public class PhoneDialer : IDialer
	{
		public bool Dial(string number)
		{
			return UIApplication.SharedApplication.OpenUrl(
				new NSUrl("tel:" + number));
		}
	}
}

