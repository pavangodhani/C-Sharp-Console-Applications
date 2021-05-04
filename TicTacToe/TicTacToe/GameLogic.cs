using System;
using System.Collections.Generic;

namespace TicTacToe
{
    static class GameLogic
    {
        private static bool gameStillGoing = true;
        private static char? winner = null;
        private static char currentPlayer = 'X';

        public static void gamePlay()
        {
            UserInterface.DisplayBoard();

            while (gameStillGoing)
            {
                handleTurn(currentPlayer);
                checkTie();
            }
        }

        private static void handleTurn(char currentPlayer)
        {
            UserInterface.PrintColorMessage(ConsoleColor.Blue, $"\n{currentPlayer}'s turn...");
            UserInterface.PrintColorMessage(ConsoleColor.Green, "\nChoose a position from 1-9 : ");
            string inputPosition = Console.ReadLine();
            int position = 0;

            bool valid = false;
            List<string> positions = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            while (!valid)
            {
                while (!positions.Contains(inputPosition))
                {
                    UserInterface.PrintColorMessage(ConsoleColor.Red, "\nOops...Invalid Input...Please, Choose a position from 1-9 : ");
                    UserInterface.PrintColorMessage(ConsoleColor.Green, "\nChoose a position from 1-9 : ");
                    inputPosition = Console.ReadLine();
                }

                position = int.Parse(inputPosition);

                position = position - 1;

                if (UserInterface.Board[position] == '-')
                {
                    valid = true;
                }
                else
                {
                    UserInterface.PrintColorMessage(ConsoleColor.Red, "\nSorry...You can't go there....");
                    inputPosition = null;
                }
            }

            UserInterface.Board[position] = currentPlayer;
            UserInterface.DisplayBoard();
        }

        private static void checkWinner()
        {

        }

        private static void checkTie()
        {
            if (!UserInterface.Board.Contains('-'))
            {
                gameStillGoing = false;
            }
        }

    }
}