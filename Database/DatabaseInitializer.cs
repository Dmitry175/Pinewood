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
                    CREATE TABLE IF NOT EXISTS Customers (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        Phone TEXT NOT NULL,
                        DateAdded datetime NOT NULL,
                        DateOfBirth datetime NOT NULL
                        LastUpdated datetime NULL
                    );";

                using (SqliteCommand command = new SqliteCommand(createTableCommand, connection))
                {
                    command.ExecuteNonQuery();
                }

                var checkTableCommand = "SELECT COUNT(*) FROM Customers";
                long rowCount = 0;

                using (var command = new SqliteCommand(checkTableCommand, connection))
                {
                    rowCount = (long)command.ExecuteScalar();
                }

                if (rowCount <= 0)
                {
                    var insertDataCommand = @"
                    INSERT OR IGNORE INTO Customers (Name, Email, Phone, DateAdded, DateOfBirth) VALUES ('John Doe', 'jd@email.com', '123456789', DateTime('now'), DateTime('now'));";

                    using (var command = new SqliteCommand(insertDataCommand, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                
            }
        }
    }
}
