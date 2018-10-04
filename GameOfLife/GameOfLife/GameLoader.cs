using System.Collections.Generic;
using System.Linq;

namespace GameOfLifePOC
{
  public static class GameLoader
  {
    public static List<List<Cell>> LoadInputToGrid(string inputBoard)
    {
      var lines = inputBoard.Split("\r\n");

      return lines.Select(ParseToCells).ToList();
    }

    private static List<Cell> ParseToCells(string line)
    {
      return line.ToCharArray().Select(c => new Cell(CellIsAlive(c))).ToList();
    }

    private static bool CellIsAlive(char c)
    {
      return c == '*';
    }
  }
}