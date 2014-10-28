using System;
using System.Collections.Generic;

namespace Evolve.Core
{
	public static class EvolveData
	{
		public static List<Animal> AnimalData = new List<Animal> () {
			new Animal { Name = "African Lion", Species = "Panthera leo" },
			new Animal { Name = "Amur Tiger", Species = "Panthera tigris altaica"},
			new Animal { Name = "Snow Leopard", Species = "Panthera Uncia" },
			new Animal { Name = "Sungazer", Species = "Cordylus giganteus" },
			new Animal { Name = "Roadrunner", Species = "Geococcyx californianus", },
			new Animal { Name = "Gambel's Quail", Species = "Callipepla gambelii" },
			new Animal { Name = "Cape Thick-knee", Species = "Burhinus bistriatus" },
			new Animal { Name = "Blue Poison Frog", Species = "Dendrobates azureus", },
			new Animal { Name = "Andean Condor", Species = "Vultur gryphus" },
			new Animal { Name = "Black-footed Cat", Species = "Felis nigripes" },
			new Animal { Name = "Naked Mole Rat", Species = "Heterocephalus glaber"},
			new Animal { Name = "Meerkat", Species = "Suricata suricatta"},
			new Animal { Name = "Caracal", Species = "Caracal caracal" },
			new Animal { Name = "Bat-Eared Fox", Species = "Otocyon megalotis" },
			new Animal { Name = "Burmese Python", Species = "Python molurus bivittatus" },
			new Animal { Name = "Clouded Leopard", Species = "Neofelis nebulosa" },
			new Animal { Name = "African Giant Millipede", Species = "Spirobolus spp." },
			new Animal { Name = "Binturong", Species = "Arctictis binturong" },
		};
		public static List<Exhibit> EventData = new List<Exhibit> () {
			new Exhibit {
				Title = "Fall Lecture Series",
				Location = "Ballroom",
				Begins = new DateTime (2013, 4, 14, 9, 0, 0)
			},
			new Exhibit {
				Title = "Cat Awareness Weekend",
				Location = "Ballroom",
				Begins = new DateTime (2013, 4, 14, 10, 0, 0)
			},
			new Exhibit {
				Title = "Wines in the Wild",
				Location = "Ballroom",
				Begins = new DateTime (2013, 4, 14, 15, 0, 0)
			},
			new Exhibit {
				Title = "Corporate Tree Trim",
				Location = "Ballroom",
				Begins = new DateTime (2013, 4, 15, 9, 0, 0)
			},
			new Exhibit {
				Title = "Zoo Year's Eve",
				Location = "Ballroom",
				Begins = new DateTime (2013, 4, 15, 9, 0, 0)
			},
			new Exhibit {
				Title = "Boo! at the Zoo",
				Location = "Ballroom",
				Begins = new DateTime (2013, 4, 16, 9, 0, 0)
			},
			new Exhibit {
				Title = "Zoo Run Run for Animal Care",
				Location = "Ballroom",
				Begins = new DateTime (2013, 4, 17, 9, 0, 0)
			},
		};
	}
}

