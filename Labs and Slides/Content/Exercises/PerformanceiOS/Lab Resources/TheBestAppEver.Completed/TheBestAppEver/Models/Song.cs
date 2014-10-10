using System;
using SQLite;

namespace TheBestAppEver
{
	public class Song : IEquatable<Song>
	{
		[Indexed]
		public string Artist {get;set;}
		[Indexed]
		public DateTime Timestamp {get;set;}
		[PrimaryKey]
		public string TrackId {get;set;}
		[Indexed]
		public string Title {get;set;}

		#region IEquatable implementation

		public bool Equals(Song other)
		{
			return (other != null
			&& other.Timestamp == this.Timestamp
			&& other.Artist == this.Artist
			&& other.Title == this.Title
			&& other.TrackId == this.TrackId);
		}

		#endregion
	}
}

