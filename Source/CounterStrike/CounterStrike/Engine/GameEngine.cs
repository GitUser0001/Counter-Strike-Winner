using CounterStrike.Model;
using CounterStrikeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrike.Engine
{
    public static class GameEngine
    {
        public static void MovePlayer(Player player, Direction direction)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }

            player.ChangePosition(direction);
        }

        public static void MoveBullet(BulletItem bullet)
        {
            if (bullet == null)
            {
                throw new ArgumentNullException("bullet");
            }

            bullet.MoveBuller();
        }
    }
}

