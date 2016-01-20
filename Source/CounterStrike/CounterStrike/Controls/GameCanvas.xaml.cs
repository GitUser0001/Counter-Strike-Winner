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
using CounterStrike.Model;

namespace CounterStrike.Controls
{
    /// <summary>
    /// Interaction logic for GameCanvas.xaml
    /// </summary>
    public partial class GameCanvas : Canvas
    {
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerOneProperty =
            DependencyProperty.Register(
                                        "PlayerOneProperty",
                                        typeof(Player),
                                        typeof(GameCanvas),
                                        new UIPropertyMetadata(
                                          GameSettings.PlayerOne,
                                          OnCurrentPlayerOnePropertyChanged,
                                          OnCoercePlayerProperty),
                                          OnValidatePlayerOneProperty);

        public GameCanvas()
        {
        }

        public Player PlayerOne
        {
            get { return (Player)GetValue(PlayerOneProperty); }
            set { SetValue(PlayerOneProperty, value); }
        }

        private static void OnCurrentPlayerOnePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            Player p = new Player("P", CounterStrikeLibrary.PlayerType.ADMIN, 10, Color.FromArgb(0, 0, 0, 0));
            p.CoordinatePlayer = new GameLogic.Coordinate(230, 230);

            //GameCanvas canvas = source as GameCanvas;
            p = (Player)e.NewValue;
        }

        /// <summary>
        /// Method to avoid exception
        /// If Player postion coordinates will be over than MAP coordinate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static object OnCoercePlayerProperty(DependencyObject sender, object data)
        {
            //if(GameSettings.Map.Height < 500 && GameSettings.Map.Width < 500)
            //{
            //    data = GameSettings.PlayerOne;
            //}
            return data;
        }

        private static bool OnValidatePlayerOneProperty(object data)
        {
            if (data.GetType() == typeof(Player))
                return true;
            else
                return false;
        }
    }
}
