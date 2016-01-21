using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeLibrary
{
    public enum MapType
    {
        DeDust,
        DeWinter,
        DeRain
    }

    public enum PlayerType
    {
        Terrorist,
        CounterTerrorist,
        ADMIN
    }

    public enum GameType
    {
        SingleGame,
        MultiGame
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,

        Up_Left,
        Up_Right,
        Down_Left,
        Down_Right
    }
}
