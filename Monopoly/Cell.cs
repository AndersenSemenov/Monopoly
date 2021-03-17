using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly
{
    abstract class Cell
    {
        public string Name { get; set; } 
        public int Position { get; set; }

        public abstract void Action(Player player);
    }
}
