using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CounterStrike.Model
{
    public class Player
    {
        public Player(int regionNumber, int weaponNumber, Color color)
        {
            RegionNumber = regionNumber;
            WeaponNumber = weaponNumber;
            Color = color;
        }

        public int RegionNumber { get; set; }

        public int WeaponNumber { get; set; }

        public Color Color { get; set; }

        public string FirstName { get; set; }

        public string NickName { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, NickName);
        }
    }
}
