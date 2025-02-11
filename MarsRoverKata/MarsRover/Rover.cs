using MarsRover.Enums;
using MarsRover.Mover;

namespace MarsRover
{
    public class Rover
    {
        public Rover(Point position)
        {
            Position = position;
            Mover = new SouthMover();
        }

        public Point Position { get; private set; }

        public void Move(string[] commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case Directions.West:
                        Mover = new WestMover();
                        break;
                    case Directions.North:
                        Mover = new NorthMover();
                        break;
                    case Directions.East:
                        Mover = new EstMover();
                        break;
                    case Directions.South:
                        Mover = new SouthMover();
                        break;
                    default:
                        Position = Mover.Move(command, Position);
                        break;
                }
            }
        }

        public IMover Mover { get; private set; }
    }

    public record Point(int X, int Y);
}