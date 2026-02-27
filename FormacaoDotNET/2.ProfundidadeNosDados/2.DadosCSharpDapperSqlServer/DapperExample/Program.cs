using Dapper;
using DapperExample.Models;
using Microsoft.Data.SqlClient;

namespace DapperExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connectionString = "Server=localhost,1433;Database=Balta;User Id=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                //CreateCateory(connection);
                UpdateCategory(connection);
                ListCategories(connection);
            }
        }

        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
            foreach (var itemCategory in categories)
            {
                Console.WriteLine($"Id: {itemCategory.Id} - Title: {itemCategory.Title}");
            }
        }

        static void CreateCateory(SqlConnection connection)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Title = "Category Dapper",
                Url = "category-dapper",
                Summary = "Summary of category dapper",
                Order = 8,
                Description = "Description of category dapper",
                Featured = true
            };

            //Do not use string interpolation to avoid SQL Injection
            var insertSql = @"INSERT INTO 
                            [Category] ([Id], [Title], [Url], [Summary], [Order], [Description], [Featured]) 
                            VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

            //Insert a new category
            var rows = connection.Execute(insertSql, category);

            Console.WriteLine($"Number of rows inserted: {rows}");
        }

        static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = @"UPDATE [Category] SET [Title] = @title WHERE [Id] = @id";
            connection.Execute(updateQuery, new { title = "Updated Category", id = new Guid("9f04f60e-98f4-44fc-8e38-5a9819cbbcd6") });
        }
    }
}