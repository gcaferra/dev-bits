namespace MarsRover.Mover
{
    public interface IMover
    {
        Point Move(string command, Point position);
    }
}