using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly
{
    class Player
    {
        public string Name { get; private set; }
        public int CurrentPosition { get; set; }
        public bool BlockMovement { get; set; }
        public int Money { get; set; }
        public bool IsLost { get; set; }
        public List<Company> Property = new List<Company>();

        public Player(string name)
        {
            Name = name;
            CurrentPosition = 0;
            Money = 8000;
            BlockMovement = false;
            IsLost = false;
        }

        public void Move()
        {
            this.CurrentPosition = RollADice();
            Field CurrentField = Game.fields[CurrentPosition];
            //Cell.DoAction();
            if (CurrentField as Company != null) //Cell, метод move(Player player), этого ifa нет
            {
                
                Company company = CurrentField as Company;
                if (company.IsBought && company.Owner != this)
                {
                    this.PayRent(company);
                }
                else if (!company.IsBought && this.Money >= company.Cost)
                {
                    company.BuyCompany(this);
                }
                else
                {
                    Console.WriteLine($"{this.Name} did nothing");
                    Console.WriteLine();
                }
            }
            else if (CurrentField as Chance != null)
            {
                Chance.GetChance(this);
            }
            else if (CurrentField as TaxeField != null)
            {
                this.PayTaxes(CurrentField as TaxeField);
                //TaxeField.PayTaxes(this);
            }
        }

        public int RollADice() //отдельный класс
        {
            Random random = new Random();
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);
            int diceSum = dice1 + dice2;
            int position = (CurrentPosition + diceSum) % 40;
            Console.WriteLine($"{this.Name} rolling dices...");
            Console.WriteLine($"Dice1: {dice1}, dice2: {dice2}");
            Console.WriteLine($"{this.Name} got into position {position}, field {Game.fields[position].Name}");
            if (CurrentPosition + diceSum == 40)
            {
                Console.WriteLine($"{this.Name} прошел круг");
                this.Plus(1000);
            }
            else if (CurrentPosition + diceSum > 40)
            {
                Console.WriteLine($"{this.Name} прошел круг");
                this.Plus(500);
            }
            return position;
        }


        public void PrintData()
        {
            Console.WriteLine($"{this.Name} has {this.Money} dollars and located in position {this.CurrentPosition}");
            Console.WriteLine($"Property of {this.Name}:");
            foreach (var property in Property)
            {
                Console.WriteLine($"{property.Name}");
            }
            Console.WriteLine();
        }

        public void PayRent(Company company)  // связать с Minus
        {
            //while (this.Money - company.Rent < 0 && this.Property.Count != 0)
            //{
            //    Property[0].SellCompany(this);
            //}
            //if (this.Money - company.Rent < 0)
            //{
            //    this.IsLost = true;
            //}
            //else
            //{
            this.Minus(company.Rent);
            Console.WriteLine($"{this.Name} paid a rent {company.Rent}");
            company.Owner.Plus(company.Rent);
        }

        public void PayTaxes(TaxeField taxeField)
        {
            this.Minus(taxeField.AmountOfTax);
        }

        public void Minus(int value)
        {
            while (this.Money - value < 0 && this.Property.Count != 0)
            {
                Property[0].SellCompany(this);
            }
            if (this.Money - value < 0)
            {
                this.IsLost = true;
            }
            else
            {
                //Console.WriteLine($"{this.Name} paid {company.Rent}");
                this.Money -= value;
            }
        }
        public void Plus(int value)
        {
            this.Money += value;
            Console.WriteLine($"{this.Name} has {this.Money} dollars");
            Console.WriteLine();
        }
    }
}