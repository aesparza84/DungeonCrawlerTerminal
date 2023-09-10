using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawl
{
    public interface IRoom
    {
        // void ShowOptions();
        void showArt();
        void ShowOptions(int n);
        void ChooseOption();
    }
}
