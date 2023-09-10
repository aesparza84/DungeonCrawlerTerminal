using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class Catacombs : Room
    {
        bool skeletonDisabled;
        int skellyPatience;
        public Catacombs(Player p)
        {
            roomInventory = new List<Item>();
            roomInventory.Add(new Bracelet());

            skeletonDisabled = false;
            skellyPatience = 0;

            passedPlayer = p;

            Info = "The catacombs are dark and dusty. Audible *clacks* are approaching, and you find yourself face to face with a violent skeleton.\n " +
                "You notice that they're wearing a dazzling bracelet.";
            Question = "What do you wish to do?";

            options = new string[4];
            addOption("Take the bracelet", 0);
            addOption("Attack the skeleton", 1);
            addOption("Go back upstairs", 2);
            addOption("Display Inventory", 3);
        }

        public override void ChooseOption()
        {
            bool makingDecision = false;
            showOptions();
            do
            {
                if (passedPlayer.HasDied())
                {
                    makingDecision = true;
                }
                string input = Console.ReadLine();
                if (!Int32.TryParse(input, out int number))
                {
                    Console.WriteLine("Enter a valid number");
                }
                else
                {
                    switch (number)
                    {
                        case 1:
                            if (!skeletonDisabled)
                            {
                                if (skellyPatience < 2)
                                {
                                    Console.WriteLine("You gesture for the bracelet, but the skeleton gets more aggressive");
                                    skellyPatience++;
                                }
                                else
                                {
                                    Console.WriteLine("The skeleton is furious!");
                                    passedPlayer.takeDamage(20);
                                }
                            }
                            else
                            {
                                if (!passedPlayer.LookForItemType(new Bracelet()))
                                {
                                    
                                    Console.WriteLine("You the rummage through the pile of bones.");
                                    passedPlayer.PickUpItem(roomInventory.First());
                                }
                                else
                                { 
                                    Console.WriteLine("You alrady picked up the item");
                                }
                            }
                            break;

                        case 2:
                            if (!skeletonDisabled)
                            {
                                if (passedPlayer.LookForItemType(new Sword()))
                                {
                                    skeletonDisabled = true;
                                    Console.Clear();
                                    RoomUI();
                                    showOptions();
                                    Console.WriteLine("You used the sword you found to slay the skeleton!");
                                }
                                else
                                {
                                    Console.WriteLine("You have nothing to attack it with");
                                }
                            }
                            else
                            {
                                Console.WriteLine("The skeleton is already dead.");
                            }                            
                            break;

                        case 3:
                            MoveToBaseRoom();
                            makingDecision = true;
                            break;

                        case 4:
                            passedPlayer.DisplayInventory();
                            break;

                        default:
                            break;
                    }
                }
            } while (!makingDecision);
        }

        public override void PresentRoom()
        {
            Console.Clear();
            RoomUI();
            ChooseOption();
        }

        public override void showArt()
        {
            if (!skeletonDisabled)
            {
                Util.Print(Art.PrintSkelly(), ConsoleColor.DarkYellow);
            }
            else
            {
                Util.Print(Art.PrintSkellyDead(), ConsoleColor.DarkYellow);
            }

        }
    }
}
