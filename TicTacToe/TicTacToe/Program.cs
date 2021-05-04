using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface.GetAppInfo();
            GameLogic.gamePlay();
        }
    }
}
