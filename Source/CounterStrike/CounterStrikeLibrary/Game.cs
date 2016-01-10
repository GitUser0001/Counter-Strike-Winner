using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CounterStrikeLibrary
{
    [XmlRoot("Games")]
    public class Game
    {
        private Gamer _gamer1;
        private Gamer _gamer2;
        private MapType _mapType;
        private GameType _gameType;
        private List<Gamer> _gamers = new List<Gamer>();

        /// <summary>
        /// Constructor for serializing
        /// </summary>
        public Game()
        {
        }

        /// <summary>
        /// Constructor for single game
        /// </summary>
        /// <param name="gamer"></param>
        public Game(Gamer gamer)
        {
            this._gamer1 = gamer;
            this._gamers.Add(gamer);
            this._gameType = GameType.SingleGame;

            this.Initialize();
        }

        /// <summary>
        /// Constructor for multi game
        /// </summary>
        /// <param name="gamer1"></param>
        /// <param name="gamer2"></param>
        public Game(Gamer gamer1, Gamer gamer2)
        {
            this._gamer1 = gamer1;
            this._gamer2 = gamer2;
            this._gamers.Add(gamer1);
            this._gamers.Add(gamer2);
            this._gameType = GameType.MultiGame;

            this.Initialize();
        }

        [XmlElement("ID")]
        public Guid IdGame { get; set; }

        [XmlElement("Time")]
        public DateTime TimeGame { get; set; }

        [XmlIgnore]
        public Gamer Gamer1
        {
            get { return this._gamer1; }
            set { this._gamer1 = value; }
        }

        [XmlIgnore]
        public Gamer Gamer2
        {
            get { return this._gamer2; }
            set { this._gamer2 = value; }
        }

        [XmlElement("TypeMap")]
        public MapType TypeMap
        {
            get { return this._mapType; }
            set { this._mapType = value; }
        }

        [XmlElement("TypeGame")]
        public GameType TypeGame
        {
            get { return this._gameType; }
            set { this._gameType = value; }
        }

        [XmlArray("Gamers")]
        public List<Gamer> Gamers
        {
            get { return this._gamers; }
            set { this._gamers = value; }
        }

        private void Initialize()
        {
            this.IdGame = Guid.NewGuid();
            this.TimeGame = DateTime.Now;
        }
    }
}
