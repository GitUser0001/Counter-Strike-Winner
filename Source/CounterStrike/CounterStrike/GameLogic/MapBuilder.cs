using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterStrike.Model;

namespace CounterStrike.GameLogic
{
    public abstract class MapBuilder
    {
        protected Map map;

        /// <summary>
        /// Instance of game map with players and settings
        /// </summary>
        public Map GameMap
        {
            get { return this.map; }
            set { this.map = value; }
        }

        /// <summary>
        /// Method to create map
        /// </summary>
        /// <returns></returns>
        public abstract Map CreateMap();

        /// <summary>
        /// Reset all map settings
        /// </summary>
        public virtual void Clear()
        {
            this.map = null;
        }

        // Abstract build methods
        public abstract void BuildPlayers();
        public abstract void BuildBlocks();
        public abstract void BuildArtifacts();
    }
}
