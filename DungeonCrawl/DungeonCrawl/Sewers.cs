using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class Sewers:Room
    {
        bool BatDisabled;
        public Sewers(Player p) 
        {
            roomInventory = new List<Item>();
            roomInventory.Add(new ChestKey());

            passedPlayer= p;
            BatDisabled= false;

            Info = "You drop into the sewers where it stinks to high heaven. You notice a giant bat dozing off above. " +
                "Within its wings is something shiny.";
            Question = "What do you wish to do?";

            options = new string[4];
            addOption("Throw a rock", 0);
            addOption("Stand around for a bit...", 1);
            addOption("Go back through the door", 2);
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
                            break;
                        case 2:
                            break;
                        case 3:
                            MoveToBaseRoom();
                            makingDecision= true;
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

        //public override void ChooseOption()
        //{

        //    bool makingDecision = false;
        //    int index = 0;

        //    ConsoleKey keyInfo = new ConsoleKey();

        //    do
        //    {
        //        RoomUI();
        //        if (index > options.Length)
        //        {
        //            index = 0;
        //        }

        //        //highlight hover option
        //        ShowOptions(index);

        //        switch (index)
        //        {
        //            case 0:
        //                keyInfo = Console.ReadKey().Key;
        //                if (keyInfo == ConsoleKey.Enter)
        //                {

        //                }
        //                else if (keyInfo == ConsoleKey.Tab)
        //                {
        //                    index++;
        //                }
        //                break;

        //            case 1:

        //                keyInfo = Console.ReadKey().Key;
        //                if (keyInfo == ConsoleKey.Enter)
        //                {

        //                }
        //                else if (keyInfo == ConsoleKey.Tab)
        //                {
        //                    index++;
        //                }
        //                break;

        //            case 2:
        //                keyInfo = Console.ReadKey().Key;
        //                if (keyInfo == ConsoleKey.Enter)
        //                {

        //                }
        //                else if (keyInfo == ConsoleKey.Tab)
        //                {
        //                    index++;
        //                }
        //                break;

        //            default:
        //                index = 0;
        //                break;
        //        }
        //    } while (!makingDecision);
        //}

        public override void PresentRoom()
        {
            Console.Clear();
            RoomUI();
            ChooseOption();
        }
        public override void showArt()
        {
            Util.Print(Art.PrintStatue(), ConsoleColor.DarkMagenta);
        }
    }
}
