using System;
using System.Collections.Generic;

namespace Evolve.Core
{
	public static class EvolveData
	{
		public static List<Speaker> SpeakerData = new List<Speaker> () {
			new Speaker { Name = "John Zablocki", Company = "Couchbase", HeadshotUrl = "images/speakers/john_zablocki.jpg", TwitterHandle ="codevoyeur" },
			new Speaker { Name = "Miguel de Icaza", Company = "Xamarin", HeadshotUrl = "images/speakers/miguel.jpg", TwitterHandle ="migueldeicaza"},
			new Speaker { Name = "Aaron Bockover", Company = "Xamarin", HeadshotUrl = "images/speakers/aaron.jpg", TwitterHandle ="abock" },
			new Speaker { Name = "John Bubriski", Company = "", HeadshotUrl = "images/speakers/john_bubriski.jpg", TwitterHandle ="johnbubriski" },
			new Speaker { Name = "Paul Betts", Company = "Github", HeadshotUrl = "images/speakers/paul.jpg", TwitterHandle ="xpaulbettsx" },
			new Speaker { Name = "Louis DeJardin", Company = "Microsoft", HeadshotUrl = "images/speakers/louis.jpg", TwitterHandle ="loudej" },
			new Speaker { Name = "Scott Olson", Company = "", HeadshotUrl = "images/speakers/scott.jpg", TwitterHandle ="vagabondrev" },
			new Speaker { Name = "Igor Moochnick", Company = "", HeadshotUrl = "images/speakers/igor.jpg", TwitterHandle ="igor_moochnick" },
			new Speaker { Name = "Jérémie Laval", Company = "Xamarin", HeadshotUrl = "images/speakers/jeremie.jpg", TwitterHandle ="jeremie_laval" },
			new Speaker { Name = "Ananth Balasubramaniam", Company = "", HeadshotUrl = "images/speakers/ananth.jpg", TwitterHandle ="ananthonline" },
			new Speaker { Name = "Bob Familiar", Company = "Microsoft", HeadshotUrl = "images/speakers/bob.jpg", TwitterHandle ="bobfamiliar" },
			new Speaker { Name = "Michael Hutchinson", Company = "Xamarin", HeadshotUrl = "images/speakers/michael.jpg", TwitterHandle ="mjhutchinson" },
			new Speaker { Name = "Jonathan Chambers", Company = "Unity", HeadshotUrl = "images/speakers/jonathan.jpg", TwitterHandle ="jon_cham" },
			new Speaker { Name = "Steve Millar", Company = "Infinitek", HeadshotUrl = "images/speakers/steve.jpg", TwitterHandle ="samillar77" },
			new Speaker { Name = "Somya Jain", Company = "", HeadshotUrl = "images/speakers/somya.jpg", TwitterHandle ="somya_j" },
			new Speaker { Name = "Sam Lippert", Company = "", HeadshotUrl = "images/speakers/sam.jpg", TwitterHandle ="lippertz" },
			new Speaker { Name = "Don Syme", Company = "Microsoft", HeadshotUrl = "images/speakers/don.jpg", TwitterHandle ="dsyme" },
			new Speaker { Name = "Dean Ellis", Company = "Aurora", HeadshotUrl = "images/speakers/dean.jpg", TwitterHandle ="infspacestudios" },
			new Speaker { Name = "Jb Evain", Company = "SyntaxTree", HeadshotUrl = "images/speakers/jb.jpg", TwitterHandle ="jbevain" },
			new Speaker { Name = "Chris Hardy", Company = "Xamarin", HeadshotUrl = "images/speakers/chris.jpg", TwitterHandle ="chrisntr" },
			new Speaker { Name = "Demis Bellot", Company = "StackExchange", HeadshotUrl = "images/speakers/demis.jpg", TwitterHandle ="demisbellot" },
			new Speaker { Name = "Frank Krueger", Company = "Xamarin", HeadshotUrl = "images/speakers/frank.jpg", TwitterHandle ="praeclarum" },
			new Speaker { Name = "Greg Shackles", Company = "OLO", HeadshotUrl = "images/speakers/greg.jpg", TwitterHandle ="gshackles" },
			new Speaker { Name = "Phil Haack", Company = "Github", HeadshotUrl = "images/speakers/phil.jpg", TwitterHandle ="haacked" },
			new Speaker { Name = "David Fowler", Company = "Microsoft", HeadshotUrl = "images/speakers/david.jpg", TwitterHandle ="davidfowler" },
		};
		public static List<Session> SessionData = new List<Session> () {
			new Session {
				Title = "Introduction to Mobile Development",
				Speaker = "Bryan Costanich",
				Location = "Ballroom",
				Begins = new DateTime (2013, 4, 14, 9, 0, 0)
			},
			new Session {
				Title = "Hello iOS",
				Speaker = "Bryan Costanich",
				Location = "Ballroom",
				Begins = new DateTime (2013, 4, 14, 10, 0, 0)
			},
			new Session {
				Title = "Hello Android",
				Speaker = "Bryan Costanich",
				Location = "Ballroom",
				Begins = new DateTime (2013, 4, 14, 15, 0, 0)
			},
			new Session {
				Title = "Cross-platform Navigation",
				Speaker = "Bryan Costanich",
				Location = "Ballroom",
				Begins = new DateTime (2013, 4, 15, 9, 0, 0)
			},
			new Session {
				Title = "Cross-platform Projects",
				Speaker = "Bryan Costanich",
				Location = "Ballroom",
				Begins = new DateTime (2013, 4, 15, 9, 0, 0)
			},
			new Session {
				Title = "Keynote (Day 1)",
				Speaker = "Miguel de Icaza, Nat Friedman",
				Location = "Ballroom",
				Begins = new DateTime (2013, 4, 16, 9, 0, 0)
			},
			new Session {
				Title = "Keynote (Day 2)",
				Speaker = "Miguel de Icaza, Nat Friedman",
				Location = "Ballroom",
				Begins = new DateTime (2013, 4, 17, 9, 0, 0)
			},
		};
	}
}

