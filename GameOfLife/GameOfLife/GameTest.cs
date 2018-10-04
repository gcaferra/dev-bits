using Xunit;

namespace GameOfLifePOC
{
  public class GameOfLifeTest
  {
    [Fact]
    public void generate_two_dimensional_grid()
    { 
      var sut = new GameOfLife(GameLoader.LoadInputToGrid(@"........
....*...
...**...
........"));

      Assert.False(sut.IsAlive(3,7));
    }

    [Fact]
    public void a_cell_can_be_Alive()
    {
      var cell = new Cell(true);
      
      Assert.True(cell.IsAlive);
    }
    
    [Fact]
    public void a_cell_can_be_Died()
    {
      var cell = new Cell(false);
      
      Assert.False(cell.IsAlive);
    }

    [Fact]
    public void a_cell_marked_with_star_is_Alive()
    {
      var game = new GameOfLife(GameLoader.LoadInputToGrid("*"));
      
      Assert.True(game.IsAlive(0,0)); 
    }
    
    [Fact]
    public void a_cell_marked_with_star_is_Died()
    {
      var game = new GameOfLife(GameLoader.LoadInputToGrid("."));
      
      Assert.False(game.IsAlive(0,0)); 
    }

  
    [Fact]
    public void a_live_cell_should_die_if_less_than_2_neighbours_are_alive()
    {
      var game = new GameOfLife(GameLoader.LoadInputToGrid(".*....\r\n" +
                                                           ".*....\r\n" +
                                                           "......\r\n"));
      var actual = game.EvolveCell(0, 1);

      Assert.False(actual.IsAlive);
    }
    
    [Fact]
    public void the_cell_should_die_if_more_than_3_neighbours_are_alive()
    {
      var game = new GameOfLife(GameLoader.LoadInputToGrid(".*....\r\n" +
                                                           ".**...\r\n" +
                                                           ".**...\r\n"));
      var result = game.EvolveCell(1, 1);

      Assert.False(result.IsAlive);
    }

    [Fact]
    public void a_live_cell_with_two_or_three_live_neighbours_lives()
    {
      var game = new GameOfLife(GameLoader.LoadInputToGrid(".*....\r\n" +
                                                           ".*...\r\n" +
                                                           ".*....\r\n"));
      game.EvolveCell(1, 1);

      Assert.True(game.IsAlive(1,1));
    }

    [Fact]
    public void a_dead_cell_with_three_live_neighbours_becomes_live()
    {
      var game = new GameOfLife(GameLoader.LoadInputToGrid(".*....\r\n" +
                                                           ".**..\r\n" +
                                                           ".*....\r\n"));
      game.EvolveCell(1, 1);

      Assert.True(game.IsAlive(1,1));
    }

    [Fact]
    public void the_new_generation_is_calculated()
    {
      var expected = "........\r\n" +
                     "...**...\r\n" +
                     "...**...\r\n" +
                     "........";
      
      var game = new GameOfLife(GameLoader.LoadInputToGrid("........\r\n" +
                                                           "....*...\r\n" +
                                                           "...**...\r\n" +
                                                           "........"));

      var actual = game.NewGeneration();
            
      Assert.Equal(expected, actual.ToString());
    } 
  }
}