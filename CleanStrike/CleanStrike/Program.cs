using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CleanStrike.Interfaces;
using CleanStrike.BusinessLogic;
using System.IO;

namespace CleanStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                // Creates the object of Carrom game.
                string inputFile = File.ReadAllText(Environment.CurrentDirectory + "\\InputFile.txt");
                int[] input = Array.ConvertAll<string, int>(inputFile.Split(' '), Convert.ToInt32);
                INewGame newGame = new NewGame();
                newGame.StartGame(input);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
