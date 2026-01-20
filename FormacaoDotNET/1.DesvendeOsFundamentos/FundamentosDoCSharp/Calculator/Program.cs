
namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Sum()
        {
            Console.Clear();
            Console.WriteLine("First value:");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Second value:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            var resultado = v1 + v2;
            Console.WriteLine($"Sum result: {resultado}");

            Console.ReadKey();

            Menu();
        }

        static void Subtraction()
        {
            Console.Clear();
            Console.WriteLine("First value:");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Second value:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            var resultado = v1 - v2;
            Console.WriteLine($"Subtraction result: {resultado}");

            Console.ReadKey();

            Menu();
        }

        static void Division()
        {
            Console.Clear();
            Console.WriteLine("First value:");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Second value:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            var resultado = v1 / v2;
            Console.WriteLine($"Division result: {resultado}");

            Console.ReadKey();

            Menu();
        }

        static void Multiplication()
        {
            Console.Clear();
            Console.WriteLine("First value:");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Second value:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            var resultado = v1 * v2;
            Console.WriteLine($"Multiplication result: {resultado}");

            Console.ReadKey();

            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Select an option:");
            Console.WriteLine("1 - Sum");
            Console.WriteLine("2 - Subtraction");
            Console.WriteLine("3 - Division");
            Console.WriteLine("4 - Multiplication");
            Console.WriteLine("5 - Exit");

            Console.WriteLine("------------------------");

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: Sum(); break;
                case 2: Subtraction(); break;
                case 3: Division(); break;
                case 4: Multiplication(); break;
                case 5: Environment.Exit(0); break;
                default: Menu(); break;
            }
        }
    }
}


