using System;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface.GetAppInfo();

            UserInterface.InputLoop();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thanks For Playing...");
            Console.ResetColor();
        }
    }
}
