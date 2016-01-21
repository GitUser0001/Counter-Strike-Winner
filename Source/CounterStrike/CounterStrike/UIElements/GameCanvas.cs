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
            var gameCanvas = (GameCanvas)d;

            gameCanvas._playerOne.Fill = gameCanvas.PlayerOne.DirectionImage;

            if (IsLegalMove(true, gameCanvas))
            {
                Canvas.SetLeft(gameCanvas._playerOne, gameCanvas.PlayerOne.PointNew.X);
                Canvas.SetTop(gameCanvas._playerOne, gameCanvas.PlayerOne.PointNew.Y);
            }
            else
            {
                gameCanvas.PlayerOne.RevertPosition();
            }

            return baseValue;
        }

        private static bool IsLegalMove(bool IsPlayerOne, GameCanvas gameCanvas)
        {
            Rectangle playerRectangle;
            Player player;

            if (IsPlayerOne)
            {
                player = gameCanvas.PlayerOne;
                playerRectangle = gameCanvas._playerOne;
            }
            else
            {
                player = gameCanvas.PlayerTwo;
                playerRectangle = gameCanvas._playerTwo;
            }

            double X = player.PointNew.X;
            double Y = player.PointNew.Y;
            double Width = gameCanvas.ActualWidth - 30;
            double Height = gameCanvas.ActualHeight - 33;

            Rect playerRect = new Rect(player.PointNew.X,
                                        player.PointNew.Y,
                                        playerRectangle.Width,
                                        playerRectangle.Height);

            if (X >= 0 && Y >= 0 && X <= Width && Y <= Height && !gameCanvas._wallsCoordinates.Any(x => x.IntersectsWith(playerRect)))
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
            var gameCanvas = (GameCanvas)d;

            gameCanvas._playerTwo.Fill = gameCanvas.PlayerTwo.DirectionImage;

            if (IsLegalMove(false, gameCanvas))
            {
                Canvas.SetLeft(gameCanvas._playerTwo, gameCanvas.PlayerTwo.PointNew.X);
                Canvas.SetTop(gameCanvas._playerTwo, gameCanvas.PlayerTwo.PointNew.Y);
            }
            else
            {
                gameCanvas.PlayerTwo.RevertPosition();
            }

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
            var gameCanvas = (GameCanvas)d;
            gameCanvas._playerOne.Fill = gameCanvas.PlayerOne.Avatar;
            //var a = (GameCanvas)d;
            //a._playerTwo.Fill = a.PlayerTwo.Avatar;
            //Canvas.SetLeft(a._playerTwo, (e.NewValue as Player).Point.X);
            //Canvas.SetTop(a._playerTwo, a.PlayerTwo.Point.Y);
        }
        //------------------------------------------------------------------------
        //------------------------------------------------------------------------
        // ----------------  WALS  -----------------------------------------------

        private Collection<Rectangle> _walls = new Collection<Rectangle>();
        IEnumerable<Rect> _wallsCoordinates = new List<Rect>();
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

            a._wallsCoordinates = a.Walls.Select(r => new Rect(Canvas.GetLeft(r.Recangle),
                                                                Canvas.GetTop(r.Recangle),
                                                                r.Recangle.Width,
                                                                r.Recangle.Height));

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
