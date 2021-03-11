using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace Monopoly
{
    class TaxeField: Field
    {
        public int AmountOfTax { get; set; }

        public static void Create()
        {
            using (StreamReader sr = new StreamReader("D:/С#/Monopoly/TaxeFields.txt"))
            {
                string s = sr.ReadLine();
                while (s != null)
                {
                    TaxeField taxeField = JsonSerializer.Deserialize<TaxeField>(s);
                    Game.fields[taxeField.Position] = taxeField;
                    s = sr.ReadLine();
                }
            }
        }
    }
}
