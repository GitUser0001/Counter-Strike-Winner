using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterStrike.ViewModel;
using System.Windows.Media.Imaging;
using CounterStrikeLibrary;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace CounterStrike.Model
{
    public class Bullet : ViewModelBase
    {
        public Point CurrentCoordinateBullet;

        private Image _bullet;
        private BitmapImage _img;
        private int _count;
        private string _photo;
        private int _stepBullet;
        private DoubleAnimation _animationX = null;
        private DoubleAnimation _animationY = null;

        public Bullet()
        {
            _stepBullet = 2000;
            this._img = new BitmapImage();
            this._photo = "pack://application:,,,/Media/Bullet/bulletTop.png";
        }

        public Direction BulletDirection { get; set; }

        public string Photo
        {
            get
            {
                return this._photo;
            }
            set
            {
                if (value != this._photo)
                {
                    this._photo = value;
                    this.OnPropertyChanged("Photo");
                }
            }
        }

        public int Count
        {
            get
            {
                return this._count;
            }
            set
            {
                if (value != this._count)
                {
                    this._count = value;
                    this.OnPropertyChanged("Count");
                }
                if(value <= -1)
                {
                    this._count = 0;
                    this.OnPropertyChanged("Count");
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="direction">The direction of shooting</param>
        /// <param name="shootFrom">The player that is shooting</param>
        /// <param name="shootTo">The player that is damage</param>
        public void Shoot(Direction direction, Point shootFrom, Panel canvas)
        {
            /// Check the count of bullets in user
            if (this.Count == 0)
                return;


            this.BulletDirection = direction;
            this.SetDirectionBullet(direction);

            //// Create image of bullet
            //// Dependency of direction
            this._bullet = new Image();
            this._bullet.Width = 32;
            this._bullet.Height = 32;

            this._bullet.Source = _img;

            /// add bullet to canvas
            /// shoot from and set bulet from user
            Canvas.SetLeft(_bullet, shootFrom.X);
            Canvas.SetTop(_bullet, shootFrom.Y);

            if(canvas != null)
                canvas.Children.Add(this._bullet);


            //// Move
            var startX = Canvas.GetLeft(_bullet);
            var startY = Canvas.GetTop(_bullet);

            double endX = ((_bullet.Width / 2) + Canvas.GetLeft(_bullet)) - startX - (_bullet.Width / 2);
            double endY = ((_bullet.Height / 2) + Canvas.GetTop(_bullet)) - startY - (_bullet.Height / 2);

            this.SetDirectionCoordinateBullet(endX, endY);


            if (_animationX != null && _animationY != null)
            {
                /// Transform image to coordinates
                TranslateTransform transform = new TranslateTransform();
                _bullet.RenderTransform = transform;

                transform.BeginAnimation(TranslateTransform.XProperty, _animationX);
                transform.BeginAnimation(TranslateTransform.YProperty, _animationY);
            }
        }

        private void SetDirectionBullet(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    _img = new BitmapImage(new Uri(@"pack://application:,,,/Media/Bullet/bulletTop.png"));
                    break;
                case Direction.Down:
                    _img = new BitmapImage(new Uri(@"pack://application:,,,/Media/Bullet/bulletDown.png"));
                    break;
                case Direction.Left:
                    _img = new BitmapImage(new Uri(@"pack://application:,,,/Media/Bullet/bulletLeft.png"));
                    break;
                case Direction.Right:
                    _img = new BitmapImage(new Uri(@"pack://application:,,,/Media/Bullet/bulletRight.png"));
                    break;
                case Direction.Up_Left:
                    break;
                case Direction.Up_Right:
                    break;
                case Direction.Down_Left:
                    break;
                case Direction.Down_Right:
                    break;
                default:
                    break;
            }
        }

        private void SetDirectionCoordinateBullet(double endX, double endY)
        {
            switch (this.BulletDirection)
            {
                case Direction.Up:
                    {
                        _animationX = new DoubleAnimation(endX, endX, TimeSpan.FromSeconds(4));
                        _animationY = new DoubleAnimation(endY, endY - _stepBullet, TimeSpan.FromSeconds(4));
                    }
                    break;
                case Direction.Down:
                    {
                        _animationX = new DoubleAnimation(endX, endX, TimeSpan.FromSeconds(4));
                        _animationY = new DoubleAnimation(endY, endY + _stepBullet, TimeSpan.FromSeconds(4));
                    }
                    break;
                case Direction.Left:
                    {
                        _animationX = new DoubleAnimation(endX, endX - _stepBullet, TimeSpan.FromSeconds(4));
                        _animationY = new DoubleAnimation(endY, endY, TimeSpan.FromSeconds(4));
                    }
                    break;
                case Direction.Right:
                    {
                        _animationX = new DoubleAnimation(endX, endX + _stepBullet, TimeSpan.FromSeconds(4));
                        _animationY = new DoubleAnimation(endY, endY, TimeSpan.FromSeconds(4));
                    }
                    break;
                case Direction.Up_Left:
                    break;
                case Direction.Up_Right:
                    break;
                case Direction.Down_Left:
                    break;
                case Direction.Down_Right:
                    break;
                default:
                    break;
            }
        }
    }
}
