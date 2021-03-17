using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly
{
    class Die
    {
        private static readonly int maxValueOfDie = 7;
        public static int RollADie()
        {
            Random random = new Random();
            int dice = random.Next(1, maxValueOfDie);
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
