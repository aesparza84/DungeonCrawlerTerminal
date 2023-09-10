using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class Room :IRoom
    {
        public Room nextRoom, prevRoom;

        protected string[] options;
        protected string Question, Info;
        public string Name;

        protected Room[] passedWorld;

        public event EventHandler OnNextRoom;
        public event EventHandler OnPrevRoom;

        public Room() { }
        public Room(Room[] world) 
        {
            passedWorld= world;
            Name = "";
        }

        protected void MoveToNextRoom()
        { 
            OnNextRoom?.Invoke(this, new EventArgs());
        }

        protected void MoveToPrevRoom()
        {
            OnPrevRoom?.Invoke(this, new EventArgs());
        }



        public void ShowOptions()
        {
            for (int i = 0; i < options.Length; i++)
            {
                Util.Print("- "+options[i], ConsoleColor.DarkYellow);
            }
        }

        public void ShowOptions(int n)
        {
            for (int i = 0; i < options.Length; i++)
            {
                if (i == n)
                {
                    Util.Print("   --> " + options[i], ConsoleColor.Cyan);
                }
                else
                {
                    Util.Print("- " + options[i], ConsoleColor.DarkYellow);
                }
            }
        }
        public virtual void ChooseOption() { }

        protected void addOption(string message, int index)
        {
            options[index] = message;
        }

       

        protected void AskQuestion()
        {
            //Console.WriteLine(Question);
            Util.Print(Info, ConsoleColor.Yellow);
            Util.PrintN(Question + " 'TAB to select", ConsoleColor.Red);
        }

        public virtual void PresentRoom()
        { 
           
        }
        public virtual void showArt() { }

        protected void RoomUI()
        {
            Console.Clear();
            showArt();
            AskQuestion();
        }
    }
}
