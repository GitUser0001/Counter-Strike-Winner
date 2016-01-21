using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CounterStrike.Infrastructure;
using CounterStrike.ViewModel;

namespace CounterStrike.Controls
{
    /// <summary>
    /// Interaction logic for GameControl.xaml
    /// </summary>
    public partial class GameControl : UserControl, IGameControlView
    {
        public GameControl()
        {
            InitializeComponent();
            Focusable = true;
            Loaded += (s, e) => Keyboard.Focus(this);
            (DataContext as GameControlViewModel).GameControlView = this as IGameControlView;
        }

        public Canvas GameCanvas
        {
            get { return this.gameCanvas; }
        }
    }
}
