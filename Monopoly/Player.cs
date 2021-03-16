using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly
{
    class Player
    {
        public string Name { get; private set; }
        public int CurrentPosition { get; set; }
        public int BlockMovement { get; set; } // 3 хода в тюрьме иначе платить 500
        public int Money { get; set; }
        public bool IsLost { get; set; }
        public bool IsJailed { get; set; }
        //public int numberOfDoubles { get; set; } 
        public List<Company> Property = new List<Company>();

        public Player(string name)
        {
            Name = name;
            CurrentPosition = 0;
            Money = 8000;
            BlockMovement = 0;
            IsLost = false;
            IsJailed = false;
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
            if (Prison.jailed.Contains(this)) 
            {
                Game.fields[0].Action(this); // норм ячейка
            }
            else if (this.BlockMovement != 0)
            {
                this.BlockMovement--;
            }
            else
            {
                Tuple<int, int> dice = Die.RollTwoDice();
                this.MoveOnBoard(dice.Item1, dice.Item2);
            }
        }

        public void MoveOnBoard(int dice1, int dice2)
        {
            int diceSum = dice1 + dice2;
            int position = (this.CurrentPosition + diceSum) % 40;
            Console.WriteLine($"{this.Name} rolling dices...");
            Console.WriteLine($"Dice1: {dice1}, dice2: {dice2}");
            if (this.CurrentPosition + diceSum > 40)
            {
                Console.WriteLine($"{this.Name} прошел круг");
                this.Plus(500);
            }
            Console.WriteLine($"{this.Name} got into position {position}, field {Game.fields[position].Name}");
            this.CurrentPosition = position;
            Game.fields[this.CurrentPosition].Action(this);
        }

        public void PayRent(Company company)
        {
            this.Minus(company.Rent);
            Console.WriteLine($"{this.Name} paid a rent {company.Rent}");
            company.Owner.Plus(company.Rent);
            Console.WriteLine();
        }

        public void Minus(int value) //
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
        public void Plus(int value) //
        {
            this.Money += value;
            Console.WriteLine($"{this.Name} has {this.Money} dollars");
        }
    }
}