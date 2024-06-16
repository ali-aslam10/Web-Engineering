using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLab2
{
    class MultiPlayerGame
    {
        private static int playerCount=0;
        public void addPlayer()
        {
            playerCount++;
        }
        public void removePlayer()
        {
            if(playerCount>0)
            {
                playerCount--;
            }
        }
        public int getPlayerCount()
        {
            return playerCount;
        }
    }
}
