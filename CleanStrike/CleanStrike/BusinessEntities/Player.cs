using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanStrike.BusinessEntities
{
    // This is a class of Player which has all the basic properties of a Player.
    class Player
    {
        public string name { get; set; }
        public int points { get; set; }
        public int foulCount { get; set; }
    }
}
