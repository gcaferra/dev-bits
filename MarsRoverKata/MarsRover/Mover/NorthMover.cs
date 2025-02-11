namespace MarsRover.Mover
{
    public class NorthMover : IMover
    {
        public Point Move(string command, Point position)
        {
            return command switch
            {
                "f" => new Point(position.X - 1, position.Y),
                "b" => new Point(position.X + 1, position.Y),
                "l" => new Point(position.X, position.Y - 1),
                "r" => new Point(position.X, position.Y + 1),
                _ => position
            };
        }
    }
}