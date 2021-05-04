using System;

namespace SchoolManagementSystem.AdminInterface
{
    static class AdminInterface
    {
        public static void CommandLoop()
        {
            System.Console.WriteLine("Enter Login ID : ");
            string loginId = Console.ReadLine().ToLower();
            System.Console.WriteLine("Enter Password : ");
            string password = Console.ReadLine().ToLower();

            if (loginId == "admin" && password == "admin")
            {
                System.Console.WriteLine("admin here...");  
            }
            else
            {
                printColorMessage(ConsoleColor.Red, "Id or Password don't match...");
            }

        }

        private static void printColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            System.Console.WriteLine(message);
            Console.ResetColor();
        }

    }
}