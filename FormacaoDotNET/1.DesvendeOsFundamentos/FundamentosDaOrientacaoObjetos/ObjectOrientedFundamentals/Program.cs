using ObjectOrientedFundamentals.ContentContext;
using ObjectOrientedFundamentals.ContentContext.Enums;

public class Program
{
    public static void Main(string[] args)
    {
        var articles = new List<Article>();
        articles.Add(new Article("First OOP Article", "object-oriented-article"));
        articles.Add(new Article("C# Article", "c-sharp-article"));
        articles.Add(new Article("ASP.NET Article", "asp-net-article"));

        foreach (var article in articles)
        {
            Console.WriteLine($"Id: {article.Id}");
            Console.WriteLine($"Title: {article.Title}");
            Console.WriteLine($"Url: {article.Url}");
            Console.WriteLine("-----------------------------");
        }

        var courses = new List<Course>();
        var courseObjectOriented = new Course("Object Oriented", "object-oriented-course", EContentLevel.Fundamental);
        var courseCSharp = new Course("C# Course", "c-sharp-course", EContentLevel.Beginner);
        var courseAspNet = new Course("ASP.NET Course", "asp-net-course", EContentLevel.Intermediate);

        courses.Add(courseObjectOriented);
        courses.Add(courseCSharp);
        courses.Add(courseAspNet);

        var careers = new List<Career>();
        var career = new Career("Especialista .NET", "especialista-dotnet-career");
        var careerItem2 = new CareerItem(2, "OOP", "", null);
        var careerItem = new CareerItem(1, "Start here", "", courseCSharp);
        var careerItem3 = new CareerItem(3, "ASP.NET", "", courseAspNet);
        career.Items.Add(careerItem2);
        career.Items.Add(careerItem);
        career.Items.Add(careerItem3);
        careers.Add(career);

        foreach (var c in careers)
        {
            Console.WriteLine($"Career: {c.Title}");
            // Order the career items by their 'Order' property before displaying them
            foreach (var item in c.Items.OrderBy(x => x.Order))
            {
                Console.WriteLine($" - {item.Order}: {item.Title} / {item.Course?.Title} - {item.Course?.Level}");

                foreach (var notification in item.Notifications)
                {
                    Console.Write($"{notification.Property} - {notification.Message}");
                }
            }

        }
    }
}
