using System;
using System.Collections.Generic;
using System.Text;

namespace EditorHTML
{
    public class OpenFile
    {

        public static void Open()
        {
            Console.Clear();
            Console.WriteLine("Enter the file path to open:");
            var path = Console.ReadLine();
            using (var file = new StreamReader(path!))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine("-----------------------");
            Console.ReadLine();
            Menu.Show();
        }

    }
}
