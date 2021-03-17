using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly
{
    class Player
    {
        public string Name { get; private set; }
        public int CurrentPosition { get; set; }
        public int BlockMovement { get; set; }
        public int Money { get; set; }
        public bool IsLost { get; set; }
        public List<Company> Property = new List<Company>();

        public Player(string name)
        {
            Name = name;
            CurrentPosition = 0;
            Money = 8000;
            BlockMovement = 0;
            IsLost = false;
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
                Game.cells[10].Action(this);
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
                Console.WriteLine($"{this.Name} passed the circle");
                this.Recieve(500);
            }
            Console.WriteLine($"{this.Name} got into position {position}, cell {Game.cells[position].Name}");
            this.CurrentPosition = position;
            Game.cells[this.CurrentPosition].Action(this);
        }

        public void PayRent(Company company)
        {
            this.Pay(company.Rent);
            Console.WriteLine($"{this.Name} paid a rent {company.Rent}");
            company.Owner.Recieve(company.Rent);
            Console.WriteLine();
        }

        public void Pay(int value)
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
        public void Recieve(int value)
        {
            this.Money += value;
            Console.WriteLine($"{this.Name} has {this.Money} dollars");
        }
    }
}