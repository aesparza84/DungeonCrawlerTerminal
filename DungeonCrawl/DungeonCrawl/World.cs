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
        public int WorldIndex { get; private set; }
        private int baseRoomIndex;
        private Player passedPlayer;
        public World(Player p) 
        {
            passedPlayer= p;
            //Array of rooms
            map = new Room[4];

            map[0] = new OutdoorEntrance(passedPlayer);
            map[1] = new Cathedral(passedPlayer);
            map[2] = new Basement(passedPlayer);
            map[3] = new Sewers(passedPlayer);

            setNextRooms();

            for (int i = 0; i < map.Length; i++)
            {
                map[i].OnNextRoom += World_OnNextRoom;
                map[i].OnPrevRoom += World_OnPrevRoom;
                map[i].OnSubRoomOne += World_OnSubRoomOne;
                map[i].OnSubRoomTwo += World_OnSubRoomTwo;
                map[i].OnBaseRoom += World_OnBaseRoom;
            }
        }

        private void World_OnBaseRoom(object? sender, EventArgs e)
        {
            WorldIndex = baseRoomIndex;
        }

        private void World_OnSubRoomTwo(object? sender, EventArgs e)
        {
            baseRoomIndex = WorldIndex;
            WorldIndex += 2;
        }

        private void World_OnSubRoomOne(object? sender, EventArgs e)
        {
            baseRoomIndex = WorldIndex;
            WorldIndex += 1;
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
