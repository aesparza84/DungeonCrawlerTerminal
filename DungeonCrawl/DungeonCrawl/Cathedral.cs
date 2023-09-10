using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class Cathedral : Room
    {
        public Cathedral(Room[] world) 
        {
            passedWorld = world;

            Info = "Inside the Cathedral stands a menacing statue with glowing eyes. Behind it, however, is a golden chalice." +
                "You also notice an open door to the side that has a steady breeze.";
            Question = "What do you wish to do?";

            options = new string[3];
            addOption("Approach the chalice", 0);
            addOption("Walk through the door", 1);
            addOption("Exit through the front",2);
        }

        public override void ChooseOption()
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
                            Util.Print("You approach the statue. 'Any Key' to continue", ConsoleColor.Green);

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
                            Util.Print("You decide to invesitgate the side door. 'Any Key' to continue", ConsoleColor.Green);

                            //We move into the next room



                            Console.ReadKey();
                            makingDecision= true;
                        }
                        else if (keyInfo == ConsoleKey.Tab)
                        {
                            index++;
                        }
                        break;

                    case 2:
                        keyInfo = Console.ReadKey().Key;
                        if (keyInfo == ConsoleKey.Enter)
                        {
                            Util.Print("You decide to leave throught the front. 'Any Key' to continue", ConsoleColor.Green);

                            //We move back to entrance
                          


                            Console.ReadKey();
                            makingDecision= true;
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

         
        }

        public override void PresentRoom()
        {
            ChooseOption();
        }
        public override void showArt()
        {
            Util.Print(Art.PrintStatue(), ConsoleColor.DarkMagenta);
        }
    }
}
