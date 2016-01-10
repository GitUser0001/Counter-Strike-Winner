using CounterStrike.Infrastructure;
using CounterStrike.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace CounterStrike.ViewModel
{
    public class PlayerPickerControlViewModel : ViewModelBase
    {
        private Player _currPlayer;

        private int _playerRegionNumber = -1;
        private int _playerWeaponNumber;

        private Color _playerColor;

        private RelayCommand _confirmPlayerCommand;

        private string _playerStatus = "Confrm";

        private bool _isNotConfirmed = true;

        public int PlayerRegionNumber
        {
            get
            {
                return _playerRegionNumber;
            }
            set
            {
                _playerRegionNumber = value;
                OnPropertyChanged("PlayerRegionNumber");
            }
        }


        public int PlayerWeaponNumber
        {
            get
            {
                return _playerWeaponNumber;
            }
            set
            {
                _playerWeaponNumber = value;
                OnPropertyChanged("PlayerWeaponNumber");
            }
        }

        public Color PlayerColor
        {
            get
            {
                return _playerColor;
            }
            set
            {
                _playerColor = value;
                OnPropertyChanged("PlayerColor");
            }
        }

        public string PlayerStatus
        {
            get
            {
                return _playerStatus;
            }
            set
            {
                _playerStatus = value;
                OnPropertyChanged("PlayerStatus");
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

        public ICommand ConfirmPlayer
        {
            get
            {
                if (_confirmPlayerCommand == null)
                    _confirmPlayerCommand = new RelayCommand(ExecuteConfirmPlayerCommand, CanExecuteConfirmPlayerCommand);
                return _confirmPlayerCommand;
            }
        }

        public void ExecuteConfirmPlayerCommand(object parameter)
        {
            PlayerStatus = "Conformed";
            IsNotConfirmed = false;
            PlayerWeaponNumber = 1;
            _currPlayer = new Player(PlayerRegionNumber, PlayerWeaponNumber, PlayerColor);
            GameSettings.AddPlayer(_currPlayer);
        }

        public bool CanExecuteConfirmPlayerCommand(object parameter)
        {
            return _currPlayer == null && PlayerColor != Color.FromArgb(0, 0, 0, 0) && PlayerRegionNumber != -1;
        }
    }
}
