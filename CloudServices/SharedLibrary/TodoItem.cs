using System;
using Newtonsoft.Json;

namespace Portable {

	public class TodoItem {
		public TodoItem ()
		{
			ID = "";
		}

		public string ID { get; set; }

		[JsonProperty(PropertyName = "text")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "notes")]
		public string Notes { get; set; }

		[JsonProperty(PropertyName = "complete")]
		public bool Done { get; set; }

		public override string ToString ()
		{
			return string.Format ("[Task: Title={0}, Description={1}, IsDone={2}]", Name, Notes, Done);
		}
	}
}