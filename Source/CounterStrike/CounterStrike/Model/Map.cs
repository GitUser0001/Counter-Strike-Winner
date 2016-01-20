using CounterStrikeLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<WallItem> _wallItems;

        public Map(MapType mapType)
        {
            ImageSource backgroundImage = MapRepository.GetImage(mapType);
            _backgroundImage = new ImageBrush(backgroundImage);
        }

        public ObservableCollection<WallItem> WallItems
        {
            get
            {
                if (_wallItems == null)
                {
                    _wallItems = GenerateWallItems();
                }
                return _wallItems;
            }
        }

        public ImageBrush BackgroundImage
        {
            get
            {
                return _backgroundImage;
            }
        }

        private ObservableCollection<WallItem> GenerateWallItems()
        {
            ObservableCollection<WallItem> resWalls = new ObservableCollection<WallItem>();

            WallItem wallItem;

            wallItem = new WallItem(50,150,40,60,Colors.DarkMagenta);
            resWalls.Add(wallItem);

            wallItem = new WallItem(240, 60, 70, 60, Colors.Gray);
            resWalls.Add(wallItem);

            wallItem = new WallItem(160, 200, 70, 30, Colors.LightGreen);
            resWalls.Add(wallItem);

            return resWalls;
        }
    }
}
