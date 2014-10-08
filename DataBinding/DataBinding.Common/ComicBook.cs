using System.Collections.Generic;

namespace DataBinding.Common
{
	public class ComicBook
	{
		public ComicBook () {}

		public int SeriesNumber  { get; set; }
		public string SeriesName  { get; set; }
		public string Writer  { get; set; }
		public string Penciller  { get; set; }
		public string Inker  { get; set; }
		public string Colorist  { get; set; }
		public string Letterer  { get; set; }
		public string Editor  { get; set; }
		public string StoryTitle  { get; set; }
		public string Character { get; set; }
		public string ISBN { get; set; }
		public string Barcode { get; set; }
		public string ImageSmall { get; set; }
		public string Url { get; set; }

		public string ListName {
			get {
				return string.Format ("#{0} - {1}", SeriesNumber, StoryTitle);
			}
		}

		public override string ToString ()
		{
			return string.Format ("[ComicBook: SeriesNumber={0}, SeriesName={1}, Writer={2}, Penciller={3}, " +
				"Inker={4}, Colorist={5}, Letterer={6}, Editor={7}, StoryTitle={8}, Character={9}, ISBN={10}, " +
				"Barcode={11}]", SeriesNumber, SeriesName, Writer, Penciller, Inker, Colorist, Letterer, Editor, 
				StoryTitle, Character, ISBN, Barcode);
		}
	}

	public static class ComicBookFactory{
		public static IList<ComicBook> GetComicBooks() {
			return new List<ComicBook> {
				new ComicBook {
					SeriesNumber = 12,
					SeriesName = "The Adventures of the X-Men",
					Writer = "",
					Penciller = "Trevor Scott",
					Inker = "?",
					Colorist = "?",
					Letterer = "Typeset",
					Editor = "Mark Bernardo",
					StoryTitle = "The Fateful Final Issue!",
					Character = "Cyclops; Jean Grey; Storm; Wolverine; Gambit; Beast; Living Tribunal",
					ISBN = "",
					Barcode = "",
					ImageSmall = "http://files1.comics.org//img/gcd/covers_by_id/195/w200/195620.jpg?7894643195071621869",
					Url = "http://www.comics.org/issue/214189/"
				},
				new ComicBook {
					SeriesNumber = 11,
					SeriesName = "The Adventures of the X-Men",
					Writer = "",
					Penciller = "Trevor Scott",
					Inker = "?",
					Colorist = "?",
					Letterer = "Typeset",
					Editor = "Mark Bernardo",
					StoryTitle = "In the Shadow of - Man-Thing",
					Character = "Jean Grey; Storm; Man-Thing",
					ISBN = "",
					Barcode = "",
					ImageSmall = "http://files1.comics.org//img/gcd/covers_by_id/195/w200/195619.jpg?1724302072195081646",
					Url = "http://www.comics.org/issue/214188/"
				},


				new ComicBook {
					SeriesNumber = 10,
					SeriesName = "The Adventures of the X-Men",
					Writer = "",
					Penciller = "Yancey Labat",
					Inker = "Ralph Cabrera",
					Colorist = "?",
					Letterer = "Typeset",
					Editor = "Mark Bernardo",
					StoryTitle = "Mojo's Media Madness!",
					Character = "Storm; Jean Grey; Cyclops; Gambit; Mojo; Turner",
					ISBN = "",
					Barcode = "75960604339201011",
					ImageSmall = "http://files1.comics.org//img/gcd/covers_by_id/195/w200/195618.jpg?8724365072384081835",
					Url = "http://www.comics.org/issue/214187/"
				}
			};
		}
	}
}

