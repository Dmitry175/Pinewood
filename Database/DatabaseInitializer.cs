using Microsoft.Data.Sqlite;

namespace Pinewood.Database
{
    public class DatabaseInitializer
    {
        public static void Initialize(string connectionString)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var createTableCommand = @"
                    CREATE TABLE IF NOT EXISTS Products (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Email TEXT NOT NULL
                        Phone TEXT NOT NULL
                    );";

                using (SqliteCommand command = new SqliteCommand(createTableCommand, connection))
                {
                    command.ExecuteNonQuery();
                }

                var insertDataCommand = @"
                    INSERT OR IGNORE INTO Customers (Name, Email, Phone) VALUES ('John Doe', jd@email.com, 123456789);";

                using (var command = new SqliteCommand(insertDataCommand, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
