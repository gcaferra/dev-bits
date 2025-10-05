using static CSharpBits.NumbersInWords.NumToWord; 

namespace CSharpBits.NumbersInWords
{
  public class NumberInWordsTest
  {
    [Fact]
    public void single_number_is_transformed_in_word()
    {
      var actual = ToWord(1);
      
      Assert.Equal("one", actual);
    }
    
    [Fact]
    public void twelve_is_transformed_in_words()
    {
      var actual = ToWord(12);
      
      Assert.Equal("twelve", actual);
    }

    [Fact]
    public void all_dozens_are_transformed_in_words()
    {
      var actual = new List<string>();
      var expected = new List<string>()
      {
        "ten",
        "twenty",
        "thirty",
        "forty",
        "fifty",
        "sixty",
        "seventy",
        "eighty",
        "ninety"
      };      
      var dozens = Enumerable.Range(10, 90).Where(x => x % 10 == 0).ToList();

      dozens.ForEach(d=> actual.Add(ToWord(d)));
      
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void number_51_is_parsed_correctly_in_words()
    {
      var actual = ToWord(51);
      
      Assert.Equal("fifty one", actual);
    }
    
    [Fact]
    public void number_132_is_parsed_correctly_in_words()
    {
      var actual = ToWord(132);
      
      Assert.Equal("one hundred thirty two", actual);
    }
    
    [Fact]
    public void number_999_is_parsed_correctly_in_words()
    {
      var actual = ToWord(999);
      
      Assert.Equal("nine hundred ninety nine", actual);
    }
  }
}