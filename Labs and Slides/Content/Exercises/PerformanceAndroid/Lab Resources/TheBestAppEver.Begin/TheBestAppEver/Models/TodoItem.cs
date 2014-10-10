namespace TheBestAppEver
{
	public class TodoItem
	{
		public string Title { get; set; }
		public bool Completed { get; set; }
		public string Notes {get;set;}

		public override string ToString()
		{
			return string.Format("{0}{1}", Title, Completed ? " - Completed" : "");
		}
	}
}

