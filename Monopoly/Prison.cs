using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly
{
    class Prison : Field
    {
        // list добавить игроков
        public static List<Player> jailed = new List<Player>();
        public override bool Action(Player player)
        {
            Tuple<int, int> dice = Die.RollTwoDice();
            if (dice.Item1 == dice.Item2)
            {
                player.BlockMovement = 0;
                jailed.Remove(player);
                player.MoveOnBoard(dice.Item1, dice.Item2);
            }
            else if (player.BlockMovement == 3)
            {
                player.BlockMovement = 0;
                jailed.Remove(player);
                player.Minus(1000);
                player.MoveOnBoard(dice.Item1, dice.Item2);
            }
            player.BlockMovement++;
            return true;
        }
    }
}
