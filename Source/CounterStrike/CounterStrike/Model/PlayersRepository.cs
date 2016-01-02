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
                    _players = new ObservableCollection<Player>();
                return _players;
            }
        }

        private static ObservableCollection<Player> GeneratePlayerRepository()
        {
            ObservableCollection<Player> players = new ObservableCollection<Player>();
            players.Add(new Player("Dan", "GitUser0001"));
            players.Add(new Player("Pashka", "BlackRak"));
            return players;
        }
    }
}
