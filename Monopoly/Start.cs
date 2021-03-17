using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace Monopoly
{
    class Start : Cell
    {
        public override void Action(Player player)
        {
            Console.WriteLine($"{player.Name} passed the circle");
            player.Recieve(1000);
        }

        public static void Create()
        {
            using (StreamReader sr = new StreamReader("D:/С#/Monopoly/Start.txt"))
            {
                string s = sr.ReadLine();
                while (s != null)
                {
                    Start start = JsonSerializer.Deserialize<Start>(s);
                    Game.cells[start.Position] = start;
                    s = sr.ReadLine();
                }
            }
        }
    }
}
