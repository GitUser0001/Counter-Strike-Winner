using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace CounterStrikeLibrary
{
    public class XmlManager
    {
        private string _pathToDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), ".CounterStrike");
        private string _fileNameGame = "Game.xml";
        private string _fileNameGamer = "Gamer.xml";

        private List<Game> _games = new List<Game>();
        private List<Gamer> _gamers = new List<Gamer>();

        /// <summary>
        /// Empty constructor
        /// </summary>
        public XmlManager()
        {
        }

        /// <summary>
        /// Serialize GAME class to XML file
        /// </summary>
        /// <param name="game"></param>
        public XmlManager(Game game)
        {
            this.MyGame = game;
        }

        /// <summary>
        /// Serialize GAME class to XML file
        /// </summary>
        /// <param name="game"></param>
        public XmlManager(List<Game> game)
        {
            this.MyGame = game[0];
            this._games = game;
        }

        /// <summary>
        /// Serialize GAMER class to XML file
        /// </summary>
        /// <param name="gamer"></param>
        public XmlManager(Gamer gamer)
        {
            this.MyGamer = gamer;
        }

        /// <summary>
        /// Serialize GAMER class to XML file
        /// </summary>
        /// <param name="gamer"></param>
        public XmlManager(List<Gamer> gamerList)
        {
            this._gamers = gamerList;
        }

        public Game MyGame { get; set; }

        public Gamer MyGamer { get; set; }

        /// <summary>
        /// Save the current gamer information
        /// </summary>
        /// <param name="gamer"></param>
        public void Save(Gamer gamer)
        {
            this.SaveGamer(gamer);
        }

        /// <summary>
        /// Save the whole game information
        /// </summary>
        /// <param name="game"></param>
        public void Save(Game game)
        {
            this.SaveGame(game);
        }

        public Gamer Get(string name)
        {
            return this.GetGamer(name);
        }

        public List<Game> Get()
        {
            return this.GetGame();
        }

        public bool SerializeXml()
        {
            bool isSerialize = false;

            return isSerialize = (this.MyGame != null && this.MyGamer == null) ? this.SerializeGame() : this.SerializeGamer();
        }

        #region Deserialize Methods
        public List<Game> DeserializeGame()
        {
            List<Game> games = new List<Game>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Game>));

            using (TextReader reader = new StreamReader(_pathToDirectory + "/" + _fileNameGame))
                games = (List<Game>)serializer.Deserialize(reader);

            return games;
        }

        public List<Gamer> DeserializeGamer()
        {
            List<Gamer> gamers = new List<Gamer>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Gamer>));

            using (TextReader reader = new StreamReader(_pathToDirectory + "/" + _fileNameGamer))
                gamers = (List<Gamer>)serializer.Deserialize(reader);

            return gamers;
        }

        #endregion

        #region Serialize Methods
        private bool SerializeGame()
        {
            try
            {
                if (!Directory.Exists(_pathToDirectory + "\\" + _fileNameGame))
                    Directory.CreateDirectory(_pathToDirectory);

                XmlSerializer serializer = new XmlSerializer(typeof(List<Game>));
                using (TextWriter writer = new StreamWriter(_pathToDirectory + "/" + _fileNameGame))
                    serializer.Serialize(writer, this._games);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private bool SerializeGamer()
        {
            try
            {
                if (!Directory.Exists(_pathToDirectory + "\\" + _fileNameGamer))
                    Directory.CreateDirectory(_pathToDirectory);

                XmlSerializer serializer = new XmlSerializer(typeof(List<Gamer>));
                using (TextWriter writer = new StreamWriter(_pathToDirectory + "/" + _fileNameGamer))
                    serializer.Serialize(writer, this._gamers);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion

        #region Get Methods
        private Gamer GetGamer(string name)
        {
            Gamer gamer = new Gamer();
            try
            {
                XmlDocument xml = OpenXmlDoc(_fileNameGamer);

                XmlNodeList arrayOfGamers = xml.SelectNodes("ArrayOfGamer");
                foreach (XmlNode xn in arrayOfGamers)
                {
                    XmlNodeList listOfGamers = xn.SelectNodes("Gamer");
                    foreach (XmlNode item in listOfGamers)
                        if (item["NickName"].InnerText == name && listOfGamers != null)
                        {
                            gamer = new Gamer()
                            {
                                NickName = item["NickName"].InnerText,
                                Points = Convert.ToInt32(item["Points"].InnerText),
                                Health = Convert.ToInt32(item["Health"].InnerText),
                                PlayerTypeInGame = (PlayerType)Enum.Parse(typeof(PlayerType), item["PlayerType"].InnerText)
                            };
                        }
                }
                return gamer;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private List<Game> GetGame()
        {
            int countGamers = 0;
            List<Game> games = new List<Game>();
            Game game = new Game();

            try
            {
                XmlDocument xml = OpenXmlDoc(_fileNameGame);

                XmlNodeList arrayOfGames = xml.SelectNodes("ArrayOfGame");
                foreach (XmlNode xn in arrayOfGames)
                {
                    XmlNodeList listOfGames = xn.SelectNodes("Game");
                    foreach (XmlNode item in listOfGames)
                    {
                        countGamers++;

                        game.IdGame = new Guid(item["ID"].InnerText);
                        game.TimeGame = Convert.ToDateTime(item["Time"].InnerText);
                        game.TypeGame = (GameType)Enum.Parse(typeof(GameType), item["TypeGame"].InnerText);

                        //// Parse XML file by hierarchy
                        //// Get the type of game and parsing GAMERS of GAME
                        //// Single game => Gamer1
                        //// Multi game => Gamer1 and Gamer2
                        if(game.TypeGame == GameType.SingleGame)
                        {
                            XmlNodeList gamerInList = item.SelectNodes("Gamer" + countGamers);

                            foreach (XmlNode g in gamerInList)
                            {
                                string res = g["NickName"].InnerText;
                            }
                        }
                        else
                        {
                            XmlNodeList gamerInList = item.SelectNodes("Gamer" + countGamers);

                            foreach (XmlNode g in gamerInList)
                            {
                                string res = g["NickName"].InnerText;
                            }

                            //// Count gamers to parse Gamer2
                            countGamers++;
                        }
                    }
                }
                return games;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion

        #region Save Methods
        private void SaveGamer(Gamer gamer)
        {
            XmlDocument xml = OpenXmlDoc(_fileNameGamer);
            XmlNodeList nodeList = xml.SelectNodes("ArrayOfGamer");
            foreach (XmlNode xn in nodeList)
            {
                XmlNodeList list = xn.SelectNodes("Gamer");
                foreach (XmlNode item in list)
                    if (item["NickName"].InnerText == gamer.NickName)
                    {
                        item["PlayerType"].InnerText = gamer.PlayerTypeInGame.ToString();
                        item["Points"].InnerText = gamer.Points.ToString();
                        item["Health"].InnerText = gamer.Health.ToString();
                        item["ColorGamer"].InnerText = gamer.ColorGamer.ToString();
                    }
            }
            xml.Save(_pathToDirectory + "\\" + _fileNameGamer);
        }

        private void SaveGame(Game game)
        {
            XmlDocument xml = OpenXmlDoc(_fileNameGamer);

            XmlNodeList arrayOfGames = xml.SelectNodes("ArrayOfGame");
            foreach (XmlNode xn in arrayOfGames)
            {
                XmlNodeList games = xn.SelectNodes("Game");
                foreach (XmlNode item in games)
                {
                    //// Save GAME information
                    item["ID"].InnerText = game.IdGame.ToString();
                    item["Time"].InnerText = game.TimeGame.ToString();
                    item["TypeMap"].InnerText = game.TypeMap.ToString();
                    item["TypeGame"].InnerText = game.TypeGame.ToString();

                    //// Save GAMER information
                    XmlNodeList arrayOfGamers = xn.SelectNodes("Gamers");
                    foreach (XmlNode g in arrayOfGamers)
                    {
                        XmlNodeList gamersNode = xn.SelectNodes("Gamer");
                        foreach (XmlNode gamer in gamersNode)
                        {
                            //// Not implementation
                            //// Thinking about that and hierarchy
                        }
                    }
                }
            }
            xml.Save(_pathToDirectory + "\\" + _fileNameGamer);
        }
        #endregion

        private XmlDocument OpenXmlDoc(string fileName)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(_pathToDirectory + "/" + fileName);
            return xml;
        }
    }
}
