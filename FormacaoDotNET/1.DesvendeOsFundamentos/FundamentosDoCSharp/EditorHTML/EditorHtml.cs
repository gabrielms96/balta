using System;
using System.Collections.Generic;
using System.Text;

namespace EditorHTML
{
    public class EditorHtml
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("EDITOR");
            Console.WriteLine("------------------");
            Start();
        }

        public static void Start() 
        { 
            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("---------------");
            Console.WriteLine(" Save changes? S or N");
            Viewer.Show(file.ToString());

        }

    }
}
