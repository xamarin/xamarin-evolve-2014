using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Util;
using Android.Content.PM;

namespace com.xamarin.university.mobilenav.android.actionbartabs
{
	[Activity (Label = "@string/app_name", Theme = "@style/Theme.AppCompat", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class MainActivity : ActionBarActivity, ActionBar.ITabListener
	{
		static readonly string Tag = "ActionBarTabs";
		Fragment[] _fragments;

		public void OnTabReselected (ActionBar.Tab tab, FragmentTransaction ft)
		{
			Log.Debug (Tag, "The tab {0} was re-selected.", tab.Text);
		}

		public void OnTabSelected (ActionBar.Tab tab, FragmentTransaction ft)
		{
			SupportFragmentManager.PopBackStack (null, FragmentManager.PopBackStackInclusive);

			Log.Debug (Tag, "The tab {0} has been selected.", tab.Text);
			Fragment frag = _fragments [tab.Position];
			ft.Replace (Resource.Id.content_frame, frag);
		}

		public void OnTabUnselected (ActionBar.Tab tab, FragmentTransaction ft)
		{
			// perform any extra work associated with saving fragment state here.
			Log.Debug (Tag, "The tab {0} as been unselected.", tab.Text);
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SupportActionBar.NavigationMode = ActionBar.NavigationModeTabs;
			SetContentView (Resource.Layout.Main);

			_fragments = new Fragment[] {
				new SessionListFragment (),
				new SpeakerListFragment (),
				new AboutFragment ()
			};

			AddTabToActionBar (Resource.String.sessions_tab_label, Resource.Drawable.ic_action_sessions);
			AddTabToActionBar (Resource.String.speakers_tab_label, Resource.Drawable.ic_action_speakers);
			AddTabToActionBar (Resource.String.about_tab_label, Resource.Drawable.ic_action_whats_on);
		}

		void AddTabToActionBar (int labelResourceId, int iconResourceId)
		{
			ActionBar.Tab tab = SupportActionBar.NewTab ()
                                                .SetText (labelResourceId)
                                                .SetIcon (iconResourceId)
                                                .SetTabListener (this);
			SupportActionBar.AddTab (tab);
		}
	}
}
