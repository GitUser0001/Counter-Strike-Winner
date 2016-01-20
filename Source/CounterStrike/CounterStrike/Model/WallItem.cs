using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CounterStrike.Model
{
    public class WallItem
    {
        public WallItem(double x, double y, double width, double height, Color color)
        {
            this.X = x;
            this.Y = y;
            Recangle = new Rectangle();
            Recangle.Width = width;
            Recangle.Height = height;
            ImageBrush imgBrush = new ImageBrush(CreateBitmapSource(color));
            Recangle.Fill = imgBrush;
        }

        public WallItem(double x, double y, double width, double height, ImageBrush image)
        {
            this.X = x;
            this.Y = y;
            Recangle = new Rectangle();
            Recangle.Width = width;
            Recangle.Height = height;
            Recangle.Fill = image;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public Rectangle Recangle { get; set; }

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
