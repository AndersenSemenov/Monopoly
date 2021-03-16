using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly
{
    class GetToPrison : Field
    {
        public override bool Action(Player player)
        {
            player.BlockMovement = 3;
            player.CurrentPosition = 10;
            Prison.jailed.Add(player);
            return true;
        }
    }
}
