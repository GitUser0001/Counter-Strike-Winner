using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrike.Model
{
    public static class PlayersRepository
    {
        private static ObservableCollection<Player> _players;

        public static ObservableCollection<Player> AllPlayers
        {
            get
            {
                if (_players == null)
                {
                    _players = GeneratePlayerRepository();
                }

                return _players;
            }
        }

        public static ObservableCollection<Player> GeneratePlayerRepository()
        {
            //_players.Add(new Player("Dan", "GitUser0001"));
            //_players.Add(new Player("Pashka", "BlackRak"));
            return _players;
        }
    }
}
