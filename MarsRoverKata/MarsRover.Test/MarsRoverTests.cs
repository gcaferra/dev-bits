using MarsRover.Enums;
using MarsRover.Mover;
using NUnit.Framework;
using Shouldly;

namespace MarsRover.Test
{
    public class MarsRoverTests
    {
        [Test]
        public void The_rover_accept_a_starting_Point()
        {
            var point = new Point(0, 0);
            var sut = new Rover(point);

            sut.Position.ShouldBeEquivalentTo(point);
        }

        [Test]
        public void Point_contains_X_and_Y()
        {
            var point = new Point(1, 2);

            var sut = new Rover(point);

            sut.Position.X.ShouldBe(1);
            sut.Position.Y.ShouldBe(2);
        }

        [Test]
        public void Rover_can_move_forward()
        {
            var point = new Point(1, 1);

            var sut = new Rover(point);

            sut.Move(new[] {"f", "f"});

            sut.Position.X.ShouldBe(3);
        }

        [Test]
        public void Rover_can_move_backward()
        {
            var point = new Point(3, 3);

            var sut = new Rover(point);

            sut.Move(new[] {"b", "b"});

            sut.Position.X.ShouldBe(1);
        }

        [Test]
        public void the_Rover_can_move_on_Left()
        {
            var point = new Point(1, 3);

            var sut = new Rover(point);

            sut.Move(new[] {"l", "l"});

            sut.Position.Y.ShouldBe(5);
        }

        [Test]
        public void the_Rover_can_move_on_Right()
        {
            var point = new Point(1, 3);

            var sut = new Rover(point);

            sut.Move(new[] {"r", "r"});

            sut.Position.Y.ShouldBe(1);
        }

        [Test]
        public void Unknown_commands_are_ignored()
        {
            var point = new Point(1, 3);

            var sut = new Rover(point);

            sut.Move(new[] {"1", "e", "d", "q"});

            sut.Position.ShouldBeEquivalentTo(point);
        }

        [Test]
        public void several_commands_are_executed_in_sequence()
        {
            var point = new Point(2, 2);
            var expected = new Point(3, 1);

            var sut = new Rover(point);

            sut.Move(new[]
                {Commands.Forward, Commands.Forward, Commands.Right, Commands.Right, Commands.Left, Commands.Backward});

            sut.Position.ShouldBeEquivalentTo(expected);
        }
        
        [Test]
        public void the_direction_can_change()
        {
            var point = new Point(1, 1);
            string[] commands = {Commands.Forward, Commands.Right, Directions.West, Commands.Forward};

            var sut = new Rover(point);

            sut.Move(commands);

            sut.Mover.ShouldBeOfType<WestMover>();
        }

        [Test]
        public void changing_the_direction_also_change_the_command_direction()
        {
            var point = new Point(2, 2);
            var expected = new Point(3, 1);
            string[] commands = {Commands.Forward, Directions.West, Commands.Forward};

            var sut = new Rover(point);

            sut.Move(commands);

            sut.Position.ShouldBeEquivalentTo(expected);
        }
    }
}