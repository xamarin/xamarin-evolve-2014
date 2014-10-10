using Android.App;
using Android.OS;
using Android.Util;

namespace Demo1Lifecycle
{
	[Activity(Label = "MemoryEaterActivity")]			
	public class MemoryEaterActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			Log.Debug("MemoryEater", "OnCreate called");
		}

		protected override void OnStart()
		{
			Log.Debug("MemoryEater", "OnStart called - allocating memory.");

			base.OnStart();

			var ii = new int[1000000000];
			ii[0] = 10;
		}
	}
}

