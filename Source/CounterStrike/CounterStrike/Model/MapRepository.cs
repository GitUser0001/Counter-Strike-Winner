using CounterStrikeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CounterStrike.Model
{
    public static class MapRepository
    {
        private static string _pathToMap1 = "pack://application:,,,/Media/Maps/de_dust2.jpg";
        private static string _pathToMap2 = "pack://application:,,,/Media/Maps/de_aztec.jpeg";
        private static string _pathToMap3 = "pack://application:,,,/Media/Maps/de_inferno.bmp";
        private static string _pathToMap4 = "pack://application:,,,/Media/Maps/RGASM.jpg";

        public static ImageSource GetImage(MapType mapType)
        {
            ImageSource backgroundImage;
            Uri imageSource;

            switch (mapType)
            {
                case MapType.DeDust:
                    imageSource = new Uri(_pathToMap1);
                    break;
                case MapType.DeWinter:
                    imageSource = new Uri(_pathToMap2);
                    break;
                case MapType.DeRain:
                    imageSource = new Uri(_pathToMap3);
                    break;
                default:
                    imageSource = new Uri(_pathToMap4);
                    break;
            }

            //backgroundImage = new BitmapImage(imageSource);
            imageSource = new Uri(_pathToMap4);
            backgroundImage = new BitmapImage(imageSource);
            return backgroundImage;
        }
    }
}
