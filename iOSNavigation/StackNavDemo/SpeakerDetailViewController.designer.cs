// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace StackNavDemo
{
	[Register ("SpeakerDetailViewController")]
	partial class SpeakerDetailViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel speakerName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton viewSessions { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (speakerName != null) {
				speakerName.Dispose ();
				speakerName = null;
			}
			if (viewSessions != null) {
				viewSessions.Dispose ();
				viewSessions = null;
			}
		}
	}
}
