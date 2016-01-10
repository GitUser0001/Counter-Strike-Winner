using CounterStrikeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CounterStrike.Model
{
    public static class GameSettings
    {
        private static GameType _gameType;
        private static Player _playerOne;
        private static Player _playerTwo;
        private static Map _map;

        public static GameType GameType
        {
            get
            {
                return _gameType;
            }
            set
            {
                ClearSettings();
                _gameType = value;
            }
        }

        public static Player PlayerOne
        {
            get
            {
                return _playerOne;
            }
        }

        public static Player PlayerTwo
        {
            get
            {
                return _playerTwo;
            }
        }

        public static Map Map
        {
            get
            {
                return _map;
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

            if (_gameType == GameType.SingleGame || _playerTwo != null)
            {
                EnvelopeWindowManager.SwitchToMapPickerMenu();
            }
        }

        public static void SetMap(Map map)
        {
            _map = map;
            EnvelopeWindowManager.SwitchToGameView();
        }

        private static void ClearSettings()
        {
            _playerOne = null;
            _playerTwo = null;
            _map = null;
        }
    }
}
