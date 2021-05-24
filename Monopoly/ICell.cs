using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly
{
    interface ICell
    {
        string Name { get; set; } 
        int Position { get; set; }

        void Action(Player player);
    }
}
