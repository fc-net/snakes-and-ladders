
namespace SnakesAndLadders
{
    using System;

    public sealed class Game
    {
        private const int START_SQUARE = 1;
        private const int MAX_SQUARE = 100;

        private readonly IDie _die;

        private int _square = START_SQUARE;

        public int Square => _square;
        public bool IsWin => _square == MAX_SQUARE;

        private Game(IDie die)
        {
            _die = die ?? throw new ArgumentNullException(nameof(die));
        }

        public static Game Create(IDie die) => new Game(die);

        public void Move()
        {
            var number = _die.Roll();

            if (_square + number <= MAX_SQUARE)
            {
                _square += number;
            }
        }
    }
}
