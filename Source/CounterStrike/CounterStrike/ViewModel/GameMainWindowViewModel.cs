using CounterStrike.Infrastructure;
using CounterStrike.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CounterStrike.ViewModel
{
    public class GameMainWindowViewModel : ViewModelBase
    {
        private RelayCommand _addPlayerCommand;

        public static ObservableCollection<Player> Players
        {
            get
            {
                return PlayersRepository.AllPlayers;
            }
        }

        public ICommand AddPlayer
        {
            get
            {
                if (_addPlayerCommand == null)
                    _addPlayerCommand = new RelayCommand(ExecuteAddPlayerCommand, CanExecuteAddPlayerCommand);
                return _addPlayerCommand;
            }
        }

        public void ExecuteAddPlayerCommand(object parameter)
        {
        }

        public bool CanExecuteAddPlayerCommand(object parameter)
        {
            return true;
        }
    }
}
