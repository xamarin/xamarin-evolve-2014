using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace FileTransfer
{
	/// <summary>
	/// Delegate for file previews.
	/// </summary>
	public class PreviewDelegate : UIDocumentInteractionControllerDelegate
	{
		public PreviewDelegate (UIViewController controller)
		{
			this.controller = controller;	
		}

		UIViewController controller;

		public override UIViewController ViewControllerForPreview (UIDocumentInteractionController controller)
		{
			return this.controller;
		}
	}

}
