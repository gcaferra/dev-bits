using System.Text;

namespace CSharpBits.GameOfLife
{
  public class GameOfLife
  {
    private readonly List<List<Cell>> _grid;

    public GameOfLife(List<List<Cell>> grid)
    {
      _grid = grid;
    }

    public bool IsAlive(int x, int y)
    {
      return IsInGrid(x, y) && _grid[x][y].IsAlive;
    }

    private bool IsInGrid(int x, int y)
    {
      if (!_grid.Any())
        return false;

      if (x < 0 || y < 0)
        return false;

      if (x >= _grid.Count)
        return false;

      if (y >= _grid[0].Count)
        return false;

      return true;
    }

    public Cell EvolveCell(int x, int y)
    {
      var range = new List<Cell>
      {
        new Cell(IsAlive(x - 1, y - 1)),
        new Cell(IsAlive(x - 1, y)),
        new Cell(IsAlive(x - 1, y + 1)),
        new Cell(IsAlive(x, y - 1)),
        new Cell(IsAlive(x, y + 1)),
        new Cell(IsAlive(x + 1, y - 1)),
        new Cell(IsAlive(x + 1, y)),
        new Cell(IsAlive(x + 1, y + 1)),
      };
      var cell = new Cell(_grid[x][y].IsAlive);

      if (cell.IsAlive)
      {
        if (LiveCellWithTwoLiveNeighboursDie(range))
          cell.IsAlive = false;
        else
        {
          if (LiveCellWithMoreThanThreeLiveNeighboursDies(range))
            cell.IsAlive = false;

          if (LiveCellWithTwoOrThreeLiveNeighboursSurvive(range))
            cell.IsAlive = true;
        }
      }
      else
      {
        if (DeadCellWithThreeNeighboursLives(range))
          cell.IsAlive = true;
      }

      return cell;
    }

    private static bool DeadCellWithThreeNeighboursLives(List<Cell> range)
    {
      return range.Count(c => c.IsAlive) == 3;
    }

    private static bool LiveCellWithTwoOrThreeLiveNeighboursSurvive(List<Cell> range)
    {
      return range.Count(c => c.IsAlive) == 2 || range.Count(c => c.IsAlive) == 3;
    }

    private static bool LiveCellWithMoreThanThreeLiveNeighboursDies(List<Cell> range)
    {
      return range.Count(c => c.IsAlive) > 3;
    }

    private static bool LiveCellWithTwoLiveNeighboursDie(List<Cell> range)
    {
      return range.Count(c => c.IsAlive) < 2;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      foreach (var row in _grid)
      {
        foreach (var cell in row)
        {
          sb.Append(cell.IsAlive ? "*" : ".");
        }

        sb.AppendLine();
      }

      sb.Length -= 2;

      return sb.ToString();
    }

    public GameOfLife NewGeneration()
    {
      var newGen = new List<List<Cell>>();
      for(int x = 0; x < _grid.Count ; x++)
      {
        var row = new List<Cell>();
        newGen.Add(row);
        for (int y = 0; y < _grid[x].Count; y++)
        {
          row.Add(EvolveCell(x, y));
        }
      }

      return new GameOfLife(newGen);
    }
  }
}