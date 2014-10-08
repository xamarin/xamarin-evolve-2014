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

namespace FileTransfer
{
	[Register ("DownloaderCell")]
	partial class DownloaderCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnDownload { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnStop { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblFilename { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIProgressView progressView { get; set; }

		[Action ("HandleStartDownload:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void HandleStartDownload (UIButton sender);

		[Action ("HandleStopDownload:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void HandleStopDownload (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnDownload != null) {
				btnDownload.Dispose ();
				btnDownload = null;
			}
			if (btnStop != null) {
				btnStop.Dispose ();
				btnStop = null;
			}
			if (lblFilename != null) {
				lblFilename.Dispose ();
				lblFilename = null;
			}
			if (progressView != null) {
				progressView.Dispose ();
				progressView = null;
			}
		}
	}
}
