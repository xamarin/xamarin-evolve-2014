using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;

namespace PerfDemoGC
{
	public class MyImageView : ImageView
	{
		#region ctors

		public MyImageView (Context context) : base (context)
		{
		}

		public MyImageView (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer)
		{
			
		}

		public MyImageView (Context context, IAttributeSet attrs) : base (context, attrs)
		{
			
		}

		public MyImageView (Context context, IAttributeSet attrs, int defStyle) : base (context, attrs, defStyle)
		{

		}

		#endregion

		protected override void Dispose (bool disposing)
		{
			base.Dispose (disposing);
			Log.Debug ("----MyImageView----", string.Format ("MyImageView is being disposed({0})", disposing));
		}
	}
}