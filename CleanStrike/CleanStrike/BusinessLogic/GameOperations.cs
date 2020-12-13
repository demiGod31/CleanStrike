using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CleanStrike.BusinessEntities;
using CleanStrike.Interfaces;

namespace CleanStrike.BusinessLogic
{
    //This class contains all the game operations for the Carrom Game
    class GameOperations: IGameOperations
    {
        public void Strike(Player player, ref int coins)
        {
            player.foulCount=0;
            player.points++;
            coins--;
        }
        public void Multistrike(Player player, ref int coins)
        {
            player.foulCount = 0;
            player.points+=2;
            coins-=2;
        }
        public void Redstrike(Player player, ref int coins, ref bool isRedCoinPresent)
        {
            if (isRedCoinPresent)
            {
                player.foulCount = 0;
                player.points += 3;
                coins--;
                isRedCoinPresent = false;
            }
            else
            {
                Console.WriteLine("Red Coin is not present on boards. Turn Lost.");
            }
        }
        public void Strikerstrike(Player player)
        {
            player.foulCount++;
            if (player.foulCount >= 3)
            {
                player.points--;
                player.foulCount = 0;
            }
            player.points--;
        }
        public void DefunctCoin(Player player, ref int coins)
        {
            player.foulCount++;
            if (player.foulCount >= 3)
            {
                player.points--;
                player.foulCount = 0;
            }
            player.points-=2;
            coins--;
        }
        //This Method is used to compare the points of the two players
        public bool CheckPoints(Player player1, Player player2)
        {
            if (player1.points >= 5 && player1.points - player2.points >= 3)
            {
                Console.WriteLine("Player 1 won the game. Final Score: {0}:{1}", player1.points, player2.points);
                return true;
            }
            else if (player2.points >= 5 && player2.points - player1.points >= 3)
            {
                Console.WriteLine("Player 2 won the game. Final Score: {0}:{1}", player1.points, player2.points);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
