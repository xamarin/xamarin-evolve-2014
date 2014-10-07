using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portable {
	/// <summary>
	/// Manager classes are an abstraction on the data access layers
	/// </summary>
	public class TodoItemManager {

		ICloudStorage storage;

		public TodoItemManager (ICloudStorage storage) 
		{
			this.storage = storage;
		}

		public Task<TodoItem> GetTaskAsync(string id)
		{
			return storage.GetTodoItemAsync(id);
		}
		
		public Task<List<TodoItem>> GetTasksAsync ()
		{
			return storage.RefreshDataAsync();
		}
		
		public Task SaveTaskAsync (TodoItem item)
		{
			return storage.SaveTodoItemAsync(item);
		}
		
		public Task DeleteTaskAsync (TodoItem item)
		{
			return storage.DeleteTodoItemAsync(item);
		}
	}
}