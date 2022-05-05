namespace SnakesAndLadders.Tests
{
    using FluentAssertions;
    using NSubstitute;
    using System;
    using Xunit;
    using static FluentAssertions.FluentActions;

    public class moves_are_determined_by_dice_rolls
    {
        [Fact]
        // I think it is the same test as "when_token_is_moved_three_spaces_then_the_token_should_is_on_square_4"
        public void when_player_rolls_a_4_then_the_token_should_move_4_spaces()
        {
            var die = Substitute.For<IDie>();
            die.Roll().Returns(51, 4);

            var game = Game.Create(die);
            game.Move();
            var origin = game.Square;


            game.Move();
            var spaces = game.Square - origin;

            spaces.Should().Be(4);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void when_player_rolls_a_die_then_the_result_should_be_between_1_and_6(int number)
        {
            var die = GetDie(number);

            Func<int> roll = () => die.Roll();

            roll.Invoke().Should().Be(number);
            Invoking(() => roll.Should().NotThrow());

        }

        [Theory]
        [InlineData(0)]
        [InlineData(7)]
        public void when_player_rolls_a_die_then_the_result_should_be_a_valid_value(int number)
        {
            var die = GetDie(number);

            Invoking(() => die.Roll())
                .Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage("Result is out of range (Parameter 'result')");
        }

        private static Die GetDie(int number)
        {
            var random = Substitute.For<IRandom>();

            random.Next(Arg.Any<int>(), Arg.Any<int>()).Returns(number);

            return new Die(random);
        }
    }
}
