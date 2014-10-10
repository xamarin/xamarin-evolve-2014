using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TheBestAppEver
{
	public class SongsViewModel : ViewModel<Song>
	{
		public event Action<float> SongsUpdated;
		public List<Song> Songs { get; private set; }

		public SongsViewModel()
		{
			Songs = new List<Song>();
		}

		public async Task Refresh()
		{
			// Start with 1st 100 songs.
			Songs.Clear();
			Songs.AddRange(Database.Songs.Table<Song>().Take(100));
			ProcItemsChanged();

			// Load new songs from service.
			var newSongs = await WebService.Shared.GetSongs ();
			await updateSongs (newSongs);
			SongsUpdated(0);
		}

		Task updateSongs(List<Song> newSongs)
		{
			return Task.Run(() => {
				for (int index = 0; index < newSongs.Count; index++) {
					var song = newSongs[index];
					Database.Songs.InsertOrReplace(song);
					SongsUpdated((float)index / (float)newSongs.Count);
					if (!Songs.Contains(song)) {
						Songs.Add(song);
						ProcItemsChanged();
					}
				}
			});
		}

		#region implemented abstract members of ViewModel

		public override int RowCount ()
		{
			return Songs.Count;
		}

		public override int RowCount (int section)
		{
			return RowCount ();
		}

		public override int SectionCount ()
		{
			return 1;
		}

		public override Song ItemForRow (int row)
		{
			return Songs [row];
		}

		public override Song ItemForRow (int section, int row)
		{
			return ItemForRow (row);
		}

		public override string HeaderTitle (int section)
		{
			return "";
		}

		#endregion
	}
}

