using CounterStrike.Model;
using CounterStrike.ViewModel;
using CounterStrikeLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace CounterStrike.Engine
{
    public class GameEngine
    {
        private ObservableCollection<BulletItem> _bulletsList;
        private ObservableCollection<WallItem> _wallItems;
        private IEnumerable<Rect> _wallsCoordinates;
        private IEnumerable<Rect> _bulletsCoordinates;
        private GameControlViewModel _gameControlViewModel;
        private Thread _bulletPositionChangingThred;
        private Thread _playerPositionChangingThred;
       // private ThreadPool _playersPositionChangingThreadPool;

        public GameEngine(
                            GameControlViewModel gameControlViewModel,
                            ObservableCollection<BulletItem> bulletsList,
                            ObservableCollection<WallItem> wallItems)
        {
            _bulletsList = bulletsList;
            _wallItems = wallItems;
            _gameControlViewModel = gameControlViewModel;

            _wallsCoordinates = new List<Rect>();
            //UpdateWallsCoordinates();
        }

        public void MovePlayer(Player player, Direction direction)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player is null");
            }

            //if (_bulletPositionChangingThred == null || _bulletPositionChangingThred.ThreadState == ThreadState.Stopped)
            //{
                new Thread(() => ChangePlayerPosition(player, direction)).Start();
                //_playerPositionChangingThred.Start();
            //}
        }

        public void MoveBullets()
        {
            if (_bulletsList == null)
            {
                throw new ArgumentNullException("bullet is null");
            }

            if (_bulletPositionChangingThred == null || _bulletPositionChangingThred.ThreadState == ThreadState.Stopped)
            {
                _bulletPositionChangingThred = new Thread(BulletPositionChangedTick);
                _bulletPositionChangingThred.Start();
            }
        }

        private void ChangePlayerPosition(Player player, Direction direction)
        {
            player.ChangePosition(direction);

            double x = player.PointNew.X;
            double y = player.PointNew.Y;

            Rect playerRect = new Rect(
                                        player.PointNew.X,
                                        player.PointNew.Y,
                                        35,
                                        35);

            //if (x >= 0 && y >= 0 && !_wallsCoordinates.Any(xx => xx.IntersectsWith(playerRect)))
            if (x >= 0 && y >= 0)
            {
                _gameControlViewModel.UpdatePlayers();
            }

            if (_bulletsCoordinates != null && _bulletsCoordinates.Any(xx => xx.IntersectsWith(playerRect)))
            {
                player.Health -= 20;
            }
        }

        private void UpdateWallsCoordinates()
        {
            if (_wallItems == null)
            {
                 throw new ArgumentNullException("_wallItems");
            }

            System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((Action)(() =>
            {
                _wallsCoordinates = GameSettings.Map.WallItems.Select(r => new Rect(
                                r.X,
                                r.Y,
                                r.Recangle.Width,
                                r.Recangle.Height));
            }));
        }

        private void UpdateBulletsCoordinates()
        {
            if (_bulletsList == null)
            {
                throw new ArgumentNullException("bulletsList is null");
            }
            // Opportynity for optimisation
            _bulletsCoordinates = _bulletsList.Select(r => new Rect(
                                                                    r.Position.X,
                                                                    r.Position.Y,
                                                                    r.Recangle.Width,
                                                                    r.Recangle.Height));
        }

        private void BulletPositionChangedTick()
        {
            do
            {
                foreach (var bullet in _bulletsList)
                {
                    bullet.MoveBuller();
                }

                UpdateBulletsCoordinates();

                _gameControlViewModel.UpdateBullets();

                Thread.Sleep(500);
            }
            while (_bulletsList.Count > 0);
        }
    }
}

