using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterStrike.Infrastructure;
using CounterStrike.Model;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CounterStrike.ViewModel
{
    public class MapPickerControlViewModel : ViewModelBase
    {
        private RelayCommand _confirmMapCommand;
        private RelayCommand _selectMap1Command;
        private RelayCommand _selectMap2Command;
        private RelayCommand _selectMap3Command;

        private string _mapStatus = "Confirm";
        private bool _isNotConfirmed = true;
        private string _mapImagePath;

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

        public string MapImagePath
        {
            get
            {
                return _mapImagePath;
            }
            set
            {
                _mapImagePath = value;
                OnPropertyChanged("MapImagePath");
            }
        }

        public string MapStatus
        {
            get
            {
                return _mapStatus;
            }
            set
            {
                _mapStatus = value;
                OnPropertyChanged("MapStatus");
            }
        }

        public bool IsNotConfirmed
        {
            get
            {
                return _isNotConfirmed;
            }
            set
            {
                _isNotConfirmed = value;
                OnPropertyChanged("IsConfirmed");
            }
        }

        #region Confirm Map Command
        public bool CanExecuteConfirmMapCommand(object parameter)
        {
            return Map.ImageMap != null;
        }

        public void ExecuteConfirmMapCommand(object parameter)
        {
            MapStatus = "Conformed";
            IsNotConfirmed = false;
            EnvelopeWindowManager.SwitchToGameView();
        }
        #endregion

        #region Select Map 1 Command
        public bool CanExecuteSelectMap1Command(object parameter)
        {
            return true;
        }

        public void ExecuteSelectMap1Command(object parameter)
        {
            Map.LoadMap1();
            MapImagePath = Map.ImageMap;
        }
        #endregion

        #region Select Map 2 Command
        public bool CanExecuteSelectMap2Command(object parameter)
        {
            return true;
        }

        public void ExecuteSelectMap2Command(object parameter)
        {
            Map.LoadMap2();
            MapImagePath = Map.ImageMap;
        }
        #endregion

        #region Select Map 3 Command
        public bool CanExecuteSelectMap3Command(object parameter)
        {
            return true;
        }

        public void ExecuteSelectMap3Command(object parameter)
        {
            Map.LoadMap3();
            MapImagePath = Map.ImageMap;
        }
        #endregion
    }
}
