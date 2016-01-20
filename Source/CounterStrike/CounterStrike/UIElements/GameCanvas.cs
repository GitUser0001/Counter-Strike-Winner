using CounterStrike.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CounterStrike.UIElements
{
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]
    public class GameCanvas : Canvas
    {
        //     -------------------------   PLAYERS  ------------------------------------------------

        private Rectangle _playerOne = new Rectangle();

        private static FrameworkPropertyMetadata _metadataPlayer = new FrameworkPropertyMetadata(
    new PropertyChangedCallback(ChangedCallbackMethodPlayerOne), new CoerceValueCallback(CoerceValueCallbackMethodPlayerOne));

        // Свойство зависимостей.
        public static readonly DependencyProperty PlayerOneProperty = DependencyProperty.Register("PlayerOne",
                                                                           typeof(Player),
                                                                           typeof(GameCanvas),
                                                                           _metadataPlayer,
                                                                           new ValidateValueCallback(ValidateValueCallbackMethodPlayerOne));

        public Player PlayerOne
        {
            get
            {
                return (Player)GetValue(PlayerOneProperty);
            }
            set
            {
                SetValue(PlayerOneProperty, value);
            }
        }

        // 1
        static object CoerceValueCallbackMethodPlayerOne(DependencyObject d, object baseValue)
        {
            var a = (GameCanvas)d;

            a._playerOne.Fill = a.PlayerOne.Avatar;

            //if (IsLegalMove(a.PlayerOne.Point.X, a.PlayerOne.Point.Y))
            //{
                Canvas.SetLeft(a._playerOne, a.PlayerOne.Point.X);
                Canvas.SetTop(a._playerOne, a.PlayerOne.Point.Y);
            //}

            return baseValue;
        }

        private static bool IsLegalMove(double p1, double p2)
        {
            if (p1 >= 0 && p2 >= 0)
            {
                return true;
            }
            return false;
        }

        // 2
        static bool ValidateValueCallbackMethodPlayerOne(object value)
        {
            return true;
        }

        // 3
        static void ChangedCallbackMethodPlayerOne(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var a = (GameCanvas)d;
            a._playerOne.Fill = a.PlayerOne.Avatar;
            Canvas.SetLeft(a._playerOne, (e.NewValue as Player).Point.X);
            Canvas.SetTop(a._playerOne, a.PlayerOne.Point.Y);
        }


        ///------------------------------------------------------------------------
        ///
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            //_playerOne = new Canvas();
            //_playerOne.Background = PlayerOne.PlayerAvatar;
            _playerOne.Width = 35;
            _playerOne.Height = 35;
            Canvas.SetLeft(_playerOne, 0);
            Canvas.SetTop(_playerOne, 0);
            this.Children.Add(_playerOne);
        }
    }
}
