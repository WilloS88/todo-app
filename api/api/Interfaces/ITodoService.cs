using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;

namespace api.Interfaces
{
	public interface ITodoService
	{
		Task<IEnumerable<TodoItem>> GetTodosAsync();
		Task<TodoItem> GetTodoAsync(Guid id);
		Task CreateTodoAsync(TodoItem todoItem);
		Task UpdateTodoAsync(TodoItem todoItem);
		Task DeleteTodoAsync(Guid id);
	}
}
