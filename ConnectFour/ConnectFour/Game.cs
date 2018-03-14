using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConnectFour
{
    class Game
    {
        public static int[][] board = new int[7][];

        public static void InstantiateBoard()
        {
            for (int r = 0; r < board.Length; r++)
            {
                board[r] = new int[7];

                for (int c = 0; c < board[r].Length - 1; c++)
                {
                    board[r][c] = 0;
                }
            }
        }

        public static void PrintBoard()
        {
            for (int row = 0; row < board.Length; row++)
            {
                Write("\nRow " + (row) + "   "); // TODO switch index out
                for (int column = 0; column < board[row].Length; column++)
                {
                    Write("| " + board[row][column] + " ");
                }
            }

            WriteLine();

            // write bottem label
            for (int x = 0; x < board[0].Length; ++x)
            {
                if (x == 0)
                {
                    Write("Column    " + (x + 1));
                }
                else
                {
                    Write("   " + (x + 1));
                }
            }

            // footer space after board game
            WriteLine("\n\n\n");
        }

        public static void ClearScreen()
        {
            for (int i = 0; i < 50; i++)
            {
                WriteLine();
            }
        }

        public static void StartScreen()
        {
            // validate user input to ensure they entered value 1-3
            int userOption = 0;

            ClearScreen();
            while (true)
            {
                ClearScreen();
                Writer.WriteWelcome();

                while (!int.TryParse(Console.ReadLine(), out userOption))
                {
                    Console.WriteLine("Error: Please enter a valid number");
                }

                if (userOption > 0 && userOption < 4)
                {
                    if (userOption == 2)
                    {
                        ClearScreen();
                        Writer.WriteInstructions();
                    }
                    else
                    {
                        break;
                    }
                }
            }

            switch (userOption)
            {
                case 1:
                    Manager.Play();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }

        public static int GetRows()
        {
            return board.Length;
        }

        public static int GetColumns()
        {
            return board[0].Length;
        }

        public static bool ValidatePlayerChoice(int userInput, Player player)
        {
            for (int r = board.Length - 1; r >= 0; --r)
            {
                if (board[r][userInput] == 0)
                {
                    // assign space to user
                    board[r][userInput] = player.GetPlayerNum();
                    return true;
                }
            }

            // row is full
            return false;
        }
    }
}