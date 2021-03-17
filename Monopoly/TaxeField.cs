using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace Monopoly
{
    class TaxeField: Cell
    {
        public int AmountOfTax { get; set; }

        public override void Action(Player player)
        {
            player.Pay(this.AmountOfTax);
        }

        public static void Create()
        {
            using (StreamReader sr = new StreamReader("D:/С#/Monopoly/TaxeFields.txt"))
            {
                string s = sr.ReadLine();
                while (s != null)
                {
                    TaxeField taxeField = JsonSerializer.Deserialize<TaxeField>(s);
                    Game.cells[taxeField.Position] = taxeField;
                    s = sr.ReadLine();
                }
            }
        }
    }
}
