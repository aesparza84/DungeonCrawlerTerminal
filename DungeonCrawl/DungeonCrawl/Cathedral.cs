using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class Cathedral : Room
    {
        public Cathedral(Room[] world) 
        {
            passedWorld = world;

            Info = "Inside the Cathedral stands a menacing statue with glowing eyes. Behind it, however, is a golden chalice." +
                "You also notice an open door to the side that has a steady breeze.";
            Question = "What do you wish to do?";

            options = new string[3];
            addOption("Approach the chalice", 0);
            addOption("Walk through the door", 1);
            addOption("Exit through the front",2);
        }
    }
}
