using System.Collections.Generic;
using Xunit;

namespace NumbersInWords
{
  public class NumberInWordsTest
  {
    [Fact]
    public void single_number_is_transformed_in_word()
    {
      var sut = new NumToWord();

      var actual = sut.ToSingleWord(1);
      
      Assert.Equal("one", actual);
    }
    
    [Fact]
    public void two_digit_is_transformed_in_words()
    {
      var sut = new NumToWord();

      var actual = sut.ToSingleWord(12);
      
      Assert.Equal("twelve", actual);
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
    };
    
    public string ToSingleWord(int number)
    {
      return _numberMap[number];
    }
  }
}