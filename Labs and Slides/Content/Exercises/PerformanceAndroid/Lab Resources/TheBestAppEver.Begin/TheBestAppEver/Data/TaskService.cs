using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using Android.Content;
using System.IO;

namespace TheBestAppEver
{
	public static class TaskService
	{
		static List<TodoItem> cache;

		public static async Task<List<TodoItem>> GetItems(Context context, int count = 0)
		{
			if (cache == null) {
				using (StreamReader sr = new StreamReader(context.Assets.Open("tasks.json")))
				{
					string data = await sr.ReadToEndAsync();
					cache = await Task.Run(() => {
						var list = JsonConvert.DeserializeObject<List<TodoItem>>(data);
						List<TodoItem> items = new List<TodoItem>(list);
						while (items.Count < count)
							items.AddRange(list);
						return items;
					});
				}
			}
			else {
				Random rng = new Random();  
				int n = cache.Count;  
				while (n > 1) {  
					n--;  
					int k = rng.Next(n + 1);  
					var value = cache[k];  
					cache[k] = cache[n];  
					cache[n] = value;  
				}  
			}
			return cache;
		}
	}

}

