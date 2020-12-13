using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanStrike.Constants
{
    //This class contains all game constants for the Carrom Game
    class GameConstants
    {
        public enum GameOptions
        {
            Strike = 1,
            Multistrike,
            Redstrike,
            Strikerstrike,
            DefunctCoin,
            None,
            Exit

        };
    }
}
