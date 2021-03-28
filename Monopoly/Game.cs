using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Monopoly
{
    class Game
    {
        public static List<Player> players = new List<Player>();

        public static Cell[] cells = new Cell[40];
        
        public void Play(string first, string second)
        {
            players.Add(new Player(first));
            players.Add(new Player(second));
            CreateCells();
            int Count = players.Count;
            int Turn = 1;
            while (Count > 1)
            {
                Console.WriteLine($"Turn {Turn}");
                players[0].PrintData();
                players[1].PrintData();
                foreach (var player in players)
                {
                    if (!player.IsLost)
                    {
                        player.Move();
                    }
                }
                //Thread.Sleep(2000);
                Console.Clear();
                foreach (var player in players)
                {
                    if (player.IsLost)
                    {
                        Count--;
                    }
                }
                Turn++;
            }
            foreach (var player in players)
            {
                if (!player.IsLost)
                {
                    Console.WriteLine($"{player.Name} won on Turn number {Turn}!");
                }
            }
        }

        public void CreateCells()
        {
            Start.Create();
            Company.Create();
            Chance.Create();
            TaxeField.Create();
            GetToPrison.Create();
            Prison.Create();
        }
    }
}
