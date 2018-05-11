using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    static class StoryElements
    {


        public static Dictionary<string, string> Encounters = new Dictionary<string, string>()
        {
            {"spider", "You encounter a mighty spider. You ready your weapon and prepare to strike..."},
            {"spider2", "Kill it before it lays eggs!"},
            {"dragon", "Oh few, it´s just a dragon"}
        };

        public static Dictionary<string, string> Options = new Dictionary<string, string>()
        {
            {"explore", "(E) Explore this room"},
            {"retire", "(R) Return to the Inn"},
            {"next", "(Any key) See what happens next"},
            ////////////////////
            {"survived", "You have vanquished your puny enemy. A great sense of pride overwhelmes you. After all, if you don´t cheer for yourself, nobody will. Huzzah!"}
        };


    }



}


