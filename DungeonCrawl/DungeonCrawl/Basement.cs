using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class Basement: Room
    {
        public Basement(Player p) 
        {
            roomInventory = new List<Item>();
            //roomInventory.Add();
            passedPlayer= p;

            Info = "The basement is dark but you can still see. A large chest rests in the middle. There are also 2 paths you can go through: the left has" +
                "a funky smell; the right has a dark aura around the entrance";
            Question = "What do you wish to do?";

            options = new string[5];
            addOption("Walk through the left", 0);
            addOption("Walk through the right", 1);
            addOption("Open the chest", 2);
            addOption("Go back upstairs", 3);
            addOption("Display Inventory", 4);
        }
        public override void ChooseOption()
        {
            bool makingDecision = false;
            showOptions();
            do
            {
                passedPlayer.CheckHP();
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
                            MoveToSubOne(); 
                            Console.WriteLine("You decide to go trough the left door");
                            Console.ReadLine();
                            makingDecision = true;
                            break;
                        case 2:
                            MoveToSubTwo();
                            Console.WriteLine("You decide to go trough the right door");
                            Console.ReadLine();
                            makingDecision= true;
                            break;
                        case 3:
                            if (passedPlayer.LookForItemType(new ChestKey()))
                            {
                                Console.WriteLine("You open the chest");
                                Console.WriteLine($"There is a |{roomInventory.First().GetName()}|");
                            }
                            else
                            {
                                Console.WriteLine("Hmmm, needs a key");
                            }

                            break;
                        case 4:
                            MoveToPrevRoom();
                            makingDecision= true;
                            break;
                        case 5:
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
        //                    Util.Print("You decide to enter the left door. 'Any Key' to continue", ConsoleColor.Green);

        //                    //We move into Sub Room 1
        //                    MoveToSubOne();

        //                    Console.ReadKey();
        //                    makingDecision = true;
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
        //                    Util.Print("You decide to enter the right door. 'Any Key' to continue", ConsoleColor.Green);

        //                    //We move into Sub Room 2
        //                    MoveToSubTwo();

        //                    Console.ReadKey();
        //                    makingDecision = true;
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
        //                    Util.Print("You decide to enter the right door. 'Any Key' to continue", ConsoleColor.Green);

        //                    //We move into Sub Room 2
        //                    MoveToSubTwo();

        //                    Console.ReadKey();
        //                    makingDecision = true;
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
           
                Util.Print(Art.PrintDoubleDoor(), ConsoleColor.DarkGray);
            
        }
    }
}
