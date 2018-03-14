using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    class Player
    {
        readonly int playerNumber;
        private bool playerWon = false;

        public Player(int playerNumber)
        {
            this.playerNumber = playerNumber;
        }

        public int GetPlayerNum()
        {
            return playerNumber;
        }

        public void PlayerWon()
        {
            Manager.GameWon(this);
            playerWon = true;
        }

        public bool DidPlayerWon()
        {
            return playerWon;
        }
    }
}
