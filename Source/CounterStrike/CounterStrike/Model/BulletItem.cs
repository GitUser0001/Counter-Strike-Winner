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
    public class BulletItem
    {
        public BulletItem(Point position, Direction direction, string ownerNickName) : this(position, direction, ownerNickName, 10)
        {
        }

        public BulletItem(Point position, Direction direction, string ownerNickName, double radius) :
            this(position, direction, ownerNickName, radius, new ImageBrush())
        {
            Color color = Colors.DarkGray;
            ImageBrush imgBrush = new ImageBrush(CreateBitmapSource(color));
            Recangle.Fill = imgBrush;
        }

        public BulletItem(Point position, Direction direction, string ownerNickName, double radius, ImageBrush image)
        {
            Position = position;
            Recangle = new Rectangle();
            Recangle.Width = radius;
            Recangle.Height = radius;
            CreatedTime = DateTime.Now;
            Direction = direction;
            OwnerNickName = ownerNickName;

            Recangle.Fill = image;
        }

        public Point Position { get; set; }
        public Rectangle Recangle { get; set; }
        public DateTime CreatedTime { get; private set; }
        public Direction Direction { get; private set; }
        public string OwnerNickName { get; private set; }

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
