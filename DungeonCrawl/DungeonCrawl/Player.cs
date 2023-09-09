using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class Player : IDamagable
    {
        public float Health { get; set; }
        public string Name { get; set; }
        public List<Item> inventory;
        private Item equippedItem;
        public Player()
        {
            Name = "";
            Health = 100;
            inventory= new List<Item>();
            equippedItem = new Item();
        }

        public void takeDamage(float dmg)
        {
            Health -= dmg;
        }

        public void setName()
        {
            string input;
            bool done = false;
            do
            {
                Util.Print("What is your name?", ConsoleColor.DarkYellow);
                input = Console.ReadLine();
                if (input.Any(char.IsDigit) || !input.Any(char.IsLetter))
                {
                    Util.Print("Only letters, try again", ConsoleColor.DarkRed);
                }
                else
                {
                    done = true;
                }

            } while (!done);
            Name = input;
        }

        public void DisplayInventory()
        {
            foreach (Item item in inventory)
            {
                item.DescribeItem();
            }
        }

        public void PickUpItem(Item i)
        { 
            inventory.Add(i);
        }
    }
}
