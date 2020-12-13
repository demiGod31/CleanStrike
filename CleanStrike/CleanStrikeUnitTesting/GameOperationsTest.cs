using CleanStrike.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CleanStrike.BusinessEntities;

namespace CleanStrikeUnitTesting
{
    
    
    //This is a test class for GameOperationsTest and is intended
    //to contain all GameOperationsTest Unit Tests
    [TestClass()]
    public class GameOperationsTest
    {


        private TestContext testContextInstance;

        //Gets or sets the test context which provides
        //information about and functionality for the current test run.
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        //A test for CheckPoints
        [TestMethod()]
        public void CheckPointsTest()
        {
            GameOperations target = new GameOperations();
            Player player1 = new Player() { name = "Player 1", points = -4, foulCount = 0 };
            Player player2 = new Player() { name = "Player 2", points = 3, foulCount = 0 };
            bool expected = false;
            bool actual;
            actual = target.CheckPoints(player1, player2);
            Assert.AreEqual(expected, actual);
        }

        //A test for DefunctCoin
        [TestMethod()]
        public void DefunctCoinTest()
        {
            GameOperations target = new GameOperations();
            Player player = new Player() { name = "Player 1", points = 10, foulCount = 2 };
            int coins = 5;
            int coinsExpected = 4;
            target.DefunctCoin(player, ref coins);
            Assert.AreEqual(coinsExpected, coins);
        }

        //A test for Multistrike
        [TestMethod()]
        public void MultistrikeTest()
        {
            GameOperations target = new GameOperations();
            Player player = new Player() { name = "Player 1", points = 10, foulCount = 2 };
            int coins = 10;
            int coinsExpected = 8;
            target.Multistrike(player, ref coins);
            Assert.AreEqual(coinsExpected, coins);
        }

        //A test for Redstrike
        [TestMethod()]
        public void RedstrikeTest()
        {
            GameOperations target = new GameOperations();
            Player player = new Player() { name = "Player 1", points = 0, foulCount = 2 };
            int coins = 9;
            int coinsExpected = 9;
            bool isRedCoinPresent = false;
            bool isRedCoinPresentExpected = false;
            target.Redstrike(player, ref coins, ref isRedCoinPresent);
            Assert.AreEqual(coinsExpected, coins);
            Assert.AreEqual(isRedCoinPresentExpected, isRedCoinPresent);
        }

        //A test for Strike
        [TestMethod()]
        public void StrikeTest()
        {
            GameOperations target = new GameOperations();
            Player player = new Player() { name = "Player 1", points = 0, foulCount = 2 };
            int coins = 10;
            int coinsExpected = 9;
            target.Strike(player, ref coins);
            Assert.AreEqual(coinsExpected, coins);
        }

        //A test for Strikerstrike
        [TestMethod()]
        public void StrikerstrikeTest()
        {
            GameOperations target = new GameOperations();
            Player player = new Player() { name = "Player 1", points = 0, foulCount = 2 };
            target.Strikerstrike(player);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
