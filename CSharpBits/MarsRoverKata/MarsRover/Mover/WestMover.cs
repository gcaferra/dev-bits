﻿namespace CSharpBits.MarsRoverKata.MarsRover.Mover
{
    public class WestMover : IMover
    {
        public Point Move(string command, Point position)
        {
            return command switch
            {
                "f" => new Point(position.X, position.Y - 1),
                "b" => new Point(position.X, position.Y + 1),
                "l" => new Point(position.X + 1, position.Y),
                "r" => new Point(position.X - 1, position.Y),
                _ => position
            };
        }
    }
}