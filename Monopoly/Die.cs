using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly
{
    class Die
    {
        public static int RollADie()
        {
            Random random = new Random();
            int dice = random.Next(1, 7);
            return dice;
        }

        public static Tuple<int, int> RollTwoDice()
        {
            int die1 = RollADie();
            int die2 = RollADie();
            Tuple<int, int> tuple = new Tuple<int, int>(die1, die2);
            return tuple; 
        }
    }
}
