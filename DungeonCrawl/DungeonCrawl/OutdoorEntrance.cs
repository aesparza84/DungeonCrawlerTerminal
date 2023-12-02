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
            Info = "You stand before the Cathedral of Liam, known to hold the powerful treasure.";
            Question = "What do you wish to do?";

            options = new string[4];
            addOption("Enter the cathedral",0);
            addOption("Stand around for a bit...", 1);
            addOption("Leave the property",2);
            addOption("Display Inventory",3);
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
                                Util.Print("No more waiting", ConsoleColor.DarkRed);
                                Console.ReadLine();
                                MoveToNextRoom();
                                makingDecision = true;
                            }
                                break; 
                        case 3:
                            if (!passedPlayer.LookForItemType(new Chalice()))
                            {
                                Console.WriteLine("You don't have the powerful treasure yet");
                            }
                            else
                            {
                                passedPlayer.OnWinEvent();
                                makingDecision= true;
                            }
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
            Util.Print(Art.PrintChurch(), ConsoleColor.DarkRed);
        }
    }
}
