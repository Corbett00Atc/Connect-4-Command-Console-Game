using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConnectFour
{
    class WinChecker
    {

        public static void CheckForWin(Player player)
        {
            CheckHorizontalWin(player);
            CheckVerticalWin(player);
            CheckDiagnalWinUp(player);
            CheckDiagnalWinDown(player);
        }

        private static void CheckHorizontalWin(Player player)
        {
            int fourInRow = 0;
            // cycles through each space
            for (int row = 0; row < Game.board.Length; row++)
            {
                for (int column = 0; column < Game.board[row].Length - 3; column++)
                {
                    // found a space with player token
                    if (Game.board[row][column] == player.GetPlayerNum())
                    {
                        // checks for four in a row
                        for (int c = column; c < column + 4; c++)
                        {
                            if (Game.board[row][c] == player.GetPlayerNum())
                            {
                                fourInRow++;

                                // game won
                                if (fourInRow >= 4)
                                {
                                    Manager.GameWon(player);
                                    return;
                                }
                            }
                            else
                            {
                                fourInRow = 0;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void CheckVerticalWin(Player player)
        {
            int fourInRow = 0;
            // cycles through each space
            for (int row = 0; row < Game.board.Length - 3; row++)
            {
                for (int column = 0; column < Game.board[row].Length; column++)
                {
                    // found a space with player token
                    if (Game.board[row][column] == player.GetPlayerNum())
                    {
                        // checks for four in a row
                        for (int r = row; r < row + 4; r++)
                        {
                            if (Game.board[r][column] == player.GetPlayerNum())
                            {
                                fourInRow++;

                                // game won
                                if (fourInRow >= 4)
                                {
                                    Manager.GameWon(player);
                                    return;
                                }
                            }
                            else
                            {
                                fourInRow = 0;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void CheckDiagnalWinUp(Player player)
        {
            int fourInRow = 0;
            // cycles through each space
            for (int row = 0; row < Game.board.Length; row++)
            {
                for (int column = 0; column < Game.board[row].Length; column++)
                {
                    // found a space with player token
                    if (Game.board[row][column] == player.GetPlayerNum())
                    {
                        // prevents going off Game.board
                        if (row - 3 >= 0 && column + 3 < Game.board[row].Length)
                        {
                            // look for four in a row
                            for (int s = 0; s < 4; s++)
                            {
                                // plug because Game.board looks inverted from index
                                int r = row - s;
                                int c = column + s;

                                if (Game.board[r][c] == player.GetPlayerNum())
                                {
                                    fourInRow++;

                                    // game won
                                    if (fourInRow >= 4)
                                    {
                                        Manager.GameWon(player);
                                        return;
                                    }
                                }
                                else
                                {
                                    fourInRow = 0;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void CheckDiagnalWinDown(Player player)
        {
            int fourInRow = 0;
            // cycles through each space
            for (int row = 0; row < Game.board.Length - 3; row++)
            {
                for (int column = 0; column < Game.board[row].Length; column++)
                {
                    // found a space with player token
                    if (Game.board[row][column] == player.GetPlayerNum())
                    {
                        // prevents going off Game.board
                        if (row + 3 < Game.board.Length && column + 3 < Game.board[row].Length)
                        {
                            // look for four in a row
                            for (int s = 0; s < 4; s++)
                            {
                                // plug because Game.board looks inverted from index
                                int r = row + s;
                                int c = column + s;

                                if (Game.board[r][c] == player.GetPlayerNum())
                                {
                                    fourInRow++;

                                    // game won
                                    if (fourInRow >= 4)
                                    {
                                        Manager.GameWon(player);
                                        return;
                                    }
                                }
                                else
                                {
                                    fourInRow = 0;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void CheckForTie()
        {
            // variable assigned to length of array
            // if variable matches, then all top roles filled
            int numberTaken = 0;
            int numberOfSpaces = Game.board.Length;

            // if all top spaces are taken then game is over
            for (int c = 0; c < Game.board.Length; ++c)
            {
                // no player wins on tie
                if (Game.board[0][c] != 0)
                {
                    numberTaken++;
                }
            }

            // grabs game instance and initiates tied method
            // this will drop the loop in Manager and finish the game
            if (numberTaken == numberOfSpaces)
            {
                Manager.GameTied();
            }
        }
    }
}
