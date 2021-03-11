using System;


namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        { 
            // json text c#,system.text.json

            Game game = new Game();
            game.Play("first", "second");
            //Console.WriteLine("Hello World!");
        }
    }
}
