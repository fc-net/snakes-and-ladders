
namespace SnakesAndLadders
{
    using System;

    public sealed class Die : IDie
    {
        private const int MAX_DIE_VALUE = 6;
        private const int MIN_DIE_VALUE = 1;

        private readonly IRandom _random;

        public Die(IRandom random)
        {
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public int Roll()
        {
            var result = _random.Next(MIN_DIE_VALUE, MAX_DIE_VALUE + 1);

            if (result < MIN_DIE_VALUE || result > MAX_DIE_VALUE)
            {
                throw new ArgumentOutOfRangeException(nameof(result), "Result is out of range");
            }

            return result;
        }
    }

    public interface IDie
    {
        int Roll();
    }
}
