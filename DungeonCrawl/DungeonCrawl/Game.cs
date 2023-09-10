using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class Game
    {
        private bool gameOver, gameWin, playerDone;
        string input;
        Player p;
        private int worldIndex;

        private World world;
        public Game() 
        {
            p = new Player();
            p.OnDeath += P_OnDeath;
            p.OnWin += P_OnWin;


            world = new World(p);
            worldIndex= 0;
        }

        private void P_OnWin(object? sender, EventArgs e)
        {
            gameWin= true;  
        }

        private void P_OnDeath(object? sender, EventArgs e)
        {
            gameOver= true;
        }

        public void RunGame()
        {
            do
            {
                Menu();
            } while (!playerDone);
            Environment.Exit(0);
        }

        private void ResetGame()
        {
            p.OnDeath-= P_OnDeath;
            p.OnWin-= P_OnWin;

            p = new Player();
            p.OnDeath += P_OnDeath;
            p.OnWin += P_OnWin;
            world = new World(p);
            worldIndex= 0;
        }

        public void NewGame() 
        {
            ResetGame();
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

                

            } while (!gameWin && !gameOver);

            if (gameWin)
            {
                Util.Print("YOU WIN!!!", ConsoleColor.Cyan);
            }
            else if (gameOver)
            {
                Util.Print("You Lose.", ConsoleColor.Red);
            }
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

        private void Menu()
        {
            
            bool done = false;

            ConsoleKey keyInfo = new ConsoleKey();

            do
            {
                Util.Print("Press 'R' to restart, 'Q' to exit app", ConsoleColor.Gray);
                keyInfo = Console.ReadKey().Key;
                if (keyInfo != ConsoleKey.R && keyInfo != ConsoleKey.Q)
                {
                    Util.Print("Invalid, enter R or Q",ConsoleColor.Red);
                }
                switch (keyInfo)
                {
                    case ConsoleKey.R:
                        Console.Clear();
                        NewGame();
                        break;
                    case ConsoleKey.Q:
                        playerDone= true;
                        done= true;
                        break;
                }

            } while (!done);
            

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
