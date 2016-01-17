using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterStrike.Model;

namespace CounterStrike.GameLogic
{
    public class GameMapBuilder : MapBuilder
    {
        public GameMapBuilder()
        {
            this.map = new Map();
        }

        public override Map CreateMap()
        {
            this.BuildPlayers();
            this.BuildBlocks();
            this.BuildArtifacts();

            return this.map;
        }

        public override void BuildPlayers()
        {
            //// NOT HAVE IMPLEMENTATION
            this.map.PlayerOne.CoordinatePlayer = new Coordinate(10, 10);
            this.map.PlayerTwo.CoordinatePlayer = new Coordinate(230, 230);
        }

        public override void BuildBlocks()
        {
            throw new NotImplementedException();
        }

        public override void BuildArtifacts()
        {
            throw new NotImplementedException();
        }
    }
}
