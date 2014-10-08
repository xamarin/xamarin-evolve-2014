using SQLite.Net;
using Xamarin.Forms;
using System.Diagnostics;
using MobileData;

namespace MobileData
{
    public class CheckRepository
    {
		readonly IDbConnection db;

		public CheckRepository()
        {
			// Retrieve the platform dependency.
			this.db = DependencyService.Get<IDbConnection>();
			Debug.Assert(db != null);

			// Create the Checks table, ignored if it exists already.
			db.Connection.CreateTable<Check>();
        }

		public TableQuery<Check> AllChecks
		{
			get { 
				return db.Connection.Table<Check>(); //.Where(cw => cw.Cleared);
			}
		}

		public void Add(Check check) 
		{
			db.Connection.Insert(check);
		}

		public void Delete(Check check)
		{
			db.Connection.Delete(check);
		}

		public void Update(Check check)
		{
			db.Connection.Update(check);
		}
    }
}

