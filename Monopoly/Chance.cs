using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace Monopoly
{
    class Chance: Field
    {
        public override bool Action(Player player)
        {
            Random random = new Random();
            int value = random.Next(1, 22);
            if (value <= 8)
            {
                player.Plus(value * 250);
            }
            else if (value <= 16)
            {
                player.Minus((value - 8) * 250); //
            }
            else if (value <= 18)
            {
                Console.WriteLine($"{player.Name} got a chance of add move");
                player.Move();
                //player.CurrentPosition = (player.CurrentPosition + random.Next(1, 13)) % 40;
            }
            else if (value == 19)
            {

            }
            else
            {
                // Action
            }
            return true;
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
