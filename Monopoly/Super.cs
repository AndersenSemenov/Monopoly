using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly
{
    abstract class Super : ICell
    {
        public int Cost { get; set; }
        public abstract int Rent { get; set; }
        public bool IsBought { get; set; }
        public Player Owner { get; set; }
        public string Color { get; set; }
        public abstract int Level { get; }
        public string Name { get; set; }
        public int Position { get; set; }
        public int HouseCost { get; set; }

        public abstract void Action(Player player);
        public abstract void Sell(Player player);
    }
}
