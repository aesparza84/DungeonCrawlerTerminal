using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class Item : IUseableItem
    {
        protected bool isKeyitem;
        protected virtual string Name { get;  set; }
        protected virtual string Description { get; set; }


        public void DescribeItem()
        {
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.WriteLine(Name);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(Description);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public virtual void UseItem()
        {
            
        }
    }
}
