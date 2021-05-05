using System;
using System.Collections.Generic;

namespace TicTacToe
{
    static class GameLogic
    {
        private static bool gameStillGoing;
        private static char? winner;
        private static char currentPlayer;
        private static List<char> board;
        private static bool quit = false;

        public static void GamePlay()
        {
            while (!quit)
            {
                board = new List<char>() { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
                gameStillGoing = true;
                winner = null;
                currentPlayer = 'X';

                displayBoard();

                while (gameStillGoing)
                {
                    handleTurn(currentPlayer);
                    checkWinner();
                    flipPlayer();
                    checkTie();
                }

                if (winner == 'X' || winner == 'O')
                {
                    printColorMessage(ConsoleColor.Cyan, $"\n{winner} Won");
                }
                else if (winner == null)
                {
                    printColorMessage(ConsoleColor.Cyan, "\nTie");
                }

                string input;
                while (true)
                {
                    printColorMessage(ConsoleColor.Green, "\nPlay again [Y / N]");
                    input = Console.ReadLine().ToUpper();
                    if(input == "Y" || input == "N")
                    {
                        break;
                    }
                    else
                    {
                        printColorMessage(ConsoleColor.Red, "\nOops...Invalid Input...");
                    }
                }

                if (input == "Y")
                {
                    continue;
                }
                else if (input == "N")
                {
                    quit = true;
                }
            }
        }

        private static void displayBoard()
        {
            Console.WriteLine();
            printColorMessage(ConsoleColor.Yellow, $"{board[0]} | {board[1]} | {board[2]}");
            printColorMessage(ConsoleColor.Yellow, $"{board[3]} | {board[4]} | {board[5]}");
            printColorMessage(ConsoleColor.Yellow, $"{board[6]} | {board[7]} | {board[8]}");
        }

        private static void handleTurn(char currentPlayer)
        {
            printColorMessage(ConsoleColor.Blue, $"\n{currentPlayer}'s turn...");
            printColorMessage(ConsoleColor.Green, "\nChoose a position from 1-9 : ");
            string inputPosition = Console.ReadLine();
            int position = 0;

            bool valid = false;
            List<string> positions = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            while (!valid)
            {
                while (!positions.Contains(inputPosition))
                {
                    printColorMessage(ConsoleColor.Red, "\nOops...Invalid Input...Please, Choose a position from 1-9 : ");
                    printColorMessage(ConsoleColor.Green, "\nChoose a position from 1-9 : ");
                    inputPosition = Console.ReadLine();
                }

                position = int.Parse(inputPosition);

                position = position - 1;

                if (board[position] == '-')
                {
                    valid = true;
                }
                else
                {
                    printColorMessage(ConsoleColor.Red, "\nSorry...You can't go there....");
                    inputPosition = null;
                }
            }

            board[position] = currentPlayer;
            displayBoard();
        }

        private static void flipPlayer()
        {
            if (currentPlayer == 'X')
            {
                currentPlayer = 'O';
            }
            else
            {
                currentPlayer = 'X';
            }
        }

        private static void checkWinner()
        {
            char? rowWinner = checkRows();
            char? columnWinner = checkColumns();
            char? diagonalWinner = checkDiagonals();

            if (rowWinner != null)
            {
                winner = rowWinner;
            }
            else if (columnWinner != null)
            {
                winner = columnWinner;
            }
            else if (diagonalWinner != null)
            {
                winner = diagonalWinner;
            }
            else
            {
                winner = null;
            }
        }

        private static char? checkDiagonals()
        {
            bool diagonal1 = board[0] != '-' && board[4] != '-' && board[8] != '-' && board[0] == board[4] && board[4] == board[8];
            bool diagonal2 = board[2] != '-' && board[4] != '-' && board[6] != '-' && board[2] == board[4] && board[4] == board[6];

            if (diagonal1 || diagonal2)
            {
                gameStillGoing = false;
            }

            if (diagonal1)
            {
                return board[0];
            }
            else if (diagonal2)
            {
                return board[2];
            }
            else
            {
                return null;
            }
        }

        private static char? checkColumns()
        {
            bool column1 = board[0] != '-' && board[3] != '-' && board[6] != '-' && board[0] == board[3] && board[3] == board[6];
            bool column2 = board[1] != '-' && board[4] != '-' && board[7] != '-' && board[1] == board[4] && board[4] == board[7];
            bool column3 = board[2] != '-' && board[5] != '-' && board[8] != '-' && board[2] == board[5] && board[5] == board[8];


            if (column1 || column2 || column3)
            {
                gameStillGoing = false;
            }

            if (column1)
            {
                return board[0];
            }
            else if (column2)
            {
                return board[1];
            }
            else if (column3)
            {
                return board[2];
            }
            else
            {
                return null;
            }
        }

        private static char? checkRows()
        {
            bool row1 = board[0] != '-' && board[1] != '-' && board[2] != '-' && board[0] == board[1] && board[1] == board[2];
            bool row2 = board[3] != '-' && board[4] != '-' && board[5] != '-' && board[3] == board[4] && board[4] == board[5];
            bool row3 = board[6] != '-' && board[7] != '-' && board[8] != '-' && board[6] == board[7] && board[7] == board[8];

            if (row1 || row2 || row3)
            {
                gameStillGoing = false;
            }

            if (row1)
            {
                return board[0];
            }
            else if (row2)
            {
                return board[3];
            }
            else if (row3)
            {
                return board[6];
            }
            else
            {
                return null;
            }
        }

        private static void checkTie()
        {
            if (!board.Contains('-'))
            {
                gameStillGoing = false;
            }
        }

        public static void GetAppInfo()
        {
            string appName = "Tic Tac Toe";
            string appVersion = "1.0.0";

            printColorMessage(ConsoleColor.Green, $"\nApp : {appName}\nVersion : {appVersion}");
        }

        private static void printColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }
}