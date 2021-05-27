using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly
{
    class Decorator: Super
    {
        protected Super company;
        public Decorator(Super company)
        {
            this.company = company;
            this.Color = company.Color;
            this.Cost = company.Cost;
            this.IsBought = company.IsBought;
            this.Owner = company.Owner;
            this.HouseCost = company.HouseCost;
            this.Position = company.Position;
            this.Name = company.Name;
        }


        public override int Rent { get => company.Rent; set => company.Rent = value; }

        public override int Level => company.Level;

        public override void Action(Player player)
        {
            company.Action(player);
        }

        public override void Sell(Player player)
        {
            company.Sell(player);
        }
    }
}
