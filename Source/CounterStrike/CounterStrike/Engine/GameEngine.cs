using CounterStrike.Model;
using CounterStrikeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrike.Engine
{
    class GameEngine
    {
        public static class GameEngine
        {
            public static void MovePlayer(Player player, Direction direction)
            {
                player.ChangePosition(direction);
            }

            public static void MoveBullet(BulletItem bullet)
            {
                bullet.MoveBuller();
            }
        }
    }
}
