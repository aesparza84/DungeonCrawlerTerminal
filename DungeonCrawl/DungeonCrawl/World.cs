using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class World
    {
        public Room[] map;
        public World() 
        {
            //Array of rooms. 0 & 1 are preoocupide;
            map = new Room[5];

            map[0] = new OutdoorEntrance(map);
            map[1] = new Cathedral(map);

            setNextRooms();
        }

        public void AddRoom(Room m)
        {
            map.Append(m);
        }

        void setNextRooms()
        {
            int index;
            for (int i = 0; i < map.Length; i++)
            {
                index= i;

                if (map[index] != null)
                {
                    if (index + 1 < map.Length && map[index + 1] != null)
                    {
                        map[index].nextRoom = map[index + 1];
                    }

                    if (index > 0 && map[index - 1] != null)
                    {
                        map[index].prevRoom = map[index - 1];
                    }

                }
                
            }
        }


    }
}
