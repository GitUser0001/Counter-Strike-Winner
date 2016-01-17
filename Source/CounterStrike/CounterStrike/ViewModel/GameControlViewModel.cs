using CounterStrike.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrike.ViewModel
{
    public class GameControlViewModel : ViewModelBase
    {
        // Can make this properties static ?????????????
        public Player PlayerOne
        {
            get
            {
                return GameSettings.PlayerOne;
            }
        }

        public Player PlayerTwo
        {
            get
            {
                return GameSettings.PlayerTwo;
            }
        }

        public Map Map
        {
            get
            {
                return GameSettings.Map;
            }
        }
    }
}
