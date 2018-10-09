using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NumbersInWords
{
  public class NumberInWordsTest
  {
    [Fact]
    public void single_number_is_transformed_in_word()
    {
      var sut = new NumToWord();

      var actual = sut.ToWord(1);
      
      Assert.Equal("one", actual);
    }
    
    [Fact]
    public void twelve_is_transformed_in_words()
    {
      var sut = new NumToWord();

      var actual = sut.ToWord(12);
      
      Assert.Equal("twelve", actual);
    }

    [Fact]
    public void all_dozens_are_transformed_in_words()
    {
      var sut = new NumToWord();
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
        "ninety",
        "one hundred"
      };      
      var dozens = Enumerable.Range(10, 100).Where(x => x % 10 == 0).ToList();

      dozens.ForEach(d=> actual.Add(sut.ToWord(d)));
      
      Assert.Equal(expected, actual);
    }
  }

  public class NumToWord
  {
    readonly Dictionary<int,string> _numberMap = new Dictionary<int, string>()
    {
      {1, "one"},
      {2, "two"},
      {3, "three"},
      {4, "four"},
      {5, "five"},
      {6, "six"},
      {7, "seven"},
      {8, "eight"},
      {9, "nine"},
      {10, "ten"},
      {11, "eleven"},
      {12, "twelve"},
      {13, "thirteen"},
      {14, "fourteen"},
      {15, "fifteen"},
      {16, "sixteen"},
      {17, "seventeen"},
      {18, "eighteen"},
      {19, "nineteen"},
      {20, "twenty"},
      {30, "thirty"},
      {40, "forty"},
      {50, "fifty"},
      {60, "sixty"},
      {70, "seventy"},
      {80, "eighty"},
      {90, "ninety"},
      {100, "one hundred"},
    };
    
    public string ToWord(int number) => _numberMap[number];
  }
}