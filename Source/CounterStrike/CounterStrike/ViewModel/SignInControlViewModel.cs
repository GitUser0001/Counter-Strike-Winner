using CounterStrike.Infrastructure;
using CounterStrike.Model;
using CounterStrikeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CounterStrike.ViewModel
{
    public class SignInControlViewModel : ViewModelBase
    {
        private RelayCommand _selectSingleModCommand;
        private RelayCommand _logOffCommand;
        private RelayCommand _selectMultiModCommand;

        public ICommand SelectSingleMod
        {
            get
            {
                if (_selectSingleModCommand == null)
                    _selectSingleModCommand = new RelayCommand(ExecuteSelectSingleModCommand, CanExecuteSelectSingleModCommand);
                return _selectSingleModCommand;
            }
        }

        public ICommand SelectMultyMod
        {
            get
            {
                if (_selectMultiModCommand == null)
                    _selectMultiModCommand = new RelayCommand(ExecuteSelectMultyModCommand, CanExecuteSelectMultyModCommand);
                return _selectMultiModCommand;
            }
        }

        public ICommand LogOff
        {
            get
            {
                if (_logOffCommand == null)
                    _logOffCommand = new RelayCommand(ExecuteLogOffCommand, CanExecuteLogOffCommand);
                return _logOffCommand;
            }
        }

        public void ExecuteSelectSingleModCommand(object parameter)
        {
            EnvelopeWindowManager.SwitchToPlayerPickerMenu(GameType.SingleGame);
        }

        public bool CanExecuteSelectSingleModCommand(object parameter)
        {
            return true;
        }

        public void ExecuteSelectMultyModCommand(object parameter)
        {
            EnvelopeWindowManager.SwitchToPlayerPickerMenu(GameType.MultiGame);
        }

        public bool CanExecuteSelectMultyModCommand(object parameter)
        {
            return true;
        }

        public void ExecuteLogOffCommand(object parameter)
        {
            Application.Current.Shutdown();
        }

        public bool CanExecuteLogOffCommand(object parameter)
        {
            return true;
        }
    }
}
