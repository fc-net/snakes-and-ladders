
namespace SnakesAndLadders
{
    using System;

    public sealed class DefaultRandom : IRandom
    {
        private readonly Random _random = new Random();

        public int Next(int minValue, int maxValue) => _random.Next(minValue, maxValue);
    }

    public interface IRandom
    {
        int Next(int minValue, int maxValue);
    }
}
