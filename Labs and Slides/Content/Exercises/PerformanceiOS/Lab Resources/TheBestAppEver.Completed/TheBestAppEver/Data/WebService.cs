using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;

namespace TheBestAppEver
{
	public class WebService
	{
		static WebService shared;
		public static WebService Shared {
			get {
				return shared ?? (shared = new WebService());
			}
		}

		public async Task<List<Song>> GetSongs()
		{
			var client = new WebClient ();
			const string smallFile = "http://docs.xamarin.com/xamu-wcf/songs-small.json";
			var data = await client.DownloadStringTaskAsync (smallFile);
			return await Task.Run(() => Newtonsoft.Json.JsonConvert.DeserializeObject<List<Song>>(data));
		}

		public async Task<List<TodoItem>> GetItems()
		{
			var client = new WebClient ();
			var data = await client.DownloadStringTaskAsync ("http://docs.xamarin.com/xamu-wcf/tasks.json");
			return await Task.Run(() => Newtonsoft.Json.JsonConvert.DeserializeObject<List<TodoItem>>(data));
		}
	}
}

