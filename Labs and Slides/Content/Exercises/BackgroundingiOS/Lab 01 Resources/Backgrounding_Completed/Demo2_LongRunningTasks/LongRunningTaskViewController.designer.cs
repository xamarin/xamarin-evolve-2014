// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace Demo2LongRunningTasks
{
	[Register ("LongRunningTaskViewController")]
	partial class LongRunningTaskViewController
	{
		[Outlet]
		[GeneratedCodeAttribute ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIButton TaskButton { get; set; }

		[Outlet]
		[GeneratedCodeAttribute ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITextView TaskLogText { get; set; }

		[Action ("OnStartTask:")]
		[GeneratedCodeAttribute ("iOS Designer", "1.0")]
		partial void OnStartTask (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (TaskButton != null) {
				TaskButton.Dispose ();
				TaskButton = null;
			}
			if (TaskLogText != null) {
				TaskLogText.Dispose ();
				TaskLogText = null;
			}
		}
	}
}
