using System;

namespace TodoApi.Models
{
	public class TodoItem
	{
		public string id { get; set; }
		public string title { get; set; }
		public string content { get; set; }
		public string state { get; set; }
	}
}
