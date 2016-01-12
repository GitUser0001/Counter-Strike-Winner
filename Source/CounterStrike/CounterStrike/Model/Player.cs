using CounterStrikeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CounterStrike.GameLogic;

namespace CounterStrike.Model
{
    public class Player
    {
        private ImageBrush _playerAvatar;

        public Player(string nickName, PlayerType regionType, int weaponNumber, Color color)
        {
            NickName = nickName;
            RegionType = regionType;
            WeaponNumber = weaponNumber;

            var colorBitmapSource = CreateBitmapSource(color);
            Color = new ImageBrush(colorBitmapSource);

            SetHealth(regionType);
            SetAvatar(regionType);
        }

        public ImageBrush PlayerAvatar
        {
            get
            {
                return _playerAvatar;
            }
        }

        public Coordinate CoordinatePlayer { get; set; }

        public string NickName { get; set; }

        public PlayerType RegionType { get; set; }

        public int WeaponNumber { get; set; }

        public ImageBrush Color { get; set; }

        public int Health { get; set; }

        public override string ToString()
        {
            return string.Format("{0} : {1}", NickName, Health);
        }

        private void SetHealth(PlayerType regionType)
        {
            switch (regionType)
            {
                case PlayerType.Terrorist:
                    Health = 100;
                    break;
                case PlayerType.CounterTerrorist:
                    Health = 100;
                    break;
                case PlayerType.ADMIN:
                    Health = 999;
                    break;
                default:
                    Health = 1;
                    break;
            }
        }

        private void SetAvatar(PlayerType regionType)
        {
            Uri imageSource;

            switch (regionType)
            {
                case PlayerType.Terrorist:
                    imageSource = new Uri("pack://application:,,,/Media/Models/counterstrike1.png");
                    break;
                case PlayerType.CounterTerrorist:
                    imageSource = new Uri("pack://application:,,,/Media/Models/counterstrike3_256.png");
                    break;
                case PlayerType.ADMIN:
                    imageSource = new Uri("pack://application:,,,/Media/Models/policeman.png");
                    break;
                default:
                    imageSource = new Uri("pack://application:,,,/Media/Models/policeman.png");
                    break;
            }
            ImageSource avatarImage = new BitmapImage(imageSource);
            _playerAvatar = new ImageBrush(avatarImage);
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
