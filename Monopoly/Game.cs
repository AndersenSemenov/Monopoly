using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Monopoly
{
    class Game
    {
        public static List<Player> players = new List<Player>();

        public static Field[] fields = new Field[40];
        
        public void Play(string first, string second)
        {
            players.Add(new Player(first));
            players.Add(new Player(second));
            CreateFields();
            int Count = players.Count;
            int Turn = 1;
            while (Count > 1)
            {
                Console.WriteLine($"Circle {Turn}");
                players[0].PrintData();
                players[1].PrintData();
                foreach (var player in players)
                {
                    if (!player.IsLost)
                    {
                        player.Move();
                    }    
                }
                //Thread.Sleep(6000);
                Console.Clear();
                foreach (var player in players)
                {
                    if (player.IsLost)
                    {
                        Count--;
                    }
                    player.numberOfDubles = 0;
                }
                Turn++;
            }
            foreach (var player in players)
            {
                if (!player.IsLost)
                {
                    Console.WriteLine($"{player.Name} won on Circle number {Turn}!");
                }
            }
        }

        public void CreateFields()
        {
            Company.Create();
            Chance.Create();
            TaxeField.Create();
        }
    }
}
