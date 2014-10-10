using People.Models;
using SQLite.Net;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;

namespace People
{
    public class PersonRepository
    {
        private SQLiteConnection dbConn;

        public string StatusMessage { get; set; }

        public PersonRepository(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            //add code to initialize a new SQLiteConnection 
	
	    //add code to create the Person table
        }
        
        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                //add code to insert a new person into the Person table

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public List<Person> GetAllPeople()
        {
            //add code to return a list of people saved to the Person table in the database
        }
        
    }
}
