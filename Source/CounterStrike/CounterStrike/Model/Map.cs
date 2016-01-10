using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CounterStrike.Model
{
    public class Map
    {
        private static string _imageMap;
        private static string _pathToMap1 = "pack://application:,,,/Media/Maps/de_dust2.jpg";
        private static string _pathToMap2 = "pack://application:,,,/Media/Maps/de_aztec.jpeg";
        private static string _pathToMap3 = "pack://application:,,,/Media/Maps/de_inferno.bmp";

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Map()
        {
        }

        public static string ImageMap
        {
            get { return _imageMap; }
            set { _imageMap = value; }
        }

        /// <summary>
        /// Load Map <de_dust2>
        /// </summary>
        public static void LoadMap1()
        {
            _imageMap = _pathToMap1;
        }

        /// <summary>
        /// Load Map <de_aztec>
        /// </summary>
        public static void LoadMap2()
        {
            _imageMap = _pathToMap2;
        }

        /// <summary>
        /// Load Map <de_inferno>
        /// </summary>
        public static void LoadMap3()
        {
            _imageMap = _pathToMap3;
        }
    }
}
