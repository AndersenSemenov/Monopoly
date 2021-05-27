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

        public List<int> Property = new List<int>();
        public List<string> MonopolyColors = new List<string>();

        public Player(string name)
        {
            Name = name;
            CurrentPosition = 0;
            Money = 15000;
            BlockMovement = 0;
            IsLost = false;
        }

        public void PrintData()
        {
            Console.WriteLine($"{this.Name} has {this.Money} dollars and located in position {this.CurrentPosition}");
            Console.WriteLine($"Property of {this.Name}:");
            foreach (var index in Property)
            {
                Console.WriteLine($"{Game.cells[index].Name}");
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
                this.MonopolyMove();
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

        public void MonopolyMove()
        {
            foreach (var color in this.MonopolyColors)
            {
                List<int> indexes = MONOPOLYINFO.monopolies[color];
                int pos = -1, level = 12;
                foreach (var index in indexes)
                {
                    if ((Game.cells[index] as Super).Level < level)
                    {
                        pos = (Game.cells[index] as Super).Position;
                        level = (Game.cells[index] as Super).Level;
                    }
                }
                if (this.Money >= (Game.cells[pos] as Super).HouseCost && (Game.cells[pos] as Super).Level <= 5)
                {
                    Game.cells[pos] = new House((Super)Game.cells[pos]);
                    Console.WriteLine($"{this.Name} builded a house level {(Game.cells[pos] as Super).Level} on {(Game.cells[pos] as Super).Name}".ToUpper());
                    this.Pay((Game.cells[pos] as Super).HouseCost);
                }
                else
                {
                    break;
                }
            }
        }

        public void PayRent(Super super)
        {
            this.Pay(super.Rent);
            Console.WriteLine($"{this.Name} paid a rent {super.Rent}");
            super.Owner.Recieve(super.Rent);
            Console.WriteLine();
        }

        public void Pay(int value)
        {
            while (this.Money - value < 0 && this.Property.Count != 0)
            {
                Super super = Game.cells[this.Property[0]] as Super;
                if (this.Property.Count != 0)
                {
                    super.Sell(this);
                }
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