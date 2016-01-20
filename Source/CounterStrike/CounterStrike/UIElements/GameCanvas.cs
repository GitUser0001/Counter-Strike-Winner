using CounterStrike.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        // ---------------------- PLAYER ONE ---------------------------------
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
        //------------------------------------------------------------------------
        //-------------------  Player TWO  --------------------------------------


        private Rectangle _playerTwo = new Rectangle();

        private static FrameworkPropertyMetadata _metadataPlayerTwo = new FrameworkPropertyMetadata(
    new PropertyChangedCallback(ChangedCallbackMethodPlayerTwo), new CoerceValueCallback(CoerceValueCallbackMethodPlayerTwo));

        // Свойство зависимостей.
        public static readonly DependencyProperty PlayerTwoProperty = DependencyProperty.Register("PlayerTwo",
                                                                           typeof(Player),
                                                                           typeof(GameCanvas),
                                                                           _metadataPlayerTwo,
                                                                           new ValidateValueCallback(ValidateValueCallbackMethodPlayerTwo));

        public Player PlayerTwo
        {
            get
            {
                return (Player)GetValue(PlayerTwoProperty);
            }
            set
            {
                SetValue(PlayerTwoProperty, value);
            }
        }

        // 1
        static object CoerceValueCallbackMethodPlayerTwo(DependencyObject d, object baseValue)
        {
            var a = (GameCanvas)d;

            a._playerTwo.Fill = a.PlayerTwo.Avatar;

            //if (IsLegalMove(a.PlayerOne.Point.X, a.PlayerOne.Point.Y))
            //{
            Canvas.SetLeft(a._playerTwo, a.PlayerTwo.Point.X);
            Canvas.SetTop(a._playerTwo, a.PlayerTwo.Point.Y);
            //}

            return baseValue;
        }

        // 2
        static bool ValidateValueCallbackMethodPlayerTwo(object value)
        {
            return true;
        }

        // 3
        static void ChangedCallbackMethodPlayerTwo(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var a = (GameCanvas)d;
            a._playerTwo.Fill = a.PlayerTwo.Avatar;
            Canvas.SetLeft(a._playerTwo, (e.NewValue as Player).Point.X);
            Canvas.SetTop(a._playerTwo, a.PlayerTwo.Point.Y);
        }
        //------------------------------------------------------------------------
        //------------------------------------------------------------------------
        // ----------------  WALS  -----------------------------------------------

        private Collection<Rectangle> _walls = new Collection<Rectangle>();

        private static FrameworkPropertyMetadata _metadataWalls = new FrameworkPropertyMetadata(
            new PropertyChangedCallback(ChangedCallbackMethodWalls), new CoerceValueCallback(CoerceValueCallbackMethodWalls));

        // Свойство зависимостей.
        public static readonly DependencyProperty WallsProperty = DependencyProperty.Register("Walls",
                                                                           typeof(Collection<WallItem>),
                                                                           typeof(GameCanvas),
                                                                           _metadataWalls,
                                                                           new ValidateValueCallback(ValidateValueCallbackMethodWalls));

        public Collection<WallItem> Walls
        {
            get
            {
                return (Collection<WallItem>)GetValue(WallsProperty);
            }
            set
            {
                SetValue(WallsProperty, value);
            }
        }

        // 1
        static object CoerceValueCallbackMethodWalls(DependencyObject d, object baseValue)
        {
            var a = (GameCanvas)d;

            try
            {
                foreach (var wall in a.Walls)
                {
                    Canvas.SetTop(wall.Recangle, wall.Y);
                    Canvas.SetLeft(wall.Recangle, wall.X);
                    a.Children.Add(wall.Recangle);
                }
            }
            catch (Exception)
            {
            }

            return baseValue;
        }

        // 2
        static bool ValidateValueCallbackMethodWalls(object value)
        {
            return true;
        }

        // 3
        static void ChangedCallbackMethodWalls(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        ///------------------------------------------------------------------------
        /// -------------------
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);


            _playerOne.Width = 35;
            _playerOne.Height = 35;
            Canvas.SetLeft(_playerOne, 0);
            Canvas.SetTop(_playerOne, 0);
            this.Children.Add(_playerOne);

            _playerTwo.Width = 35;
            _playerTwo.Height = 35;
            Canvas.SetLeft(_playerTwo, 0);
            Canvas.SetTop(_playerTwo, 0);
            this.Children.Add(_playerTwo);
        }
    }
}
