using CounterStrikeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CounterStrike.GameLogic;

namespace CounterStrike.Model
{
    public class Map
    {
        private ImageBrush _backgroundImage;

        public Map()
        {
        }

        public Map(float height, float width)
        {
            this.Height = height;
            this.Width = width;
        }

        public Map(MapType mapType)
        {
            ImageSource backgroundImage = MapRepository.GetImage(mapType);
            _backgroundImage = new ImageBrush(backgroundImage);
        }

        public float Height { get; set; }
        public float Width { get; set; }

        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }

        public ImageBrush BackgroundImage
        {
            get
            {
                return _backgroundImage;
            }
        }
    }
}
