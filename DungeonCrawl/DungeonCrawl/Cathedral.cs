using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class Cathedral : Room
    {
        bool statueDestroyed;
        public Cathedral(Player p) 
        {
            statueDestroyed= false;
            passedPlayer =p;

            roomInventory = new List<Item>();
            roomInventory.Add(new Chalice());

            Info = "Inside the Cathedral stands a menacing statue with glowing eyes. Behind it, however, is a golden chalice." +
                "You also notice an open door to the side that has a steady breeze.";
            Question = "What do you wish to do?";

            options = new string[4];
            addOption("Approach the chalice", 0);
            addOption("Walk through the door", 1);
            addOption("Exit through the front",2);
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
                else
                {
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
                                if (!passedPlayer.LookForItemType(new Bracelet()))
                                {
                                    Util.Print("As you approach the statue it fires a beam at you, preventing you from stepping closer.\nIf only you can reflect it...\n", ConsoleColor.White);
                                    passedPlayer.takeDamage(50.0f);
                                }
                                else
                                {
                                    if (!statueDestroyed)
                                    {
                                        statueDestroyed = true;
                                        Util.Print("The beam reflects off the bracelet and destroys the statue. You pick up the Chalice", ConsoleColor.Yellow);

                                        Console.ReadKey();
                                        Console.Clear();
                                        RoomUI();
                                        showOptions();
                                        passedPlayer.PickUpItem(roomInventory.First());
                                    }
                                    else
                                    {
                                        Util.Print("You already have the treasure", ConsoleColor.DarkYellow);
                                    }
                                }
                                break;
                            case 2:
                                MoveToNextRoom();
                                makingDecision = true;
                                break;
                            case 3:
                                MoveToPrevRoom();
                                makingDecision = true;
                                break;
                            case 4:
                                passedPlayer.DisplayInventory();
                                break;

                            default:

                                break;
                        }
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
        //                    Util.Print("You approach the statue. 'Any Key' to continue", ConsoleColor.Green);

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
        //                    Util.Print("You decide to invesitgate the side door. 'Any Key' to continue", ConsoleColor.Green);

        //                    //We move into the next room
        //                    MoveToNextRoom();


        //                    Console.ReadKey();
        //                    makingDecision= true;
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
        //                    Util.Print("You decide to leave throught the front. 'Any Key' to continue", ConsoleColor.Green);

        //                    //We move back to entrance
        //                    MoveToPrevRoom();


        //                    Console.ReadKey();
        //                    makingDecision= true;
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
            if (!statueDestroyed)
            {
                Util.Print(Art.PrintStatue(), ConsoleColor.DarkMagenta);
            }
            else
            {
                Util.Print(Art.PrintStatueBroken(), ConsoleColor.DarkMagenta);
            }
        }
    }
}
