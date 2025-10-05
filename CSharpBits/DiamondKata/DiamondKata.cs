namespace CSharpBits.DiamondKata;

public class DiamondKata
{
    private DiamondPrinter _diamondPrinter = new DiamondPrinter();

    [Fact]
    void A_Case()
    {
        var result = _diamondPrinter.Print("A");
        Assert.Equal(["A"], result);
    }

    [Fact]
    void B_Case()
    {
        List<string> expected = [
                            " A ", 
                            "B B", 
                            " A "];
        
        var result = _diamondPrinter.Print("B");
        
        Assert.Equal(expected, result);
    }

    [Fact]
    void C_Case()
    {
        List<string> expected = [
                            "  A  ", 
                            " B B ", 
                            "C   C", 
                            " B B ",
                            "  A  "];
        
        var result = _diamondPrinter.Print("C");
        
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 3, "   A   ")]
    [InlineData(1, 3, "  B B  ")]
    [InlineData(2, 3, " C   C ")]
    [InlineData(3, 3, "D     D")]
    // [InlineData(4, 3, " C   C ")]
    // [InlineData(5, 3, "  B B  ")]
    // [InlineData(6, 3, "   A   ")]
    void BuildRow(int rowNumber, int target, string expected)
    {
        var result = _diamondPrinter.BuildRow(rowNumber, target);
        Assert.Equal(expected, result);
    }

}

public class DiamondPrinter
{
    private readonly List<string> _alphabet = ["A", "B", "C", "D"];
    
    public string[] Print(string character)
    {
        var index = GetIndex(character);

        List<string> result = new List<string>();
        int rowNumber = 0;
        for (; rowNumber <= index; rowNumber++)
        {
            result.Add(BuildRow(rowNumber, (int)index));
        }

        rowNumber-=2;
        
        for (; rowNumber >= 0; rowNumber--)
        {
            result.Add(BuildRow(rowNumber, (int)index));
        }
        
        return  result.ToArray();
    }

    internal string BuildRow(int rowNumber, int target)
    {
        if (rowNumber == 0)
        {
            var spaces = new string(' ', target - rowNumber);

            return $"{spaces}{_alphabet[rowNumber]}{spaces}";
        }

        var sideSpaceN = target - rowNumber;
        var sideSpaces = new string(' ', Math.Abs(sideSpaceN));
        var rowSize = target * 2 + 1;
        var innerSpaces =  new string(' ',  rowSize - (Math.Abs(sideSpaceN) * 2) - 2);
        
        return $"{sideSpaces}{_alphabet[rowNumber]}{innerSpaces}{_alphabet[rowNumber]}{sideSpaces}";
    }

    private uint GetIndex(string character)
    {
        return (uint) _alphabet.IndexOf(character);
    }
}