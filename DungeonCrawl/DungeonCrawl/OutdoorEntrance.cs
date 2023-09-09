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
        public OutdoorEntrance(Room[] world) 
        {
            world = passedWorld;

            waitCounter= 0;
            Info = "You stand before the Cathedral of Liam, know to hold the powerful treasure.";
            Question = "What do you wish to do?";

            options = new string[2];
            addOption("Enter the cathedral",0);
            addOption("Stand around for a bit...", 1);
        }

        public override bool ChooseOption()
        {
            
            bool makingDecision = false;
            int index = 0;

            ConsoleKey keyInfo = new ConsoleKey();

            do
            {
                RoomUI();
                if (index > options.Length)
                {
                    index = 0;
                }

                //highlight hover option
                ShowOptions(index);

                switch (index)
                {
                    case 0:
                        keyInfo = Console.ReadKey().Key;
                        if (keyInfo == ConsoleKey.Enter)
                        {
                            Util.Print("You decide to enter. 'Any Key' to continue", ConsoleColor.Green);
                            makingDecision = true;
                        }
                        else if (keyInfo == ConsoleKey.Tab)
                        {
                            index++;
                        }
                        break;

                    case 1:
                        
                        keyInfo = Console.ReadKey().Key;
                        if (keyInfo == ConsoleKey.Enter)
                        {
                            if (waitCounter < 3)
                            {
                                Util.Print("You stand outside for a bit. 'Any Key' to continue", ConsoleColor.Green);
                                Console.ReadKey();
                                waitCounter++;
                            }
                            else
                            {
                                Util.PrintN("No more waiting", ConsoleColor.DarkRed);
                                makingDecision = true;
                            }

                        }
                        else if (keyInfo == ConsoleKey.Tab)
                        {
                            index++;
                        }
                        break;

                    default:
                        index = 0;
                        break;
                }
            } while (!makingDecision);

            return makingDecision;
        }

        private void RoomUI()
        {
            Console.Clear();
            showArt();
            AskQuestion();
        }

        public override void PresentRoom()
        {
            base.PresentRoom();
            ChooseOption();
        }

        public override void showArt()
        {
            Util.Print(Art.PrintChurch(), ConsoleColor.DarkRed);
        }
    }
}
