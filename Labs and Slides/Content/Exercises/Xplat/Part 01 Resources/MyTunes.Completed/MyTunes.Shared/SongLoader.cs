using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace MyTunes
{
	public static class SongLoader
	{
		const string Filename = "songs.json";

		public static async Task<IEnumerable<Song>> Load()
		{
			using (var reader = new StreamReader(await OpenData())) {
				return JsonConvert.DeserializeObject<List<Song>>(await reader.ReadToEndAsync());
			}
		}

		private static async Task<Stream> OpenData()
		{
#if WINDOWS_PHONE_APP
			var sf = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(Filename);
			return await sf.OpenStreamForReadAsync();
#elif __IOS__
			return File.OpenRead(Filename);
#elif __ANDROID__
			return Android.App.Application.Context.Assets.Open(Filename);
#else
			// TODO: add code to open file here.
	
			return null;
#endif
		}
	}
}

