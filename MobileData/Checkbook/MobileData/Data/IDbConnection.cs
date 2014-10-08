using SQLite.Net;

namespace MobileData
{
	public interface IDbConnection
	{
		/// <summary>
		/// The filename we are using to store the local DB.
		/// </summary>
		/// <value>The filename.</value>
		string Filename { get; }

		/// <summary>
		/// The platform-specific connection created for iOS or Android
		/// </summary>
		/// <value>The connection.</value>
		SQLiteConnection Connection { get; }
	}
    
}
