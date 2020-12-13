using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CleanStrike.Interfaces;
using CleanStrike.BusinessEntities;
using CleanStrike.Constants;

namespace CleanStrike.BusinessLogic
{
    class NewGame: INewGame
    {
        // This function contains the logic to start the game and it's game flow.
        public void StartGame(int[] input)
        {
            Player player1 = new Player() { name = "Player 1", points = 0, foulCount = 0 };
            Player player2 = new Player() { name = "Player 2", points = 0, foulCount = 0 };
            int _turn = 0,_coins = 10,selectedOption;
            bool _isRedCoinPresent = true;
            Player currentPlayer = player1;
            IGameOperations gameOperations = new GameOperations();

            for (int i = 0; i < input.Length;i++ )
            {
                while (_coins > 0)
                {
                    try
                    {
                        if (gameOperations.CheckPoints(player1, player2))
                        {
                            Console.WriteLine("Thanks for playing!");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                        currentPlayer = _turn % 2 == 0 ? player1 : player2;
                        DisplayGameOptions(currentPlayer.name);

                        selectedOption = input[i];
                        switch (selectedOption)
                        {
                            case (int)GameConstants.GameOptions.Strike:
                                gameOperations.Strike(currentPlayer, ref _coins);
                                break;
                            case (int)GameConstants.GameOptions.Multistrike:
                                gameOperations.Multistrike(currentPlayer, ref _coins);
                                break;
                            case (int)GameConstants.GameOptions.Redstrike:
                                gameOperations.Redstrike(currentPlayer, ref _coins, ref _isRedCoinPresent);
                                break;
                            case (int)GameConstants.GameOptions.Strikerstrike:
                                gameOperations.Strikerstrike(currentPlayer);
                                break;
                            case (int)GameConstants.GameOptions.DefunctCoin:
                                gameOperations.DefunctCoin(currentPlayer, ref _coins);
                                break;
                            case (int)GameConstants.GameOptions.None:
                                break;
                            case (int)GameConstants.GameOptions.Exit:
                                Console.WriteLine("Thanks for playing!");
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Please Choose an outcome from the list below only. Turn Lost.");
                                break;
                        }
                    }
                    catch (FormatException formatException)
                    {
                        Console.WriteLine("Please enter only numbers from the list. Turn Lost.");
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    Console.WriteLine("Score:- Player 1: {0} Player 2: {1}", player1.points, player2.points);
                    Console.WriteLine("Coins Remaining on Board: {0}\n", _coins);
                    _turn++;
                }
                if (!gameOperations.CheckPoints(player1, player2))
                {
                    Console.WriteLine("The Game has been drawn!");
                }
                Console.WriteLine("Thanks for playing!");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        //Displays the Game Options
        public void DisplayGameOptions(string name)
        {
            Console.WriteLine(name + ": Choose an outcome from the list below\n");
            foreach (GameConstants.GameOptions gameOption in Enum.GetValues(typeof(GameConstants.GameOptions)))
            {
                Console.WriteLine((int)gameOption +". "+   gameOption);
            }
        }
    }
}
