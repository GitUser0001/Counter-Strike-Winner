using CounterStrikeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CounterStrike.Model
{
    public class Player
    {
        private ImageBrush _avatar;
        private Point _pointNew;
        private Point _pointOld;
        private double _step;

        /// <summary>
        /// Create Empty Заглушку
        /// </summary>
        public Player()
        {
        }

        public Player(string nickName, PlayerType regionType, int weaponNumber, Color color)
        {
            NickName = nickName;
            RegionType = regionType;
            WeaponNumber = weaponNumber;

            var colorBitmapSource = CreateBitmapSource(color);
            Color = new ImageBrush(colorBitmapSource);

            SetPlayerParameters(regionType);
        }

        public ImageBrush Avatar
        {
            get
            {
                return _avatar;
            }
        }

        public Point PointNew
        {
            get
            {
                if (_pointNew == null)
                {
                    _pointNew = new Point(1, 1);
                }
                return _pointNew;
            }
            private set
            {
                _pointNew = value;
            }
        }

        public Point PointOld
        {
            get
            {
                if (_pointOld == null)
                {
                    _pointOld = new Point(0, 0);
                }
                return _pointOld;
            }
            private set
            {
                _pointOld = value;
            }
        }

        public string NickName { get; set; }

        public PlayerType RegionType { get; set; }

        public int WeaponNumber { get; set; }

        public ImageBrush Color { get; set; }

        public ushort Health { get; set; }

        public void RevertPosition()
        {
            _pointNew.X = PointOld.X;
            _pointNew.Y = PointOld.Y;
        }

        public void ChangePosition(Direction direction)
        {
            _pointOld.X = PointNew.X;
            _pointOld.Y = PointNew.Y;

            switch (direction)
            {
                case Direction.Up:
                    _pointNew.Y -= _step;
                    break;
                case Direction.Down:
                    _pointNew.Y += _step;
                    break;
                case Direction.Left:
                    _pointNew.X -= _step;
                    break;
                case Direction.Right:
                    _pointNew.X += _step;
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

        public override string ToString()
        {
            return string.Format("{0} : {1}", NickName, Health);
        }

        private void SetPlayerParameters(PlayerType regionType)
        {
            Uri imageSource;

            switch (regionType)
            {
                case PlayerType.Terrorist:
                    imageSource = new Uri("pack://application:,,,/Media/Models/counterstrike1.png");
                    Health = 100;
                    _step = 5;
                    break;
                case PlayerType.CounterTerrorist:
                    imageSource = new Uri("pack://application:,,,/Media/Models/counterstrike3_256.png");
                    Health = 100;
                    _step = 5;
                    break;
                case PlayerType.ADMIN:
                    imageSource = new Uri("pack://application:,,,/Media/Models/policeman.png");
                    Health = 999;
                    _step = 10;
                    break;
                default:
                    imageSource = new Uri("pack://application:,,,/Media/Models/policeman.png");
                    Health = 1;
                    _step = 5;
                    break;
            }
            ImageSource avatarImage = new BitmapImage(imageSource);
            _avatar = new ImageBrush(avatarImage);
        }

        private BitmapSource CreateBitmapSource(System.Windows.Media.Color color)
        {
            int width = 128;
            int height = width;
            int stride = width / 8;
            byte[] pixels = new byte[height * stride];

            List<System.Windows.Media.Color> colors = new List<System.Windows.Media.Color>();
            colors.Add(color);
            BitmapPalette myPalette = new BitmapPalette(colors);

            BitmapSource image = BitmapSource.Create(
                width,
                height,
                96,
                96,
                PixelFormats.Indexed1,
                myPalette,
                pixels,
                stride);

            return image;
        }
    }
}
