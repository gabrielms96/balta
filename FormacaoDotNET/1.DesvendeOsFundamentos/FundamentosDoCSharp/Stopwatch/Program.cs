using System;

namespace Stopwatch
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
            Console.WriteLine("Stopwatch Menu");
            Console.WriteLine("Enter the time in seconds or minutes to count up to:");
            Console.WriteLine("For seconds, just enter the numeber with 's' (10s = 10 seconds).");
            Console.WriteLine("For minutes, enter the number with 'm' (1m = 1 minute).");
            Console.WriteLine("Or enter '0' to exit.");

            string data = Console.ReadLine().ToLower();

            if (data == "0")
                Environment.Exit(0);

            char type = data[data.Length - 1];
            int multiplier = 1;
            if (type != 's' && type != 'm')
            {
                Console.WriteLine("Invalid format. Please use 's' for seconds or 'm' for minutes.");
                Thread.Sleep(2000);
                Console.WriteLine("Returning to menu...");
                Menu();
            }
            else if (type == 'm')
                multiplier = 60;

            data = data.Substring(0, data.Length - 1);
            StartStopwatch(int.Parse(data) * multiplier);
        }

        static void StartStopwatch(int time)
        {
            int currentTime = 0;

            while (currentTime != time)
            {
                Console.Clear();
                currentTime++;
                Console.WriteLine(currentTime);
                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("Stopwatch finished! Will return to menu in");
            Console.WriteLine("3 seconds...");
            Thread.Sleep(1000);
            Console.WriteLine("2 seconds...");
            Thread.Sleep(1000);
            Console.WriteLine("1 second...");
            Thread.Sleep(1000);
            Console.WriteLine("Returning to menu...");
            Thread.Sleep(700);
            Menu();
        }
    }
}