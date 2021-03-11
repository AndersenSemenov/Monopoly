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
        public int numberOfDubles { get; set; }
        public List<Company> Property = new List<Company>();

        public Player(string name)
        {
            Name = name;
            CurrentPosition = 0;
            Money = 8000;
            BlockMovement = false;
            IsLost = false;
            numberOfDubles = 0;
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

        public void Move()
        {
            Field CurrentField = Dice.RollTwoDices(this);
            CurrentField.Action(this);
        }

        public void PayRent(Company company)
        {
            this.Minus(company.Rent);
            Console.WriteLine($"{this.Name} paid a rent {company.Rent}");
            company.Owner.Plus(company.Rent);
            Console.WriteLine();
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
                this.Money -= value;
                Console.WriteLine($"{this.Name} has {this.Money} dollars");
            }
        }
        public void Plus(int value)
        {
            this.Money += value;
            Console.WriteLine($"{this.Name} has {this.Money} dollars");
        }
    }
}