using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly
{
    class Start : Field
    {
        public override bool Action(Player player)
        {
            Console.WriteLine($"{player.Name} прошел круг");
            player.Plus(1000);
            return true;
        }
    }
}
