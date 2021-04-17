using System;
using GradeBook.GradeBooks;

namespace GradeBook.UserInterfaces
{
    public static class StartingUserInterface
    {
        public static bool Quit = false;
        public static void CommandLoop()
        {
            while (!Quit)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(">> What would you like to do?");
                var command = Console.ReadLine().ToLower();
                CommandRoute(command);
            }
        }

        private static void CommandRoute(string command)
        {
            if (command.StartsWith("create"))
            {
                CreateCommand(command);
            }
            else if (command == "help")
            {
                HelpCommand(command);
            }
            else if(command == "quit")
            {
                Quit = true;
            }
        }

        private static void HelpCommand(string command)
        {
            Console.WriteLine();
            Console.WriteLine("GradeBook accepts the following commands:");
            Console.WriteLine();
            Console.WriteLine("Create 'Name' - Creates a new gradebook where 'Name' is the name of the gradebook.");
            Console.WriteLine();
            Console.WriteLine("Load 'Name' - Loads the gradebook with the provided 'Name'.");
            Console.WriteLine();
            Console.WriteLine("Help - Displays all accepted commands.");
            Console.WriteLine();
            Console.WriteLine("Quit - Exits the application");
        }

        private static void CreateCommand(string command)
        {
            var parts = command.Split(" ");
            if (parts.Length != 2)
            {
                System.Console.WriteLine("Command not Valid");
                return;
            }

            var name = parts[1];

            BaseGradeBook gradeBook = new BaseGradeBook(name);
            System.Console.WriteLine($"Created Grade Book {name}");

            GradeBookUserInterface.CommandLoop(gradeBook);
        }
    }
}
