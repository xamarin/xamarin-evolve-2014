using System;

namespace MyTunes
{
	public class Song
	{
		public string Name { get; set; }
		public string Artist { get; set; }
		public string Composer { get; set; }
		public string Album { get; set; }
		public string Genre { get; set; }
		public long TotalTime { get; set; }
		public int TrackNumber { get; set; }
		public int Year { get; set; }
		public int BitRate { get; set; }
	}
}

