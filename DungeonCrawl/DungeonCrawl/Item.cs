using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class Item : IUseableItem
    {
        public bool isKeyitem;
        protected virtual string Name { get;  set; }
        protected virtual string Description { get; set; }


        public void DescribeItem()
        {
            Console.WriteLine();
            Util.Print(Name, ConsoleColor.Cyan);
            Util.Print(Description, ConsoleColor.DarkCyan);

        }

        public virtual void UseItem()
        {
            
        }
    }
}
