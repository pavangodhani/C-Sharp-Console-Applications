﻿using System;
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
            else if (command == "quit")
            {
                Quit = true;
            }
            else if (command.StartsWith("load"))
            {
                LoadCommand(command);
            }
        }

        private static void HelpCommand(string command)
        {
            Console.WriteLine();
            Console.WriteLine("GradeBook accepts the following commands:");

            Console.WriteLine();
            // Console.WriteLine("Create 'Name' - Creates a new gradebook where 'Name' is the name of the gradebook.");
            // Console.WriteLine("Create 'Name' 'Type' - Creates a new gradebook where 'Name' is the name of the gradebook and 'Type'(standard, ranked) is what type of grading it should use.");
            Console.WriteLine("Create 'Name' 'Type' 'Weighted' - Creates a new gradebook where 'Name' is the name of the gradebook, 'Type' is what type of grading(standard / ranked) it should use, and 'Weighted' is whether or not grades should be weighted (true or false).");

            Console.WriteLine();
            Console.WriteLine("Load 'Name' - Loads the gradebook with the provided 'Name'.");

            Console.WriteLine();
            Console.WriteLine("Help - Displays all accepted commands.");

            Console.WriteLine();
            Console.WriteLine("Quit - Exits the application");
        }

        private static void CreateCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 4)
            {
                Console.WriteLine("Command not valid, Create requires a name and type of gradebook.");
                return;
            }
            var name = parts[1];
            var type = parts[2].ToLower();
            bool isWeighted = bool.Parse(parts[3]);

            if (type == "standard")
            {
                var gradeBook = new StandardGradeBook(name, isWeighted);
                Console.WriteLine($"Created {type} gradebook {name}.");
                GradeBookUserInterface.CommandLoop(gradeBook);
            }
            else if (type == "ranked")
            {
                var gradeBook = new RankedGradeBook(name, isWeighted);
                Console.WriteLine($"Created {type} gradebook {name}.");
                GradeBookUserInterface.CommandLoop(gradeBook);

            }
            else if (isWeighted == true)
            {

            }
            else
            {
                System.Console.WriteLine($"Command not valid, Create requires a name, type of gradebook(standard / ranked), if it's weighted (true / false).");
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------

        public static void LoadCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 2)
            {
                Console.WriteLine("Command not valid, Load requires a name.");
                return;
            }
            var name = parts[1];
            var gradeBook = BaseGradeBook.Load(name);

            if (gradeBook == null)
                return;

            GradeBookUserInterface.CommandLoop(gradeBook);
        }
    }
}
