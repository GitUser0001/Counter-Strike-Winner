using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterStrike.Infrastructure;
using CounterStrike.Model;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using CounterStrikeLibrary;
using System.Windows.Media;

namespace CounterStrike.ViewModel
{
    public class MapPickerControlViewModel : ViewModelBase
    {
        private Map _map;

        private RelayCommand _confirmMapCommand;
        private RelayCommand _selectMap1Command;
        private RelayCommand _selectMap2Command;
        private RelayCommand _selectMap3Command;

        public Map Map
        {
            get
            {
                return _map;
            }
            set
            {
                _map = value;
                OnPropertyChanged("Map");
            }
        }

        public ICommand ConfirmMap
        {
            get
            {
                if (_confirmMapCommand == null)
                    _confirmMapCommand = new RelayCommand(ExecuteConfirmMapCommand, CanExecuteConfirmMapCommand);
                return _confirmMapCommand;
            }
        }

        public ICommand SelectMap1
        {
            get
            {
                if (_selectMap1Command == null)
                    _selectMap1Command = new RelayCommand(ExecuteSelectMap1Command, CanExecuteSelectMap1Command);
                return _selectMap1Command;
            }
        }

        public ICommand SelectMap2
        {
            get
            {
                if (_selectMap2Command == null)
                    _selectMap2Command = new RelayCommand(ExecuteSelectMap2Command, CanExecuteSelectMap2Command);
                return _selectMap2Command;
            }
        }

        public ICommand SelectMap3
        {
            get
            {
                if (_selectMap3Command == null)
                    _selectMap3Command = new RelayCommand(ExecuteSelectMap3Command, CanExecuteSelectMap3Command);
                return _selectMap3Command;
            }
        }

        #region Confirm Map Command
        public bool CanExecuteConfirmMapCommand(object parameter)
        {
            return Map != null;
        }

        public void ExecuteConfirmMapCommand(object parameter)
        {
            GameSettings.SetMap(Map);
        }
        #endregion

        #region Select Map 1 Command
        public bool CanExecuteSelectMap1Command(object parameter)
        {
            return true;
        }

        public void ExecuteSelectMap1Command(object parameter)
        {
            Map = new Map(MapType.DeDust);
        }
        #endregion

        #region Select Map 2 Command
        public bool CanExecuteSelectMap2Command(object parameter)
        {
            return true;
        }

        public void ExecuteSelectMap2Command(object parameter)
        {
            Map = new Map(MapType.DeRain);
        }
        #endregion

        #region Select Map 3 Command
        public bool CanExecuteSelectMap3Command(object parameter)
        {
            return true;
        }

        public void ExecuteSelectMap3Command(object parameter)
        {
            Map = new Map(MapType.DeWinter);
        }
        #endregion
    }
}
