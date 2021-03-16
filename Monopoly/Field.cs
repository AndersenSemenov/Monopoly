using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly
{
    class Field
    {
        public string Name { get; set; } 
        public int Position { get; set; }

        public virtual bool Action(Player player)
        {
            return true;
        }
    }
}
