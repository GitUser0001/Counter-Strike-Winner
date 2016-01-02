using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrike.Model
{
    public class Player
    {
        public string FirstName { get; set; }
        public string NickName { get; set; }

        public Player(string firstName, string lastName)
        {
            FirstName = firstName;
            NickName = lastName;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, NickName);
        }
    }
}
