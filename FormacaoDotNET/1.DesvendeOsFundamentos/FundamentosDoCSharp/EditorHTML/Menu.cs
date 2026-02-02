using System;
using System.Collections.Generic;
using System.Text;

namespace EditorHTML
{
    public static class Menu
    {

        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            DrawScreen();
            WriteOptions();

            var option = short.Parse(Console.ReadLine());

            HandleMenuOption(option);
        }

        public static void DrawScreen()
        {
            WriteTopBottomLine();
            Border(15);
            WriteTopBottomLine();
        }

        public static void WriteTopBottomLine()
        {
            Console.Write("+");
            for (int i = 0; i <= 17; i++)
            {
                Console.Write("<>");
            }
            Console.Write("+");
            Console.Write("\n");
        }

        public static void Border(int Lines)
        {
            for (int i = 0; i <= Lines; i++)
            {
                Console.Write("|");
                for (int j = 0; j <= 35; j++)
                    Console.Write(" ");
                
                Console.Write("|");
                Console.Write("\n");
            }
        }

        public static void WriteOptions()
        {
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("Editor HTML");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("============");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Select an option below:");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("1 - New File");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("2 - Open File");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine("0 - Exit");
            Console.SetCursorPosition(3, 10);
            Console.Write("Option: ");
        }

        public static void HandleMenuOption(short option)
        {
            switch (option)
            {
                case 1:
                    EditorHtml.Show();
                    break;
                case 2:
                    OpenFile.Open();
                    break;
                case 0:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Show();
                    break;
            }
        }
    }
}
