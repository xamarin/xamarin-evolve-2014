using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Evolve.Core;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentActivity = Android.Support.V4.App.FragmentActivity;

namespace com.xamarin.university.mobilenav.android.flyout
{
	[Activity (Label = "@string/app_name", Theme = "@style/Theme.AppCompat.Light.DarkActionBar", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, Icon = "@drawable/ic_launcher")]
	public class MainActivity : ActionBarActivity, IFragmentNavigation
	{
		static readonly string Tag = "Flyout";
		DrawerLayout drawerLayout;
		ActionBarDrawerToggle drawerToggle;
		ListView drawerList;
		static string[] sections = new[] { "Events", "Animals" };

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			drawerLayout = FindViewById<DrawerLayout> (Resource.Id.drawer_layout);
			drawerLayout.SetDrawerShadow (Resource.Drawable.drawer_shadow, (int)GravityFlags.Start);
			drawerList = FindViewById<ListView> (Resource.Id.flyout);
			drawerList.Adapter = new ArrayAdapter<string> (this, Resource.Layout.drawer_list_item, sections);

			drawerToggle = new ActionBarDrawerToggle (this, 
				drawerLayout, Resource.Drawable.ic_drawer, 
				Resource.String.drawer_open, Resource.String.drawer_close);

			drawerLayout.SetDrawerListener (drawerToggle);

			drawerList.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => ListItemClicked (e.Position);
			ListItemClicked (0);

			ActionBar.SetDisplayHomeAsUpEnabled (true);
			ActionBar.SetHomeButtonEnabled (true);
		}

		void ListItemClicked (int position)
		{
			SupportFragmentManager.PopBackStack (null, (int)PopBackStackFlags.Inclusive);

			Log.Debug (Tag, "Item {0} has been selected.", position);

			Fragment fragment = null;
			switch (position) {
			case 0:
				fragment = new EventListFragment ();
				break;
			case 1:
				fragment = new AnimalListFragment ();
				break;
			case 2:
				fragment = new AboutFragment ();
				break;
			}

			// Insert the fragment by replacing any existing fragment
			SupportFragmentManager.BeginTransaction ()
				.Replace (Resource.Id.content_frame, fragment)
				.Commit ();

			// Highlight the selected item, update the title, and close the drawer
			drawerList.SetItemChecked (position, true);
			SupportActionBar.Title = sections [position];
			drawerLayout.CloseDrawer (drawerList);
		}

		protected override void OnPostCreate (Bundle savedInstanceState)
		{
			base.OnPostCreate (savedInstanceState);
			drawerToggle.SyncState ();
		}

		public override void OnConfigurationChanged (Configuration newConfig)
		{
			base.OnConfigurationChanged (newConfig);
			drawerToggle.OnConfigurationChanged (newConfig);
		}


		// Pass the event to ActionBarDrawerToggle, if it returns
		// true, then it has handled the app icon touch event
		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			if (drawerToggle.DrawerIndicatorEnabled && drawerToggle.OnOptionsItemSelected (item))
				return true;

			return base.OnOptionsItemSelected (item);
		}

		public override bool OnPrepareOptionsMenu (IMenu menu)
		{
			var drawerOpen = drawerLayout.IsDrawerOpen (drawerList);
			//when open don't show anything
			for (int i = 0; i < menu.Size (); i++)
				menu.GetItem (i).SetVisible (!drawerOpen);

			return base.OnPrepareOptionsMenu (menu);
		}


		#region IFragmentNavigation implementation

		public void ShowUpNavigation ()
		{
			drawerToggle.DrawerIndicatorEnabled = false;
		}

		#endregion
	}
}


