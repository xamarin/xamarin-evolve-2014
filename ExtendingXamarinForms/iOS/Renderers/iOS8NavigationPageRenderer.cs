using System;
using Xamarin.Forms;
using MonoTouch.UIKit;
using ExtendingXamarinForms.iOS;
using MonoTouch.ObjCRuntime;
using Xamarin.Forms.Platform.iOS;

//[assembly: ExportRenderer(typeof(NavigationPage), typeof(iOS8NavigationPageRenderer))]

namespace ExtendingXamarinForms.iOS
{
	public class iOS8NavigationPageRenderer : NavigationRenderer
	{
		public iOS8NavigationPageRenderer () : base()
		{
			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) 
				this.HidesBarsOnSwipe = true;
		}
	}
}

