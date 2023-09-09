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

        OutdoorEntrance entrace;
        Cathedral cath;

        private World world;
        private int worldIndex;
        public Game() 
        {
            world = new World();

            entrace = new OutdoorEntrance(world.map);
            cath = new Cathedral(world.map);

            world.map[0] = entrace;
            world.map[1] = cath;
            //2-empty, 3-empty, 4-empty
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
                world.map[worldIndex].PresentRoom();
            } while (!gameWin || !gameOver);

            //Intro();
            //ChooseOption();

        }

        private void StartSequence()
        {
            worldIndex= 0;
            p = new Player();
            p.setName();
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
