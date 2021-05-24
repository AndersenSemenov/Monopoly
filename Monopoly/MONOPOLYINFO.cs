using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly
{
    class MONOPOLYINFO
    {
        public static Dictionary<string, List<int>> monopolies = new Dictionary<string, List<int>>();
        public static bool BelongToOneMonopoly(string color, Player owner)
        {
            foreach (var cell in Game.cells)
            {
                if (cell as Company != null && (cell as Company).Color == color)
                {
                    if ((cell as Company).Owner != owner || (cell as Company).Owner == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void CreateDictionary()
        {
            foreach (var cell in Game.cells)
            {
                if (cell as Company != null && (cell as Company).Color != null)
                {
                    if (!monopolies.ContainsKey((cell as Company).Color))
                    {
                        monopolies.Add((cell as Company).Color, new List<int>(new int[] { cell.Position }));
                    }
                    else
                    {
                        monopolies[(cell as Company).Color].Add(cell.Position);
                    }
                }
            }
        }

        public static void CreateMonopoly(string color)
        {
            foreach (var cell in Game.cells)
            {
                if (cell as Company != null && (cell as Company).Color == color)
                {
                    Game.cells[cell.Position] = new Monopoly(cell as Super);
                }
            }
        }
    }
}
