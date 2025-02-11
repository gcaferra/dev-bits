
namespace Tennis.UnitTests
{
    public class TennisGameTests
    {
        [Test]
        public async Task player1_Score_a_Point()
        {
            // Arrange
            var sut = new TennisGame("player1Name", "player2Name");

            // Act
            sut.WonPoint("player1Name");
            // Assert
            await Assert.That(sut.GetScore()).IsEqualTo("Fifteen-Love");
        }     
        
        [Test]
        public async Task player2_score_a_Point()
        {
            // Arrange
            var sut = new TennisGame("player1Name", "player2Name");

            // Act
            sut.WonPoint("player2Name");
            // Assert
            await Assert.That(sut.GetScore()).IsEqualTo("Love-Fifteen");
        }
    }
}