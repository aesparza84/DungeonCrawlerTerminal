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

        private Room[] rooms;
        public Game() 
        {
            // Random rooms, max of 4;
            rooms = new Room[5];

            entrace = new OutdoorEntrance(rooms);
            cath = new Cathedral(rooms);

            rooms[0] = entrace;
            rooms[1] = cath;
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

            OutdoorEntrance d = new OutdoorEntrance(rooms);
            d.PresentRoom();

            //Intro();
            //ChooseOption();

        }

        private void StartSequence()
        {
            p = new Player();
            p.setName();
            gameOver = false;
            gameWin = false; 
        }

        private void decisionLoop(Room rm)
        {
            do
            {

            } while (!rm.ChooseOption());
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
