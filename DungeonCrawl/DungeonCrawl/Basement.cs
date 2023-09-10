using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class Basement: Room
    {
        private Room[] subRooms;
        public Basement(Room[] world, int connectingCount) 
        {
            passedWorld= world;

            subRooms = new Room[connectingCount];


            Info = "The basement is dark but you can still see. There are 2 paths you can go through: the left has" +
                "a funky smell; the right has a dark aura around the entrance";
            Question = "What do you wish to do?";

            options = new string[3];
            addOption("Walk through the left", 0);
            addOption("Walk through the right", 1);
            addOption("Go back upstairs", 2);
        }
    }
}
