using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace Monopoly
{
    class Chance: Cell
    {
        public override void Action(Player player)
        {
            Random random = new Random();
            int value = random.Next(1, 21);
            if (value <= 8)
            {
                player.Recieve(value * 250);
                Console.WriteLine();
            }
            else if (value <= 16)
            {
                player.Pay((value - 8) * 250);
                Console.WriteLine();
            }
            else if (value <= 18)
            {
                Console.WriteLine($"{player.Name} got a chance of add move");
                Console.WriteLine();
                player.Move();
            }
            else
            {
                Game.cells[30].Action(player);
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
                    Game.cells[chance.Position] = chance;
                    s = sr.ReadLine();
                }
            }
        }
    }
}
