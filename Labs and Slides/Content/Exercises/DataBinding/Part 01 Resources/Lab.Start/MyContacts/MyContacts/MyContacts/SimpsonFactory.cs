using System;
using System.Collections.Generic;

namespace MyContacts
{
	public enum Gender { Male, Female };

	public class Person
	{
		public string Name { get; set; }
		public string HeadshotUrl { get; set; }
		public string Email { get; set; }
		public DateTime Dob { get; set; }
		public Gender Gender { get; set; }
		public bool IsFavorite { get; set; }

		public override string ToString()
		{
			return string.Format("Name={0}, Email={1}, Dob={2}, Gender={3}, IsFavorite={4}", 
                this.Name, this.Email, this.Dob, this.Gender, this.IsFavorite);
		}
	}

    public static class SimpsonFactory
    {
		public static Person GetPerson()
		{
			return new Person { 
				Name = "Homer Simpson", 
				HeadshotUrl = "Homer.gif", 
				Email = "donutlover@aol.com", 
				Dob = new DateTime(1965, 1, 24),
				Gender = Gender.Male,
				IsFavorite = false,
			};
		}
    }
}

