namespace CSharpBits.DiamondKata;

public class DiamondKataPbtTest
{
    //generators
    private static char[] _charArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    private static string[][] _diamonds = _charArray.Select(DiamondKataPbt.PrintLetter).ToArray(); 
    
    [Fact]
    void Produce_a_square()
    {
        _diamonds.AlwaysTrue(d => d.IsSquare());
    }

    [Fact]
    void Print_all_letter_from_a_to_target()
    {
        _diamonds.AlwaysTrue(d => d.IsSquare());
    }
    
}

internal class DiamondKataPbt
{
    public static string[] PrintLetter(char letter)
    {
        return [];
    }
}

internal static class DiamondKataExtensions
{
    internal static void AlwaysTrue<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        Assert.True(collection.All(predicate));
    }
    
    internal static bool IsSquare(this string[] diamond)
    {
        var numberOfRows = diamond.Length;
        return diamond.All(x => x.Length == numberOfRows);
    }
}