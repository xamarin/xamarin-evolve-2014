using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using SQLite.Net.Interop;

namespace People
{
    public class App
    {
        public static PersonRepository PersonRepo { get; private set; }
        public static Page GetMainPage(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            //set database path first, then retrieve main page
            PersonRepo = new PersonRepository(sqlitePlatform, dbPath);

            return new MainPage();
        }
    }
}
