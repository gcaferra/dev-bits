namespace CSharpBits.TennisRefactoring.Tennis
{
    public interface ITennisGame
    {
        void WonPoint(string playerName);
        string GetScore();

    }
}