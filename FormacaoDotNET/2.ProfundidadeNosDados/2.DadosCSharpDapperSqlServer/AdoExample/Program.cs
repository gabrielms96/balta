using Microsoft.Data.SqlClient;

namespace DataAccess
{
    internal class Program
    {
        /// <summary>
        /// ADO.NET example to connect to a SQL Server database, execute a simple query, and read the results.
        /// Today we are using Frameworks like Dapper and Entity Framework, but it's important to understand how ADO.NET works under the hood.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=Balta;User Id=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection opened successfully.");

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [Id], [Title] FROM Category";

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader.GetGuid(0)}, Title: {reader.GetString(1)}");
                    }
                }
                connection.Close();
                Console.WriteLine("Connection closed successfully.");
            }
        }
    }
}