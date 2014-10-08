using System.Collections.Generic;
using System.Linq;

namespace NavPatterns.Core
{
	public static class Repository
	{
		public static List<Session> GetSessions ()
		{
			var sessions = new List<Session> { 
				new Session {
					Title = "Kickoff Session",
					Topic = "General",
					SpeakerName = "Nat Friedman",
				},
				new Session {
					Title = "Developing Mobile Applications",
					Topic = "Fundamentals",
					SpeakerName = "Mark Smith",
				},
				new Session {
					Title = "Intro to Testing / Unit Testing",
					Topic = "Glenn Stephens",
					SpeakerName = "Testing",
				},
				new Session {
					Title = "Intro to Xamarin.Forms",
					Topic = "Xamarin.Forms",
					SpeakerName = "René Ruppert",
				},
				new Session {
					Title = "Intro to Xamarin.Forms",
					Topic = "Xamarin.Forms",
					SpeakerName = "Rob Gibbens",
				},
				new Session {
					Title = "Introduction to Xamarin.Forms",
					Topic = "Fundamentals",
					SpeakerName = "René Ruppert",
				},
				new Session {
					Title = "Writing Xamarin.UI Tests",
					Topic = "Testing",
					SpeakerName = "Chris van Wyk",
				},
				new Session {
					Title = "XAML in Xamarin.Forms",
					Topic = "Xamarin.Forms",
					SpeakerName = "Mark Smith",
				},
				new Session {
					Title = "Intro to Cross-platform Mobile Development",
					Topic = "Fundamentals",
					SpeakerName = "Mark Smith",
				},
				new Session {
					Title = "Workshop - Testing",
					Topic = "Testing",
					SpeakerName = "Xamarin Training Staff",
				},
				new Session {
					Title = "Data Binding in Xamarin.Forms",
					Topic = "Xamarin.Forms",
					SpeakerName = "Chris van Wyk",
				},
				new Session {
					Title = "Workshop - Fundamentals",
					Topic = "Fundamentals",
					SpeakerName = "Xamarin Training Staff",
				},
				new Session {
					Title = "Publishing to Test Cloud",
					Topic = "Testing",
					SpeakerName = "Glenn Stephens",
				},
				new Session {
					Title = "Xamarin.Forms Navigation",
					Topic = "Xamarin.Forms",
					SpeakerName = "Rob Gibbens",
				},
				new Session {
					Title = "XAML in Xamarin.Forms",
					Topic = "Fundamentals",
					SpeakerName = "Mark Smith",
				},
				new Session {
					Title = "Continuous Integration with Test Cloud",
					Topic = "Testing",
					SpeakerName = "Tom Opgenorth",
				},
				new Session {
					Title = "Extending Xamarin.Forms",
					Topic = "Xamarin.Forms",
					SpeakerName = "Glenn Stephens",
				},
				new Session {
					Title = "Extending Xamarin.Forms",
					Topic = "Xamarin.Forms",
					SpeakerName = "Rob Gibbens",
				},
				new Session {
					Title = "Data Binding in Xamarin.Forms",
					Topic = "Fundamentals",
					SpeakerName = "Chris van Wyk",
				},
				new Session {
					Title = "Publishing an App",
					Topic = "Testing",
					SpeakerName = "Adrian Stevens",
				},
				new Session {
					Title = "Localization",
					Topic = "Xamarin.Forms",
					SpeakerName = "Craig Dunn",
				},

			};

			return sessions.OrderBy (x => x.Title).ToList ();
		}

		public static List<Speaker> GetSpeakers ()
		{
			var sessions = GetSessions ();
			var speakers = sessions.GroupBy (x => x.SpeakerName).Select (x => new Speaker { Name = x.Key }).OrderBy (x => x.Name).ToList ();
			return speakers;

		}

		public static List<Topic> GetTopics ()
		{
			var sessions = GetSessions ();
			var topics = sessions.GroupBy (x => x.Topic).Select (x => new Topic { Name = x.Key }).OrderBy (x => x.Name).ToList ();
			return topics;

		}

		public static List<Sponsor> GetSponsors ()
		{
			return new List<Sponsor> { 
				new Sponsor {
					Name = "Microsoft"
				},
				new Sponsor {
					Name = "IBM"
				},
				new Sponsor {
					Name = "Amazon"
				},
				new Sponsor {
					Name = "Avanade"
				},
				new Sponsor {
					Name = "Mindtree"
				},
				new Sponsor {
					Name = "Salesforce"
				},
				new Sponsor {
					Name = "Google"
				},


			};
		}

		public static List<Room> GetRooms ()
		{
			return new List<Room> { 
				new Room {
					Name = "Room 100"
				},
				new Room {
					Name = "Room 200"
				},
				new Room {
					Name = "Room 300"
				}
			};
		}
	}
	
}
