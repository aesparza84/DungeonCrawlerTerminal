using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class Item : IUseableItem
    {
        public string Name { get;  set; }
        protected string Description { get; set; }

        public Item() 
        {
            Name = "";
            Description = "";
        }
        public string DescribeItem()
        {
            return Name+"\n" + "    "+Description;

        }

        public virtual void UseItem()
        {
            
        }

        public string GetName()
        {
            return Name;
        }
    }
}
