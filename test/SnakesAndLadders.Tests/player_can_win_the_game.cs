namespace SnakesAndLadders.Tests
{
    using FluentAssertions;
    using NSubstitute;
    using Xunit;

    public class player_can_win_the_game
    {
        private readonly IDie _die;

        public player_can_win_the_game()
        {
            _die = Substitute.For<IDie>();
        }

        [Fact]
        public void when_token_is_on_square_97_and_is_moved_3_spaces_then_the_player_should_won_the_game()
        {
            _die.Roll().Returns(96, 3);

            var game = Game.Create(_die);

            game.Move();
            game.Move();

            game.IsWin.Should().BeTrue();
            game.Square.Should().Be(100);
        }

        [Fact]
        public void when_token_is_on_square_97_and_is_moved_4_spaces_then_the_player_should_not_won_the_game()
        {
            _die.Roll().Returns(96, 4);

            var game = Game.Create(_die);

            game.Move();
            game.Move();

            game.IsWin.Should().BeFalse();
            game.Square.Should().Be(97);
        }

        [Fact]
        public void when_token_is_on_square_99_and_is_moved_3_spaces_then_the_player_should_does_not_move()
        {
            _die.Roll().Returns(98, 3);

            var game = Game.Create(_die);

            game.Move();
            game.Move();

            game.Square.Should().Be(99);
            game.IsWin.Should().BeFalse();
        }
    }
}
