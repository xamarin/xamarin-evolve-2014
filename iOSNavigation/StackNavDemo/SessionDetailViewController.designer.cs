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
	[Register ("SessionDetailViewController")]
	partial class SessionDetailViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel sessionTitle { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton speakerName { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (sessionTitle != null) {
				sessionTitle.Dispose ();
				sessionTitle = null;
			}
			if (speakerName != null) {
				speakerName.Dispose ();
				speakerName = null;
			}
		}
	}
}
