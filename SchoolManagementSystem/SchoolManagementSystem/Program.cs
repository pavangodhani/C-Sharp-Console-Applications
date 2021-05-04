using System;
using AdminInterface;

namespace SchoolManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            printColorMessage(ConsoleColor.Green, "Who are you ? (Student, Teacher or Admin)");
            string userType = Console.ReadLine().ToLower();

            if (userType == "admin")
            {
                AdminInterface.AdminInterface.CommandLoop();
            }
            else
            {
                printColorMessage(ConsoleColor.Red, "Please, Enter valid input...");    
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
