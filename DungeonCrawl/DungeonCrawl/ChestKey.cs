using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public class ChestKey : Item
    {
        public ChestKey() 
        {
            isKeyitem = false;
            Name = "Chest Key";
            Description = "A large key, can probably open something";
        }
    }
}
