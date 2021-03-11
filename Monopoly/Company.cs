using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace Monopoly
{
    class Company : Field
    {
        public int Cost { get; set; } 
        public int Rent { get; set; }
        public bool IsBought { get; set; }
        public Player Owner { get; set; }

        public override void Action(Player player)
        {
            if (this.IsBought && this.Owner != player)
            {
                player.PayRent(this);
            }
            else if (!this.IsBought && player.Money >= this.Cost)
            {
                this.BuyCompany(player);
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
            player.Minus(this.Cost);
            Console.WriteLine();
            this.Owner = player;
            this.IsBought = true;
            player.Property.Add(this);
        }

        public void SellCompany(Player player)
        {
            Console.WriteLine($"{player.Name} sold a company {this.Name}");
            player.Plus(Cost);
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
                    Game.fields[company.Position] = company;
                    s = sr.ReadLine();
                }
            }
        }
    }
}
