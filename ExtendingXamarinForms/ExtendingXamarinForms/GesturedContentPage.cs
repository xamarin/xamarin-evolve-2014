using System;
using Xamarin.Forms;
using System.ServiceModel;

namespace ExtendingXamarinForms
{
	/// <summary>
	/// Subclass of Content Page. Used to have custom hooks to gestures via Native Renderers. It only works on the 
	/// Page Level, but it should give you an idea how you could apply it elsewhere too
	/// </summary>
	public class GesturedContentPage : ContentPage
	{
		public GesturedContentPage() : base()
		{
		}

		public Action OnSwipeLeftToRight = delegate {};
		public Action OnSwipeRightToLeft = delegate {};
		public Action OnSwipeTopToBottom = delegate {};
		public Action OnSwipeBottomToTop = delegate {};
		public Action OnTap = delegate {};
		public Action OnLongTap = delegate {};

		public bool CaptureSwipeLeftToRight = false;
		public bool CaptureSwipeRightToLeft = false;
		public bool CaptureSwipeTopToBottom = false;
		public bool CaptureSwipeBottomToTop = false;
		public bool CaptureTap = false;
		public bool CaptureLongTap = false;
	}
	
}
