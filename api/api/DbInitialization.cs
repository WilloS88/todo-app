using System.Data;
using MySql.Data.MySqlClient;
using Dapper;

namespace DbInit
{
	public static class DatabaseInitializer
	{
		public static void InitializeDatabase(string connectionString)
		{
			using (IDbConnection dbConnection = new MySqlConnection(connectionString))
			{
				dbConnection.Open();

				string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Tasks (
                    Id VARCHAR(36) PRIMARY KEY,
					Title VARCHAR(255) NOT NULL,
					Content TEXT,
					State ENUM('Open', 'InProgress', 'Finished') NOT NULL DEFAULT 'Open',
					created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
					updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                );";

				dbConnection.Execute(createTableQuery);
			}
		}
	}
}
