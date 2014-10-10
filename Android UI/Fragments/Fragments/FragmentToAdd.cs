using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Fragments
{
	public class FragmentToAdd : Fragment
	{
		private const string
			ArgumentBackgroundColorRed = "ARGUMENT_BACKGROUND_COLOR_RED",
			ArgumentBackgroundColorGreen = "ARGUMENT_BACKGROUND_COLOR_GREEN",
			ArgumentBackgroundColorBlue = "ARGUMENT_BACKGROUND_COLOR_BLUE";

		public Color BackgroundColor {
			get {
				if (Arguments == null)
					return new Color ();

				var red = Arguments.GetInt (ArgumentBackgroundColorRed);
				var green = Arguments.GetInt (ArgumentBackgroundColorGreen);
				var blue = Arguments.GetInt (ArgumentBackgroundColorBlue);

				return new Color (red, green, blue);
			}
		}

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			System.Diagnostics.Debug.WriteLine ("Fragment Created");
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate (Resource.Layout.FragmentToAdd, container, false);

			var currentTime = view.FindViewById<TextView> (Resource.Id.currentTime);
			currentTime.Text = string.Format ("Added: {0}", DateTime.Now.ToLongTimeString ());
			currentTime.SetBackgroundColor (BackgroundColor);

			System.Diagnostics.Debug.WriteLine ("Fragment Layout Created");

			return view;
		}

		public override void OnPause ()
		{
			base.OnPause ();

			System.Diagnostics.Debug.WriteLine ("Fragment Paused");
		}
			
		//TODO: Use a builder method to create a fragment with data passed to it
		public static FragmentToAdd CreateFragmentToAdd (Color backgroundColor)
		{
			var fragmentToAdd = new FragmentToAdd {
				Arguments = new Bundle ()
			};

			fragmentToAdd.Arguments.PutInt (ArgumentBackgroundColorRed, backgroundColor.R);
			fragmentToAdd.Arguments.PutInt (ArgumentBackgroundColorGreen, backgroundColor.G);
			fragmentToAdd.Arguments.PutInt (ArgumentBackgroundColorBlue, backgroundColor.B);

			return fragmentToAdd;
		}
	}
}