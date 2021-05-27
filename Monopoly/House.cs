using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly
{
    class House : Decorator
    {
        public override int Rent { get => company.Rent * 2; }
        public override int Level { get => company.Level + 1; }
        public House(Super company) : base(company)
        {
            this.company = company;
        }

        public override void Action(Player player)
        {
            if (this.Owner != player)
            {
                player.PayRent(this);
            }
            else
            {
                Console.WriteLine("YOU ARE THE OWNER");
            }
        }

        public override void Sell(Player player)
        {
            Console.WriteLine($"{player.Name} sold a house");
            player.Recieve(company.HouseCost);

            // House -> House || Monopoly
            Game.cells[this.Position] = company;
        }
    }
}
