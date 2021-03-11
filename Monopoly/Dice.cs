using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly
{
    class Dice
    {
        public static int RollADice()
        {
            Random random = new Random();
            int dice = random.Next(1, 7);
            return dice;
        }

        public static Field RollTwoDices(Player player)
        {
            int dice1 = RollADice();
            int dice2 = RollADice();
            int dicesSum = dice1 + dice2;
            int position = (player.CurrentPosition + dicesSum) % 40;
            if (dice1 == dice2)
            {
                player.numberOfDubles++; // реализовать нормально
            }
            Console.WriteLine($"{player.Name} rolling dices...");
            Console.WriteLine($"Dice1: {dice1}, dice2: {dice2}");
            if (player.CurrentPosition + dicesSum == 40)
            {
                Console.WriteLine($"{player.Name} прошел круг");
                player.Plus(1000);
            }
            else if (player.CurrentPosition + dicesSum > 40)
            {
                Console.WriteLine($"{player.Name} прошел круг");
                player.Plus(500);
            }
            Console.WriteLine($"{player.Name} got into position {position}, field {Game.fields[position].Name}");
            player.CurrentPosition = position;
            return Game.fields[position];
        }
    }
}
