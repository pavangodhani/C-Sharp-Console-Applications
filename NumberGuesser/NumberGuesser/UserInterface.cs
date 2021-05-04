using System;

namespace NumberGuesser
{
    public static class UserInterface
    {
        static bool quit = false;
        static string name;

        public static void GetAppInfo()
        {
            string appName = "Number Guesser";
            string appVersion = "1.0.0";
            string appAuthor = "Marshal";

            printColorMessage(ConsoleColor.Green, $"App : {appName}\nVersion : {appVersion}\nDeveloped By : {appAuthor}");
        }

        private static void greetUser()
        {
            Console.WriteLine("\nEnter your name : ");
            name = Console.ReadLine();

            printColorMessage(ConsoleColor.Blue, $"\nHello {name.ToUpper()}, Let's play a game...");
        }

        public static void InputLoop()
        {
            greetUser();

            gameStart();

            while (!quit)
            {
                Console.WriteLine($"\n{name.ToUpper()} Play Again? [Y or N]");
                var command = Console.ReadLine().ToLower();

                if(command == "n")
                {
                    break;
                }
                else if(command == "y")
                {
                    gameStart();
                }
                else
                {
                    printColorMessage(ConsoleColor.Red, "Oops...Wrong Input, Please try again...");
                    continue;
                }
            }
        }

        private static void gameStart()
        {
            int correctNumber = new Random().Next(1, 10);
            int guess = 0;
            int attempt = 0;


            while(true)
            {
                Console.WriteLine("\nGuess a number between 1 to 10 : ");
                var input = Console.ReadLine();

                if(! int.TryParse(input, out guess))
                {
                    printColorMessage(ConsoleColor.Red, "It's not a number!!!...Please enter a number between 1 to 10...");
                    continue;
                }

                if(guess == correctNumber)
                {
                    printColorMessage(ConsoleColor.Yellow, "\nYou are CORRECT !!!...");
                    printColorMessage(ConsoleColor.Yellow, $"You take {attempt} attempts...");
                    break;
                }
                else
                {
                    printColorMessage(ConsoleColor.Red, "Oops...Wrong Number, Please try again...");
                    attempt++;
                }
            }
        }

        private static void printColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
