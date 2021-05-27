using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace Monopoly
{
    class Company : Super 
    {
        private int _rent;
        public override int Rent { get => _rent; set => _rent = value; }

        public override int Level { get => 0; }

        public override void Action(Player player)
        {
            if (this.IsBought && this.Owner != player)
            {
                player.PayRent(this);
            }
            else if (!this.IsBought && player.Money >= this.Cost)
            {
                this.BuyCompany(player);
                if (MONOPOLYINFO.BelongToOneMonopoly(this.Color, player) && this.Color != null)
                {
                    MONOPOLYINFO.CreateMonopoly(this.Color);
                    player.MonopolyColors.Add(this.Color);
                    Console.WriteLine($"{player.Name} got a {this.Color} monopoly!".ToUpper());
                }
            }
            else
            {
                Console.WriteLine($"{player.Name} did nothing");
                Console.WriteLine();
            }
        }

        public void BuyCompany(Player player)
        {
            Console.WriteLine($"{player.Name} bought a company {this.Name}");
            player.Pay(this.Cost);
            Console.WriteLine();
            this.Owner = player;
            this.IsBought = true;
            player.Property.Add(this.Position);
        }

        public override void Sell(Player player)
        {
            Console.WriteLine($"{player.Name} sold a company {this.Name}");
            player.Recieve(Cost);
            IsBought = false;
            Owner = null;
            player.Property.RemoveAt(0);
        }

        public static void Create()
        {
            using (StreamReader sr = new StreamReader("D:/С#/Monopoly/Companies.txt"))
            {
                string s = sr.ReadLine();
                while (s != null)
                {
                    Company company = JsonSerializer.Deserialize<Company>(s);
                    Game.cells[company.Position] = company;
                    s = sr.ReadLine();
                }
            }
        }
    }
}
