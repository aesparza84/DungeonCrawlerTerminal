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
        private Item[] inven;

        private bool hasBracelet;
        private bool hasChestKey;
        private bool hasSword;


        public Room currentRoom;
        public Player()
        {
            Name = "";
            Health = 100;
            inventory= new List<Item>();
            inven = new Item[3];

            PickUpItem(new ChestKey());
        }

        public event EventHandler OnDeath;
        public event EventHandler OnWin;

        public void OnDeathEvent()
        { 
            OnDeath?.Invoke(this, EventArgs.Empty);
        }

        public void OnWinEvent()
        { 
            OnWin?.Invoke(this, EventArgs.Empty);
        }

        public void takeDamage(float dmg)
        {
            Health -= dmg;
        }

        public void CheckHP()
        {
            if (Health <= 0.0f)
            {
                OnDeathEvent();
            }
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
            inven = inventory.ToArray();
            //var inv = inventory.ToArray();

            if (inventory.Count==0)
            {
                Console.WriteLine("Nothing to display");
            }
            else
            {
                for (int i = 0; i < inven.Length; i++)
                {
                    Util.Print($"{i + 1}. {inven[i].DescribeItem()}", ConsoleColor.DarkCyan);
                }
            }
            
        }
        public void PickUpItem(Item i)
        { 
            inventory.Add(i);
            Console.WriteLine($"You aquired a {i.GetName}");
        }

        public bool LookForItemType(Item t)
        {
            inven = inventory.ToArray();
            for (int i = 0; i < inven.Length; i++)
            {
                if (inven[i].GetType() == t.GetType())
                {
                    return true;
                }
            }
            //foreach (Item item in inventory)
            //{
            //    if (item.GetType() == t.GetType())
            //    {
            //        return true;
            //    }
            //}
            return false;
        }

    }
}
