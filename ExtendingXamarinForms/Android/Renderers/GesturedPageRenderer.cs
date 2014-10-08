using System;
using Android.Views;
using ExtendingXamarinForms;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ExtendingXamarinForms.Android;

[assembly: ExportRenderer (typeof (GesturedContentPage), typeof (GesturedPageRenderer))]

namespace ExtendingXamarinForms.Android
{
	public class GesturedPageRenderer : PageRenderer
	{
		public GesturedPageRenderer () : base()
		{

		}

		GestureDetector _gestureDetector;

		GesturedContentPage _page;

		protected override void OnElementChanged (ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged (e);
		
			_page = (e.NewElement) as GesturedContentPage;
			_gestureDetector = new GestureDetector (new InternalGestureCapture (_page));
		}

		public override bool OnTouchEvent (MotionEvent e)
		{
			base.OnTouchEvent (e);

			_gestureDetector.OnTouchEvent(e);

			return true;
		}

		public class InternalGestureCapture : Java.Lang.Object, GestureDetector.IOnGestureListener
		{
			const int MinSwipeDistance = 120;
			const int MaxSwipeOffPath = 250;
			const int SwipeThreadsholdVelocity = 200;

			GesturedContentPage _page;

			public InternalGestureCapture(GesturedContentPage page)
			{
				_page = page;
			}

			public bool OnDown (MotionEvent e)
			{
				return true;
			}

			public bool OnFling (MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
			{
				// Right to left swipe
				if (e1.GetX() - e2.GetX() > MinSwipeDistance
					&& Math.Abs(velocityX) > SwipeThreadsholdVelocity) {
					if (_page.CaptureSwipeRightToLeft)
						_page.OnSwipeRightToLeft ();
				} 
				// Left to right swipe
				else if (e2.GetX() - e1.GetX() > MinSwipeDistance
					&& Math.Abs(velocityX) > SwipeThreadsholdVelocity) {
					if (_page.CaptureSwipeLeftToRight)
						_page.OnSwipeLeftToRight ();
				}

				if (e1.GetY() - e2.GetY() > MinSwipeDistance
					&& Math.Abs(velocityY) > SwipeThreadsholdVelocity) {
					if (_page.CaptureSwipeBottomToTop)
						_page.OnSwipeBottomToTop ();
				} 
				// Left to right swipe
				else if (e2.GetY() - e1.GetY() > MinSwipeDistance
					&& Math.Abs(velocityY) > SwipeThreadsholdVelocity) {
					if (_page.CaptureSwipeTopToBottom)
						_page.OnSwipeTopToBottom ();
				}

				return true;
			}

			public bool OnSingleTapUp (MotionEvent e)
			{
				if (_page.CaptureTap)
					_page.OnTap ();

				return true;
			}

			public void OnLongPress (MotionEvent e)
			{
				if (_page.CaptureLongTap)
					_page.OnLongTap ();
			}

			public bool OnScroll (MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
			{
				return false;
			}

			public void OnShowPress (MotionEvent e)
			{

			}
		}
	}
}

