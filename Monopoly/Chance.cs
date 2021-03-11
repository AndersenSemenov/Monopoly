using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace Monopoly
{
    class Chance: Field
    {
        public static void GetChance(Player player)
        {
            Random random = new Random();
            int value = random.Next(1, 11);
            if (value <= 8)
            {
                player.Plus(value * 250);
                // cw ??
            }
            else if (value == 9)
            {
                player.Minus(random.Next(1, 9) * 250);
            }
            else if (value == 10)
            {
                player.CurrentPosition = (player.CurrentPosition + random.Next(1, 41)) % 40;
            }
        }

        public static void Create()
        {
            using (StreamReader sr = new StreamReader("D:/С#/Monopoly/Chances.txt"))
            {
                string s = sr.ReadLine();
                while (s != null)
                {
                    Chance chance = JsonSerializer.Deserialize<Chance>(s);
                    Game.fields[chance.Position] = chance;
                    s = sr.ReadLine();
                }
            }
        }
    }
}
