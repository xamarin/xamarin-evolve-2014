using Xamarin.Forms;
using System;
using WebServices.Droid;
using Android.Net;
using System.Threading.Tasks;

[assembly:Dependency(typeof(AndroidConnectivityServiceImpl))]

namespace WebServices.Droid
{
	public class AndroidConnectivityServiceImpl : IConnectivityService
    {
        bool reachable = true;
       
		public async void CreateConnectivityWatchDog (Action<bool> connectivityChanged)
		{
			var connectivityManager = (ConnectivityManager)Forms.Context.GetSystemService ("connectivity");
			bool? currentValue = null;

			await Task.Run(async () =>
			{
				while (true)
				{
					await Task.Delay (1000);
					var activeConnection = connectivityManager.ActiveNetworkInfo;

					if ((activeConnection != null) && activeConnection.IsConnected)
					{
						reachable = true;
					}
					else
					{
						reachable = false;
					}

					if (currentValue == null || reachable != currentValue)
					{
						currentValue = reachable;
						connectivityChanged (reachable);
					}
				}
			});
		}



    }
}