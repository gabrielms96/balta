using System;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Open File");
            Console.WriteLine("2 - Create New File");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("-----------------------");
            short option = short.Parse(Console.ReadLine());
            switch (option)
            {
                case 0: Environment.Exit(0); break;
                case 1: OpenFile(); break;
                case 2: Edit(); break;
                default: Menu(); break;
            }
        }

        static void OpenFile()
        {
            Console.Clear();
            Console.WriteLine("Enter the file path to open:");
            var path = Console.ReadLine();
            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine("-----------------------");
            Console.ReadLine();
        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Enter your text below (Press ESC to finish):");
            Console.WriteLine("----------------------------------------------");
            string text = "";
            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.Write(text);
            Save(text);
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Enter the file path to save:");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"File saved successfully at {path}");
            Console.ReadLine();
            Menu();
        }
    }
}