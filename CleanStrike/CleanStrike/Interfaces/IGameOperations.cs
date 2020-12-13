using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CleanStrike.BusinessEntities;

namespace CleanStrike.Interfaces
{
    interface IGameOperations
    {
        void Strike(Player player,ref int coin);
        void Multistrike(Player player,ref int coin);
        void Redstrike(Player player,ref int coin,ref bool isRedCoinPresent);
        void Strikerstrike(Player player);
        void DefunctCoin(Player player,ref int coin);
        bool CheckPoints(Player player1, Player player2);
    }
}
