using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrike.GameLogic
{
    public struct Coordinate
    {
        private float _x;
        private float _y;

        public Coordinate(float x, float y)
        {
            this._x = x;
            this._y = y;
        }

        /// <summary>
        /// The coordinate on canvas is LEFT 
        /// </summary>
        public float X
        {
            get { return this._x; }
            set { this._x = value;}
        }

        /// <summary>
        /// The coordinate on canvas is TOP
        /// </summary>
        public float Y
        {
            get { return this._y; }
            set { this._y = value;}
        }
    }
}
