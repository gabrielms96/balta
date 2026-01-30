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
    }
}
