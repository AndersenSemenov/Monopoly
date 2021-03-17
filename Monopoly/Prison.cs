using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace Monopoly
{
    class Prison : Cell
    {
        public static List<Player> jailed = new List<Player>();
        public override void Action(Player player)
        {
            if (jailed.Contains(player))
            {
                Tuple<int, int> dice = Die.RollTwoDice();
                Console.WriteLine($"{player.Name} tries to get out of the prison");
                player.BlockMovement--;
                if (dice.Item1 == dice.Item2)
                {
                    player.BlockMovement = 0;
                    jailed.Remove(player);
                    player.MoveOnBoard(dice.Item1, dice.Item2);
                }
                else if (player.BlockMovement == 0)
                {
                    jailed.Remove(player);
                    player.Pay(1000);
                    player.MoveOnBoard(dice.Item1, dice.Item2);
                }
            }
        }

        public static void Create()
        {
            using (StreamReader sr = new StreamReader("D:/С#/Monopoly/Prison.txt"))
            {
                string s = sr.ReadLine();
                while (s != null)
                {
                    Prison prison = JsonSerializer.Deserialize<Prison>(s);
                    Game.cells[prison.Position] = prison;
                    s = sr.ReadLine();
                }
            }
        }
    }
}
