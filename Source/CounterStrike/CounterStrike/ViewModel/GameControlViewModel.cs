using CounterStrike.Infrastructure;
using CounterStrike.Model;
using CounterStrikeLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CounterStrike.ViewModel
{
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    public class GameControlViewModel : ViewModelBase
    {
        private RelayCommand _movePlayerOneUpCommand;
        private RelayCommand _movePlayerOneDownCommand;
        private RelayCommand _movePlayerOneLeftCommand;
        private RelayCommand _movePlayerOneRightCommand;
        private Player _playerOne;
        private Player _playerTwo;
        private Map _map;

        public Player PlayerOne
        {
            get
            {
                if (_playerOne == null)
                {
                    _playerOne = GameSettings.PlayerOne;
                }
                return _playerOne;
            }
            set
            {
                _playerOne = value;
                OnPropertyChanged("PlayerOne");
            }
        }

        public Player PlayerTwo
        {
            get
            {
                if (_playerTwo == null)
                {
                    _playerTwo = GameSettings.PlayerTwo;
                }
                return _playerTwo;
            }
            set
            {
                _playerTwo = value;
                OnPropertyChanged("PlayerTwo");
            }
        }

        public Map Map
        {
            get
            {
                if (_map == null)
                {
                    _map = GameSettings.Map;
                }
                return _map;
            }
            set
            {
                _map = value;
                OnPropertyChanged("Map");
            }
        }

        public GameControlViewModel()
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                _playerOne = new Player("Паша", PlayerType.Terrorist, 0, System.Windows.Media.Colors.Azure);
                _playerTwo = new Player("Даня", PlayerType.CounterTerrorist, 0, System.Windows.Media.Colors.DarkGray);
            }
        }

        // --------------------- Player One ------------------
        #region MyRegion

        public ICommand MovePlayerOneUp
        {
            get
            {
                if (_movePlayerOneUpCommand == null)
                    _movePlayerOneUpCommand = new RelayCommand(ExecuteMovePlayerOneUpCommand, CanExecuteMovePlayerOneUpCommand);
                return _movePlayerOneUpCommand;
            }
        }

        public void ExecuteMovePlayerOneUpCommand(object parameter)
        {
            PlayerOne.ChangePosition(Direction.Up);
            OnPropertyChanged("PlayerOne");
        }

        public bool CanExecuteMovePlayerOneUpCommand(object parameter)
        {
            return true;
        }

        public ICommand MovePlayerOneDown
        {
            get
            {
                if (_movePlayerOneDownCommand == null)
                    _movePlayerOneDownCommand = new RelayCommand(ExecuteMovePlayerOneDownCommand, CanExecuteMovePlayerOneDownCommand);
                return _movePlayerOneDownCommand;
            }
        }

        public void ExecuteMovePlayerOneDownCommand(object parameter)
        {
            PlayerOne.ChangePosition(Direction.Down);
            OnPropertyChanged("PlayerOne");
        }

        public bool CanExecuteMovePlayerOneDownCommand(object parameter)
        {
            return true;
        }

        public ICommand MovePlayerOneLeft
        {
            get
            {
                if (_movePlayerOneLeftCommand == null)
                    _movePlayerOneLeftCommand = new RelayCommand(ExecuteMovePlayerOneLeftCommand, CanExecuteMovePlayerOneLeftCommand);
                return _movePlayerOneLeftCommand;
            }
        }

        public void ExecuteMovePlayerOneLeftCommand(object parameter)
        {
            PlayerOne.ChangePosition(Direction.Left);
            OnPropertyChanged("PlayerOne");
        }

        public bool CanExecuteMovePlayerOneLeftCommand(object parameter)
        {
            return true;
        }

        public ICommand MovePlayerOneRight
        {
            get
            {
                if (_movePlayerOneRightCommand == null)
                    _movePlayerOneRightCommand = new RelayCommand(ExecuteMovePlayerOneRightCommand, CanExecuteMovePlayerOneRightCommand);
                return _movePlayerOneRightCommand;
            }
        }

        public void ExecuteMovePlayerOneRightCommand(object parameter)
        {
            PlayerOne.ChangePosition(Direction.Right);
            OnPropertyChanged("PlayerOne");
        }

        public bool CanExecuteMovePlayerOneRightCommand(object parameter)
        {
            return true;
        }
    }
        #endregion
        // ---------------------------------------------------
}
