using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace Monopoly
{
    class GetToPrison : ICell
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public void Action(Player player)
        {
            player.BlockMovement = 3;
            player.CurrentPosition = 10;
            Prison.jailed.Add(player);
        }

        public static void Create()
        {
            using (StreamReader sr = new StreamReader("D:/С#/Monopoly/GetToPrison.txt"))
            {
                string s = sr.ReadLine();
                while (s != null)
                {
                    GetToPrison getToPrison = JsonSerializer.Deserialize<GetToPrison>(s);
                    Game.cells[getToPrison.Position] = getToPrison;
                    s = sr.ReadLine();
                }
            }
        }
    }
}
