using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConnectFour
{
    class Manager
    {
        private static bool tied = false;
        private static bool gameWon = false;
        private static Player winningPlayer;

        public static void InitializeGame()
        {
            Game.InstantiateBoard();
            Game.ClearScreen();
            Game.StartScreen();
        }

        public static void Play()
        {
            while (gameWon == false && tied == false)
            {
                Turn(Program.playerOne);

                if (gameWon == true || tied == true)
                {
                    break;
                }

                Turn(Program.playerTwo);
            }

            GameResult();
        }

        private static void GameResult()
        {
            // TODO Input object for log construction

            if (tied == true)
            {
                Game.ClearScreen();
                WriteLine("-------------------------------------------------------------------");
                WriteLine("                             Game Over                             ");
                WriteLine("-------------------------------------------------------------------");
                WriteLine("\n\n\n\nResult:");
                WriteLine("Game Tied!");
            }
            if (gameWon == true)
            {
                Game.ClearScreen();
                WriteLine("-------------------------------------------------------------------");
                WriteLine("                             Game Over                             ");
                WriteLine("-------------------------------------------------------------------");
                WriteLine("\n\n\n\nResult:");
                WriteLine("Player " + winningPlayer.GetPlayerNum() + " won the game!");
                WriteLine("\nPress Enter to continue...");
                ReadKey();
                ResetGame();
            }
        }

        private static void ResetGame()
        {
            tied = false;
            gameWon = false;
            InitializeGame();
        }

        public static void Turn(Player player)
        {
            Game.ClearScreen();
            WriteLine("-------------------------------------------------------------------");
            WriteLine("Player Turn: " + player.GetPlayerNum());
            WriteLine("-------------------------------------------------------------------");

            Game.PrintBoard();
            PlayerPickColumn(player);
            WinChecker.CheckForWin(player);
        }

        // player picks column
        private static void PlayerPickColumn(Player player)
        {
            int userOption = 0;
            while (true)
            {
                WriteLine("\n\nEnter a column number to drop a tile: ");

                while (!int.TryParse(Console.ReadLine(), out userOption))
                {
                    Console.WriteLine("Error: Please enter a valid number");
                }

                // number too big
                if (userOption > Game.GetColumns())
                {
                    WriteLine("Error: Invalid column.");
                }

                if (userOption > 0 && userOption < Game.GetColumns() + 1)
                {
                    // arrays start at 0;
                    userOption -= 1;

                    // check to see if user entered invalid number
                    if (Game.ValidatePlayerChoice(userOption, player) == false)
                    {
                        Console.WriteLine("Error: Invalid choice. Press Enter to Continue...");
                    }
                    else
                    {
                        break;
                    }
                }
            }

        }

        public static void GameWon(Player player)
        {
            winningPlayer = player;
            gameWon = true;
        }

        public static void GameTied()
        {
            tied = true;
        }
    }
}
