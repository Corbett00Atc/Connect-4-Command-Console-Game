using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

/*
 * Connect Four Game
 */

namespace ConnectFour
{
    class Program
    {
        public static Game manager = new Game();
        public static Player playerOne = new Player(1);
        public static Player playerTwo = new Player(2);

        static void Main(string[] args)
        {
            Manager.InitializeGame();
            ReadKey();
        }
    }
}
