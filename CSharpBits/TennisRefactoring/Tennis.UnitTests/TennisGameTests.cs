
using Shouldly;

namespace CSharpBits.TennisRefactoring.Tennis.UnitTests
{
    public class TennisGameTests
    {
        [Fact]
        public void player1_Score_a_Point()
        {
            // Arrange
            var sut = new TennisGame("player1Name", "player2Name");

            // Act
            sut.WonPoint("player1Name");
            // Assert
             sut.GetScore().ShouldBe("Fifteen-Love");
        }     
        
        [Fact]
        public async Task player2_score_a_Point()
        {
            // Arrange
            var sut = new TennisGame("player1Name", "player2Name");

            // Act
            sut.WonPoint("player2Name");
            // Assert
           sut.GetScore().ShouldBe("Love-Fifteen");
        }
    }
}