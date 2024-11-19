using System;
using System.Threading.Tasks;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TodoController : ControllerBase
	{
		private readonly ITodoService _todoService;

		public TodoController(ITodoService todoService)
		{
			_todoService = todoService;
		}

		[HttpGet]
		public async Task<IActionResult> GetTodos()
		{
			var todos = await _todoService.GetTodosAsync();
			return Ok(todos);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetTodoById(Guid id)
		{
			var todo = await _todoService.GetTodoAsync(id);
			if (todo == null)
			{
				return NotFound(new { isError = true, error = new { code = "404", message = "Todo not found" } });
			}
			return Ok(todo);
		}

		[HttpPost]
		public async Task<IActionResult> CreateTodo(TodoItem todoItem)
		{
			await _todoService.CreateTodoAsync(todoItem);
			return CreatedAtAction(nameof(GetTodoById), new { id = todoItem.id }, todoItem);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateTodo(string id, TodoItem todoItem)
		{
			if (!Guid.TryParse(id, out var idGuid))
			{
				return BadRequest(new { isError = true, error = new { code = "400", message = "Invalid ID format" } });
			}

			var existingTodo = await _todoService.GetTodoAsync(idGuid);
			if (existingTodo == null)
			{
				return NotFound(new { isError = true, error = new { code = "404", message = "Todo not found" } });
			}

			await _todoService.UpdateTodoAsync(todoItem);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTodo(string id)
		{
			if (!Guid.TryParse(id, out var idGuid))
			{
				return BadRequest(new { isError = true, error = new { code = "400", message = "Invalid ID format" } });
			}

			var existingTodo = await _todoService.GetTodoAsync(idGuid);
			if (existingTodo == null)
			{
				return NotFound(new { isError = true, error = new { code = "404", message = "Todo not found" } });
			}

			await _todoService.DeleteTodoAsync(idGuid);
			return NoContent();
		}
	}
}
