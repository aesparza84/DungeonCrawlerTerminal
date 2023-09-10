using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class Game
    {
        private bool gameOver, gameWin, makingDecision;
        string input;
        Player p;
        private int worldIndex;

        private World world;
        public Game() 
        {
            p = new Player();
            world = new World();
            worldIndex= 0;
        }

        

        public void NewGame() 
        {
            //Start Game - !gameOver, !gameWin, 
                //Player chooses name
                // ASCII church and enter ReadKey

            // while !gameWin
                //Loop thru array of choices
                    //Loop thru array of 'ROOMS'


            StartSequence();

            Util.Print("Hello "+p.Name, ConsoleColor.Blue);

            do
            {
                worldIndex = world.WorldIndex;
                p.currentRoom = world.map[worldIndex];
                //Enter the 1st room 
                world.map[worldIndex].PresentRoom();

            } while (!gameWin || !gameOver);

            //Intro();
            //ChooseOption();

        }

        private void StartSequence()
        {
            //worldIndex= 0;
            
            p.setName();
            p.currentRoom = world.map[worldIndex];
            gameOver = false;
            gameWin = false; 
        }        

        void DispalyHud()
        {
            Console.Clear();
            Console.WriteLine(p.Name +" "+"Inventory: \n");
            p.DisplayInventory();

            Console.WriteLine("----------------------------------------------------");
        }


    }
}
