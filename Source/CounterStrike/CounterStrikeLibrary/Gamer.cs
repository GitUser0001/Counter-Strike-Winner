using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml;
using System.Xml.Serialization;

namespace CounterStrikeLibrary
{
    [XmlRoot("Gamers")]
    public class Gamer
    {
        /// <summary>
        /// Constructor for serializing
        /// </summary>
        public Gamer()
        {
        }

        public Gamer(string nickName, PlayerType type, Color color)
        {
            this.Id = Guid.NewGuid();
            NickName = nickName;
            PlayerTypeInGame = type;
            ColorGamer = color;
        }

        [XmlAttribute("Id")]
        public Guid Id { get; set; }

        [XmlElement("NickName")]
        public string NickName { get; set; }

        [XmlElement("PlayerType")]
        public PlayerType PlayerTypeInGame { get; set; }

        [XmlElement("ColorGamer")]
        public Color ColorGamer { get; set; }

        [XmlElement("Points")]
        public int Points { get; set; }

        [XmlElement("Health")]
        public int Health { get; set; }
    }
}
