using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly
{
    class Monopoly: Decorator
    {
        public override int Rent { get => company.Rent * 2; } 
        public override int Level { get => company.Level + 1; }
        public Monopoly(Super company) : base(company)
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
            //base.Sell(player);
            Console.WriteLine($"{player.Name} sold a company {this.Name}");
            player.Recieve(Cost);
            IsBought = false;
            Owner = null;
            var index = player.Property.BinarySearch(this.Position);
            player.Property.RemoveAt(index);

            // Monopoly -> Company
            Game.cells[this.Position] = company;
        }

        //public Super Destroy()
        //{
        //    return company;
        //}
    }
}
