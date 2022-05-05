namespace SnakesAndLadders.Tests
{
    using FluentAssertions;
    using NSubstitute;
    using Xunit;

    public class token_can_move_across_the_board
    {
        private readonly IDie _die;

        public token_can_move_across_the_board()
        {
            _die = Substitute.For<IDie>();
        }

        [Fact]
        public void when_the_token_is_placed_on_the_board_then_the_token_should_is_on_square_1()
        {
            var game = Game.Create(_die);

            game.Square.Should().Be(1);
        }

        [Fact]
        public void when_token_is_moved_three_spaces_then_the_token_should_is_on_square_4()
        {
            _die.Roll().Returns(3);

            var game = Game.Create(_die);

            game.Move();

            game.Square.Should().Be(4);
        }

        [Fact]
        public void when_token_is_moved_three_spaces_and_then_is_moved_four_spaces_then_the_token_should_is_on_square_8()
        {
            _die.Roll().Returns(3, 4);

            var game = Game.Create(_die);

            game.Move();
            game.Move();

            game.Square.Should().Be(8);
        }
    }
}
