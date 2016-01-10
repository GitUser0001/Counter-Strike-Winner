using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrike.Model
{
    public static class GameSettings
    {
        private static bool _isSinglePlayer;
        private static Player _playerOne;
        private static Player _playerTwo;
        private static Map _map;

        public static bool IsSinglePlayer
        {
            get
            {
                return _isSinglePlayer;
            }
            set
            {
                ClearSettings();
                _isSinglePlayer = value;
            }
        }

        public static void AddPlayer(Player player)
        {
            if (_playerOne == null)
            {
                _playerOne = player;
            }
            else if (_playerTwo == null)
            {
                _playerTwo = player;
            }

            if (_isSinglePlayer || _playerTwo != null)
            {
                EnvelopeWindowManager.SwitchToMapPickerMenu();
            }
        }

        private static void ClearSettings()
        {
            _playerOne = null;
            _playerTwo = null;
            _map = null;
        }
    }
}
