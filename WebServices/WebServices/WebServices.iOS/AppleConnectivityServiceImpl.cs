using MonoTouch.CoreFoundation;
using MonoTouch.SystemConfiguration;
using Xamarin.Forms;
using System;
using WebServices.iOS;
using System.Threading.Tasks;

[assembly:Dependency(typeof(AppleConnectivityServiceImpl))]

namespace WebServices.iOS
{
	public class AppleConnectivityServiceImpl : IConnectivityService
    {
        bool reachable = true;
        NetworkReachability remoteHostReachability;
		Action<bool> connectivityChanged;

		public void CreateConnectivityWatchDog (Action<bool> connectivityChanged)
		{
			this.connectivityChanged = connectivityChanged;

			if (remoteHostReachability == null)
			{
				if (remoteHostReachability != null)
				{
					remoteHostReachability.Unschedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
				}

				// Create new instance if host address changed.
				remoteHostReachability = new NetworkReachability(new System.Net.IPAddress(0));
				remoteHostReachability.SetNotification(HandleReachabilityChanged);
				remoteHostReachability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
			}

			// Trigger callback.
			if (this.connectivityChanged != null)
			{
				this.connectivityChanged (true);
			}
		}


		private void HandleReachabilityChanged(NetworkReachabilityFlags flags)
        {
			Console.WriteLine (flags);
            var requiresConnection = (flags & NetworkReachabilityFlags.ConnectionRequired) > 0;
            // It's reachable if Reachable flag is set and no connection is required.
            reachable = !requiresConnection && (flags & NetworkReachabilityFlags.Reachable) > 0;

			// Trigger callback.
			if (this.connectivityChanged != null)
			{
				this.connectivityChanged (reachable);
			}
        }
    }
}