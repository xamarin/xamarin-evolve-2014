using System;
using Xamarin.Forms;
using MobileData.iOS;
using System.IO;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;

[assembly: DependencyAttribute(typeof(DbConnection))]

namespace MobileData.iOS
{
	class DbConnection : IDbConnection
    {
		const string DbFile = "checkbook.db";

		public string Filename { get; private set; }
		public SQLiteConnection Connection { get; private set; }

        public DbConnection()
        {
			// Get the filename in the Library folder.
			string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			path = Path.Combine(path, "..", "Library");
			path = Path.Combine(path, DbFile);

			Filename = Path.GetFullPath(path);
			//File.Delete(Filename);
			Connection = new SQLiteConnection(new SQLitePlatformIOS(), Filename);
        }
    }
}

