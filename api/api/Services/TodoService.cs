using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;
using TodoApi.Models;

namespace TodoApi.Services
{
	public class TodoService : ITodoService
	{
		private readonly string _connectionString = "Server=localhost;Database=todo_db;User=todo_user;Password=todo_password;";

		public TodoService()
		{
			using var connection = new MySqlConnection(_connectionString);
		}

		public async Task<IEnumerable<TodoItem>> GetTodosAsync()
		{
			using var connection = new MySqlConnection(_connectionString);
			string query = "SELECT * FROM Tasks";
			return await connection.QueryAsync<TodoItem>(query);
		}

		public async Task<TodoItem> GetTodoAsync(Guid id)
		{
			using var connection = new MySqlConnection(_connectionString);
			return await connection.QueryFirstOrDefaultAsync<TodoItem>(
				"SELECT * FROM Tasks WHERE Id = @Id", new { Id = id.ToString() });
		}

		public async Task CreateTodoAsync(TodoItem todoItem)
		{
			using var connection = new MySqlConnection(_connectionString);
			todoItem.id = Guid.NewGuid().ToString();

			todoItem.state = todoItem.state switch
			{
				"Open" => "Open",
				"InProgress" => "InProgress",
				"Finished" => "Finished",
				_ => throw new ArgumentException("Invalid State value")
			};

			await connection.ExecuteAsync(
				"INSERT INTO Tasks (Id, Title, State, Content) VALUES (@Id, @Title, @State, @Content)",
				todoItem);
		}

		public async Task UpdateTodoAsync(TodoItem todoItem)
		{
			using var connection = new MySqlConnection(_connectionString);
			await connection.ExecuteAsync(
				"UPDATE Tasks SET Title = @Title, State = @State, Content = @Content WHERE Id = @Id",
				todoItem);
		}

		public async Task DeleteTodoAsync(Guid id)
		{
			using var connection = new MySqlConnection(_connectionString);
			await connection.ExecuteAsync("DELETE FROM Tasks WHERE Id = @Id", new { Id = id.ToString() });
		}
	}
}
