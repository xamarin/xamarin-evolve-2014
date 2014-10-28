using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Util;
using Android.Content.PM;
using Android.Support.V4.View;

namespace com.xamarin.university.mobilenav.android.actionbartabs
{
	[Activity (Label = "@string/app_name", Theme = "@style/Theme.AppCompat.Light.DarkActionBar", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class MainActivity : ActionBarActivity, ActionBar.ITabListener, ViewPager.IOnPageChangeListener
	{
		static readonly string Tag = "ActionBarTabs";

		TabAdapter tabsAdapter;

		ViewPager content;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);


			SupportActionBar.NavigationMode = ActionBar.NavigationModeTabs;

			SetContentView (Resource.Layout.Main);

			content = FindViewById<ViewPager> (Resource.Id.content_frame);
			content.Adapter = tabsAdapter = new TabAdapter (SupportFragmentManager);
			content.SetOnPageChangeListener (this);


			AddTabToActionBar (Resource.String.events_tab_label, Resource.Drawable.calendar);
			AddTabToActionBar (Resource.String.animals_tab_label, Resource.Drawable.gorilla);
			//AddTabToActionBar (Resource.String.about_tab_label, Resource.Drawable.ic_action_whats_on);
		}


		#region Tabs
		public void OnTabSelected (ActionBar.Tab tab, FragmentTransaction ft)
		{
			SupportFragmentManager.PopBackStack (null, FragmentManager.PopBackStackInclusive);
			content.SetCurrentItem (tab.Position, true);
			Log.Debug (Tag, "The tab {0} as been selected.", tab.Text);
		}

		public void OnTabUnselected (ActionBar.Tab tab, FragmentTransaction ft)
		{
			Log.Debug (Tag, "The tab {0} as been unselected.", tab.Text);
		}

		public void OnTabReselected (ActionBar.Tab tab, FragmentTransaction ft)
		{
			Log.Debug (Tag, "The tab {0} was re-selected.", tab.Text);
		}
		#endregion

		#region View Pager
		public void OnPageScrollStateChanged (int state)
		{
		}

		public void OnPageScrolled (int position, float positionOffset, int positionOffsetPixels)
		{
		}

		public void OnPageSelected (int position)
		{
			SupportActionBar.SetSelectedNavigationItem (position);
		}
		#endregion


		void AddTabToActionBar (int labelResourceId, int iconResourceId)
		{
			ActionBar.Tab tab = SupportActionBar.NewTab ()
                                                .SetText (labelResourceId)
                                                .SetIcon (iconResourceId)
                                                .SetTabListener (this);
			SupportActionBar.AddTab (tab);
		}


		#region Tabs Adapter

		class TabAdapter : FragmentStatePagerAdapter{

			Fragment[] _fragments;

			public TabAdapter(FragmentManager fragmentManager) : base(fragmentManager){

				_fragments = new Fragment[] {
					new EventListFragment (),
					new AnimalListFragment ()
				};
			}

			public override int Count {
				get {
					return _fragments.Length;
				}
			}

			public override Fragment GetItem (int position)
			{
				if (position < 0 ||  position > _fragments.Length - 1)
					return null;

				return _fragments [position];
			}

		}

		#endregion

	}
}
