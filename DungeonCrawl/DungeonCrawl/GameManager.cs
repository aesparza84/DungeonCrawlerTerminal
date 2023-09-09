using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class GameManager
    {
        private bool gameOver, gameWin;
        string input;
        Player p;

        private string[] Options;
        string opt;
        public GameManager() 
        {
            Options = new string[4];
            Options[3] = "Run";
        }
        public void RunGame() 
        {
            p = new Player();
            Intro();
        }

        private void Intro()
        {
            Console.WriteLine("What is your name traveler?");
            p.setName();

            Bracelet b = new Bracelet();
            p.PickUpItem(b);

            ChestKey s = new ChestKey();
            p.PickUpItem(s);

            Console.Clear();
            DispalyHud();
        }


        void DispalyHud()
        {
            Console.WriteLine(p.Name +" "+"Inventory: \n");
            p.DisplayInventory();

            Console.WriteLine("----------------------------------------------------");
        }
    }
}
