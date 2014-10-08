using System;
using Xamarin.Forms;
using System.ServiceModel;

namespace ExtendingXamarinForms
{
	public class DisplayCurrentSwipeActionPage : GesturedContentPage
	{
		public DisplayCurrentSwipeActionPage ()
		{
			Title = "Swipe me";

			CaptureSwipeBottomToTop = true;
			CaptureSwipeTopToBottom = true;
			CaptureSwipeLeftToRight = true;
			CaptureSwipeRightToLeft = true;
			CaptureTap = true;
			CaptureLongTap = true;

			var directionDisplay = new Label () {
				Text = "Swipe to Update",
				Font = Font.SystemFontOfSize (30),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
			Content = directionDisplay;

			OnSwipeLeftToRight += () => directionDisplay.Text = "-->";
			OnSwipeRightToLeft += () => directionDisplay.Text = "<--";
			OnSwipeTopToBottom += () => directionDisplay.Text = "\\/";
			OnSwipeBottomToTop += () => directionDisplay.Text = "/\\";
			OnTap += () => directionDisplay.Text = "Tapped";
			OnLongTap += () => directionDisplay.Text = "Long Tap";
		}
	}
}

