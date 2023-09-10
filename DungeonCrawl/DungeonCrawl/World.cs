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
        public int WorldIndex;
        public World() 
        {
            //Array of rooms
            map = new Room[2];

            map[0] = new OutdoorEntrance(map);
            map[1] = new Cathedral(map);

            setNextRooms();

            for (int i = 0; i < map.Length; i++)
            {
                map[i].OnNextRoom += World_OnNextRoom;
                map[i].OnPrevRoom += World_OnPrevRoom;
            }
        }

        private void World_OnPrevRoom(object? sender, EventArgs e)
        {
            WorldIndex--;
        }

        private void World_OnNextRoom(object? sender, EventArgs e)
        {
            WorldIndex++;
        }

        private void EnterRoom(int n)
        { 
            
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
