using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyContacts
{
	public enum Gender { Male, Female };

	public class Person : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = delegate {};

		public string Name { get; set; }
		public string HeadshotUrl { get; set; }
		public string Email { get; set; }

		DateTime dob;
		public DateTime Dob {
			get {
				return dob;
			}
			set {
				if (dob != value) {
					dob = value;
					RaisePropertyChanged();
				}
			}
		}

		public Gender Gender { get; set; }
		public bool IsFavorite { get; set; }

		void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

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

