using System;
using MonoTouch.UIKit;

namespace TheBestAppEver
{
	public class SongCell : UITableViewCell
	{
		public const string Key = "Song";
		public SongCell(IntPtr handle) : base(handle)
		{

		}
		public SongCell () : base (UITableViewCellStyle.Subtitle,Key)
		{

		}

		Song song;
		public Song Song {
			get {
				return song;
			}
			set {
				song = value;
				if (song == null)
					return;
				TextLabel.Text = song.Title;
				DetailTextLabel.Text = song.Artist;
			}
		}
	}
}

