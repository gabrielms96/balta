using Dapper;
using DapperExample.Models;
using Microsoft.Data.SqlClient;
using System.Data;

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
                //CreateManyCategories(connection);
                //UpdateCategory(connection);
                //DeleteCategory(connection);
                //ExecuteProcedure(connection);
                //ExecuteReadProcedure(connection);
                //ListCategories(connection);
                //ExecuteScalar(connection);
                //ReadView(connection);
                //OneToOne(connection);
                //OneToManys(connection);
                //QueryMutiple(connection);
                //SelectIn(connection);
                //SelectLike(connection);
                Transactions(connection);

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

        static void DeleteCategory(SqlConnection connection)
        {
            var deleteQuery = @"DELETE FROM [Category] WHERE [Id] = @id";
            connection.Execute(deleteQuery, new { id = new Guid("371598c1-681a-4733-a45f-576e6643dad2") });
        }

        static void CreateManyCategories(SqlConnection connection)
        {
            var categoryList = new List<Category>();
            for (int i = 0; i < 5; i++)
            {
                categoryList.Add(new Category
                {
                    Id = Guid.NewGuid(),
                    Title = $"Category {i}",
                    Url = $"category-{i}",
                    Summary = $"Summary of category {i}",
                    Order = i,
                    Description = $"Description of category {i}",
                    Featured = true
                });
            }
            var insertSql = @"INSERT INTO 
                            [Category] ([Id], [Title], [Url], [Summary], [Order], [Description], [Featured]) 
                            VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";
            var rows = connection.Execute(insertSql, categoryList);
            Console.WriteLine($"Number of rows inserted: {rows}");
        }
        static void ExecuteProcedure(SqlConnection connection)
        {
            var sql = "[spDeleteStudent]";
            var pars = new { StudentId = "a5c9aada-91ca-4789-92e4-e123f94327b5" };
            var affectedRows = connection.Execute(sql, pars, commandType: CommandType.StoredProcedure);
            Console.WriteLine($"Affected Rows: {affectedRows}");
        }

        static void ExecuteReadProcedure(SqlConnection connection)
        {
            var sql = "[spGetCoursesByCategory]";
            var pars = new { CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };
            //var courses = connection.Query(sql, pars, commandType: CommandType.StoredProcedure);
            var courses = connection.Query(sql, pars, commandType: CommandType.StoredProcedure);

            foreach (var itemCourse in courses)
            {
                Console.WriteLine($"Id: {itemCourse.Id} - Title: {itemCourse.Title}");
            }
        }

        static void ExecuteScalar(SqlConnection connection)
        {
            var category = new Category
            {
                Title = $"Category Scalar",
                Url = $"category-Scalar",
                Summary = $"Summary of category Scalar",
                Order = 5,
                Description = $"Description of category Scalar",
                Featured = true
            };
            var insertSql = @"INSERT INTO 
                            [Category] OUTPUT inserted.[Id]
                            VALUES (NEWID(), @Title, @Url, @Summary, @Order, @Description, @Featured)

                            SELECT SCOPE_IDENTITY()";

            var rows = connection.ExecuteScalar(insertSql, category);
            Console.WriteLine($"Number of rows inserted: {rows}");
        }

        static void ReadView(SqlConnection connection)
        {
            var sql = "SELECT * FROM [Balta].[dbo].[vwCourse]";
            var courses = connection.Query(sql);
            foreach (var itemCourse in courses)
            {
                Console.WriteLine($"Id: {itemCourse.Id} - Title: {itemCourse.Title} - Category: {itemCourse.Category}");
            }
        }

        static void OneToOne(SqlConnection connection)
        {
            var sql = @"SELECT 
                            *
                        FROM
                            [CareerItem]
                        INNER JOIN
                            [Course] ON [CareerItem].[CourseId] = [Course].[Id]";


            ///* The splitOn parameter is used to specify the column name where the split 
            ///should occur between the two objects being mapped.
            var items = connection.Query<CareerItem, Course, CareerItem>(sql, (careerItem, course) =>
            {
                careerItem.Course = course;
                return careerItem;
            }
            , splitOn: "Id");


            foreach (var itemCareer in items)
            {
                Console.WriteLine($"Career Item: {itemCareer.Title} - Course: {itemCareer.Course.Title}");
            }
        }

        static void OneToManys(SqlConnection connection)
        {
            var sql = @"SELECT 
                            [Career].[Id],
                            [Career].[Title],
                            [CareerItem].[CareerId],
                            [CareerItem].[Title]
                        FROM 
                            [Career] 
                        INNER JOIN 
                            [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
                        ORDER BY
                            [Career].[Title]";

            var careers = new List<Career>();
            var items = connection.Query<Career, CareerItem, Career>(
                sql,
                (career, item) =>
                {
                    var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                    if (car == null)
                    {
                        car = career;
                        car.Items.Add(item);
                        careers.Add(car);
                    }
                    return career;
                }
                , splitOn: "CareerId");


            foreach (var item in items)
            {
                Console.WriteLine($"Career Item: {item.Title}");
                foreach (var it in item.Items)
                {
                    Console.WriteLine($" - Course: {it.Title}");
                }
            }
        }

        static void QueryMutiple(SqlConnection connection)
        {
            var query = @"SELECT * FROM [Category]; SELECT * FROM [Course]";

            using (var multi = connection.QueryMultiple(query))
            {
                var categories = multi.Read<Category>();
                var courses = multi.Read<Course>();

                foreach (var itemCategory in categories)
                {
                    Console.WriteLine($"Id: {itemCategory.Id} - Title: {itemCategory.Title}");
                }

                foreach (var itemCourse in courses)
                {
                    Console.WriteLine($"Id: {itemCourse.Id} - Title: {itemCourse.Title}");
                }
            }
        }

        static void SelectIn(SqlConnection connection)
        {
            var ids = new[] { "6f1cc2be-9e88-4720-8b13-2b5a8d15f532", "af3407aa-11ae-4621-a2ef-2028b85507c4" };
            var sql = @"SELECT [Id], [Title] FROM [Category] WHERE [Id] IN @Ids";
            var categories = connection.Query<Category>(sql, new { Ids = ids });
            foreach (var itemCategory in categories)
            {
                Console.WriteLine($"Id: {itemCategory.Id} - Title: {itemCategory.Title}");
            }
        }

        static void SelectLike(SqlConnection connection)
        {
            var sql = @"SELECT [Id], [Title] FROM [Course] WHERE [Title] LIKE @Exp";
            var term = "Web";
            var categories = connection.Query<Course>(sql, new { Exp = $"%{term}%" });
            foreach (var itemCategory in categories)
            {
                Console.WriteLine($"Id: {itemCategory.Id} - Title: {itemCategory.Title}");
            }
        }

        static void Transactions(SqlConnection connection)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Title = "Transactions Title",
                Url = "Transactions Url",
                Summary = "Summary of Transactions",
                Order = 50,
                Description = "Description of Transactions",
                Featured = true
            };

            //Do not use string interpolation to avoid SQL Injection
            var insertSql = @"INSERT INTO 
                            [Category] ([Id], [Title], [Url], [Summary], [Order], [Description], [Featured]) 
                            VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

            //Insert a new category
            connection.Open();
            using (var transaction = connection.BeginTransaction())
            {
                var rows = connection.Execute(insertSql, category, transaction);
                transaction.Commit();
                //transaction.Rollback();
                Console.WriteLine($"Number of rows inserted: {rows}");
            }
        }
    }
}