using System;

namespace WebServices
{
	/// <summary>
	///     Interface to check connectivity. This is platform specific.
	/// </summary>
	public interface IConnectivityService
	{
		/// <summary>
		/// Sets up a watchdog for connectivity.
		/// </summary>
		/// <param name="connectivityChanged">Gets called if connectivity changed. Passes TRUE if the host is reachabe, FALSE if not.</param>
		void CreateConnectivityWatchDog (Action<bool> connectivityChanged);
	}
}