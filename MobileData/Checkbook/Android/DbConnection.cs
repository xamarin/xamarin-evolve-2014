using System;
using Xamarin.Forms;
using MobileData.Android;
using System.IO;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

[assembly: DependencyAttribute(typeof(DbConnection))]

namespace MobileData.Android
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
			path = Path.Combine(path, "..", "databases");

			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);

			Filename = Path.GetFullPath(Path.Combine(path, DbFile));
			//File.Delete(Filename);
			Connection = new SQLiteConnection(new SQLitePlatformAndroid(), Filename);
        }
    }
}

