using System;
using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CounterStrikeLibrary;
using System.Collections.Generic;

namespace CounterStrikeTest
{
    [TestClass]
    public class TestXmlManager
    {
        [TestMethod, TestCategory("XMLmanager")]
        public void TestSerializeGamer()
        {
            Gamer g1 = new Gamer("Pasha", PlayerType.ADMIN, new Color());
            g1.Health = 100;
            g1.Points = 75;

            Gamer g2 = new Gamer("Dan", PlayerType.ADMIN, new Color());
            g2.Health = 90;
            g2.Points = 85;

            List<Gamer> gamers = new List<Gamer>();

            gamers.Add(g1);
            gamers.Add(g2);

            XmlManager manager = new XmlManager(gamers);
            manager.SerializeXml();
        }

        [TestMethod, TestCategory("XMLmanager")]
        public void TestGetGamer()
        {
            XmlManager manager = new XmlManager();

            var res = manager.Get("Pasha");

            Assert.IsNotNull(res);
        }

        [TestMethod, TestCategory("XMLmanager")]
        public void TestSaveGamer()
        {
            Gamer g1 = new Gamer("Pasha", PlayerType.ADMIN, new Color());
            g1.Health = 50;
            g1.Points = 1000;

            XmlManager manager = new XmlManager();
            manager.Save(g1);
        }

        [TestMethod, TestCategory("XMLmanager")]
        public void TestSerializeGame()
        {
            Gamer g1 = new Gamer("Pasha", PlayerType.ADMIN, new Color());
            g1.Health = 100;
            g1.Points = 75;

            Gamer g2 = new Gamer("Dan", PlayerType.ADMIN, new Color());
            g2.Health = 90;
            g2.Points = 85;

            Game game1 = new Game(g1, g2);
            Game game2 = new Game(g2);

            List<Game> games = new List<Game>();
            games.Add(game1);
            games.Add(game2);

            XmlManager manager = new XmlManager(games);
            manager.SerializeXml();
        }

        [TestMethod, TestCategory("XMLmanager")]
        public void TestGetGame()
        {
            XmlManager manager = new XmlManager();
            var res = manager.Get();

            Assert.IsNotNull(res);
        }

        [TestMethod, TestCategory("XMLmanager")]
        public void TestGameDeserialize()
        {
            XmlManager manager = new XmlManager();
            var res = manager.DeserializeGame();

            Assert.IsNotNull(res);
        }

        [TestMethod, TestCategory("XMLmanager")]
        public void TestGamerDeserialize()
        {
            XmlManager manager = new XmlManager();
            var res = manager.DeserializeGamer();

            Assert.IsNotNull(res);
        }
    }
}
