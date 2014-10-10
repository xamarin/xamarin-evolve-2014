using System;
using SQLite;

namespace TheBestAppEver
{
	public class Person
	{
		public Person ()
		{
		}
		[PrimaryKeyAttribute, AutoIncrement]
		public int Id {get;set;}
		public string FirstName {get;set;}

		public string MiddleName { get; set; }

		[Indexed]
		public string LastName {get;set;}

		[Indexed]
		public string IndexCharacter { get; set; }

		public string Email { get; set; }

		public string PhoneNumber {get;set;}

		public override string ToString ()
		{
			return string.Format ("{0} , {1}",  LastName, FirstName);
		}
	}
}

