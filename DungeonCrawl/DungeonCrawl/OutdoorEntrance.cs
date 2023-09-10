using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class OutdoorEntrance: Room
    {
        int waitCounter;
        public OutdoorEntrance(Player p) 
        {
            passedPlayer= p;

            waitCounter = 0;
            Info = "You stand before the Cathedral of Liam, know to hold the powerful treasure.";
            Question = "What do you wish to do?";

            options = new string[3];
            addOption("Enter the cathedral",0);
            addOption(" Stand around for a bit...", 1);
            addOption(" Display Inventory",2);
        }

        public override void ChooseOption()
        {            
            bool makingDecision = false;
            showOptions();
            do
            {
                passedPlayer.HasDied();
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
                            MoveToNextRoom();
                            makingDecision= true;
                            break;
                        case 2:
                            if (waitCounter < 3)
                            {
                                waitCounter++;
                                Console.WriteLine("You wait around a bit");
                            }
                            else
                            {
                                Console.WriteLine("No more waiting");
                                Console.ReadLine();
                                MoveToNextRoom();
                                makingDecision = true;
                            }
                                break; 
                        case 3:
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
            Util.Print(Art.PrintChurch(), ConsoleColor.DarkRed);
        }
    }
}
