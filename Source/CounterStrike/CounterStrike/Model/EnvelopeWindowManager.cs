using CounterStrike.Controls;
using CounterStrike.ViewModel;
using CounterStrikeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CounterStrike.Model
{
    public static class EnvelopeWindowManager
    {
        private static EnvelopeWindowViewModel _mainWindow;
        private static SignInControl _singInControl;
        private static PlayerPickerControl _playerOnePickerControl;
        private static PlayerPickerControl _playerTwoPickerControl;
        private static MapPickerControl _mapPickerControl;
        private static GameControl _gameControl;

        private static SignInControl SignInControl
        {
            get
            {
                if (_singInControl == null)
                {
                    _singInControl = new SignInControl();
                }

                return _singInControl;
            }
            set
            {
                _singInControl = value;
            }
        }

        private static PlayerPickerControl PlayerOnePickerControl
        {
            get
            {
                if (_playerOnePickerControl == null)
                {
                    _playerOnePickerControl = new PlayerPickerControl();
                }

                return _playerOnePickerControl;
            }
            set
            {
                _playerOnePickerControl = value;
            }
        }

        private static PlayerPickerControl PlayerTwoPickerControl
        {
            get
            {
                if (_playerTwoPickerControl == null)
                {
                    _playerTwoPickerControl = new PlayerPickerControl();
                }

                return _playerTwoPickerControl;
            }
            set
            {
                _playerTwoPickerControl = value;
            }
        }

        private static MapPickerControl MapPickerControl
        {
            get
            {
                if (_mapPickerControl == null)
                {
                    _mapPickerControl = new MapPickerControl();
                }

                return _mapPickerControl;
            }
            set
            {
                _mapPickerControl = value;
            }
        }

        private static GameControl GameControl
        {
            get
            {
                if (_gameControl == null)
                {
                    _gameControl = new GameControl();
                }

                return _gameControl;
            }
            set
            {
                _gameControl = value;
            }
        }

        public static void SetEnvelopeWindow(EnvelopeWindowViewModel mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public static void SwitchToSignInMenu()
        {
            CheckWindowReference();
            ClearWindow();

            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                _mainWindow.MiddleView = SignInControl;
            }));
        }

        public static void SwitchToPlayerPickerMenu(GameType gameType)
        {
            CheckWindowReference();
            ClearWindow();

            GameSettings.GameType = gameType;

            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                _mainWindow.MiddleView = PlayerOnePickerControl;
            }));

            if (gameType == GameType.MultiGame)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    _mainWindow.RightView = PlayerTwoPickerControl;
                }));
            }
        }

        public static void SwitchToMapPickerMenu()
        {
            CheckWindowReference();
            ClearWindow();

            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                _mainWindow.MiddleView = MapPickerControl;
            }));
        }

        public static void SwitchToGameView()
        {
            CheckWindowReference();
            ClearWindow();

            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                _mainWindow.GameView = GameControl;
            }));
        }

        private static void ClearWindow()
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                _mainWindow.LeftView = null;
                _mainWindow.MiddleView = null;
                _mainWindow.RightView = null;
                _mainWindow.StatusBar = null;
            }));
        }

        private static void CheckWindowReference()
        {
            if (_mainWindow == null)
            {
                throw new InvalidOperationException("_mainWindow == null");
            }
        }
    }
}
