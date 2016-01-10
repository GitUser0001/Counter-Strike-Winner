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
    public class Map
    {
        private ImageBrush _backgroundImage;

        public Map(MapType mapType)
        {
            ImageSource backgroundImage = MapRepository.GetImage(mapType);
            _backgroundImage = new ImageBrush(backgroundImage);
        }

        public ImageBrush BackgroundImage
        {
            get
            {
                return _backgroundImage;
            }
        }
    }
}
