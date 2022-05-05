
namespace SnakesAndLadders
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Snakes And Ladders");

            var game = Game.Create(new Die(new DefaultRandom()));

            while (!game.IsWin)
            {
                Console.WriteLine("Roll a die!");

                Console.ReadLine();

                var origin = game.Square;

                game.Move();

                var target = game.Square;

                Console.WriteLine($"From {origin} to {target} square");
            }
        }
    }
}
