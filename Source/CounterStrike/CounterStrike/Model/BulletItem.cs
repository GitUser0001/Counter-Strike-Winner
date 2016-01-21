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
        private Point _position;

        public BulletItem(Point position, Direction direction, string ownerNickName) : this(position, direction, ownerNickName, 10, 10)
        {
        }

        public BulletItem(Point position, Direction direction, string ownerNickName, double radius, double speed) :
            this(position, direction, ownerNickName, radius, speed, new ImageBrush())
        {
            Color color = Colors.DarkGray;
            ImageBrush imgBrush = new ImageBrush(CreateBitmapSource(color));
            Recangle.Fill = imgBrush;
        }

        public BulletItem(Point position, Direction direction, string ownerNickName, double radius, double speed, ImageBrush image)
        {
            Position = position;
            Recangle = new Rectangle();
            Recangle.Width = radius;
            Recangle.Height = radius;
            CreatedTime = DateTime.Now;
            //Direction = direction;
            OwnerNickName = ownerNickName;

            Recangle.Fill = image;

            switch (direction)
            {
                case Direction.Up:
                    Step = new Point(0, (-1) * speed);
                    break;
                case Direction.Down:
                    Step = new Point(0, speed);
                    break;
                case Direction.Left:
                    Step = new Point((-1) * speed, 0);
                    break;
                case Direction.Right:
                    Step = new Point(speed, 0);
                    break;
                default:
                    Step = new Point(speed, speed);
                    break;
            }
        }

        public Point Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        public Rectangle Recangle { get; set; }
        public DateTime CreatedTime { get; private set; }
        //public Direction Direction { get; private set; }
        public string OwnerNickName { get; private set; }
        public Point Step { get; set; }

        public void MoveBuller()
        {
            _position.X += Step.X;
            _position.Y += Step.Y;
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
