using CounterStrike.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CounterStrike.ViewModel
{
    public class EnvelopeWindowViewModel : ViewModelBase
    {
        private UIElement _statusBar;
        private UIElement _leftView;
        private UIElement _middleView;
        private UIElement _rightView;
        private UIElement _gameView;

        public EnvelopeWindowViewModel()
        {
            EnvelopeWindowManager.SetEnvelopeWindow(this);
            EnvelopeWindowManager.SwitchToSignInMenu();
        }

        public UIElement GameView
        {
            get
            {
                return _gameView;
            }

            set
            {
                _gameView = value;
                OnPropertyChanged("GameView");
            }
        }

        public UIElement StatusBar
        {
            get
            {
                return _statusBar;
            }

            set
            {
                _statusBar = value;
                OnPropertyChanged("StatusBar");
            }
        }

        public UIElement LeftView
        {
            get
            {
                return _leftView;
            }

            set
            {
                _leftView = value;
                OnPropertyChanged("LeftView");
            }
        }

        public UIElement MiddleView
        {
            get
            {
                return _middleView;
            }

            set
            {
                _middleView = value;
                OnPropertyChanged("MiddleView");
            }
        }

        public UIElement RightView
        {
            get
            {
                return _rightView;
            }

            set
            {
                _rightView = value;
                OnPropertyChanged("RightView");
            }
        }
    }
}
