using System;
using System.Collections.Generic;

namespace TicTacToe
{
    static class UserInterface
    {
        public static List<char> Board = new List<char>() { '-', '-', '-', '-', '-', '-', '-', '-', '-' };

        public static void DisplayBoard()
        {
            Console.WriteLine();
            PrintColorMessage(ConsoleColor.Yellow, $"{Board[0]} | {Board[1]} | {Board[2]}");
            PrintColorMessage(ConsoleColor.Yellow, $"{Board[3]} | {Board[4]} | {Board[5]}");
            PrintColorMessage(ConsoleColor.Yellow, $"{Board[6]} | {Board[7]} | {Board[8]}");
        }

        public static void GetAppInfo()
        {
            string appName = "Tic Tac Toe";
            string appVersion = "1.0.0";

            PrintColorMessage(ConsoleColor.Green, $"\nApp : {appName}\nVersion : {appVersion}");
        }

        public static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
