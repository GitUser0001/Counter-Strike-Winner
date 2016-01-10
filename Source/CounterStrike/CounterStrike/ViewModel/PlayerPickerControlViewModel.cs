using CounterStrike.Infrastructure;
using CounterStrike.Model;
using CounterStrikeLibrary;
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

        private string _nickName;

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

        public string NickName
        {
            get
            {
                return _nickName;
            }
            set
            {
                _nickName = value;
                OnPropertyChanged("NickName");
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
            PlayerType playerType;

            switch (PlayerRegionNumber)
            {
                case 0:
                    playerType = PlayerType.Terrorist;
                    break;
                case 1:
                    playerType = PlayerType.CounterTerrorist;
                    break;
                default:
                    playerType = PlayerType.ADMIN;
                    break;
            }

            _currPlayer = new Player(NickName, playerType, PlayerWeaponNumber, PlayerColor);
            GameSettings.AddPlayer(_currPlayer);
        }

        public bool CanExecuteConfirmPlayerCommand(object parameter)
        {
            return _currPlayer == null && !string.IsNullOrEmpty(NickName) &&
                PlayerColor != Color.FromArgb(0, 0, 0, 0) && PlayerRegionNumber != -1;
        }
    }
}
