using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class Item : IUseableItem
    {
        protected virtual string Name { get;  set; }
        protected virtual string Description { get; set; }
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
