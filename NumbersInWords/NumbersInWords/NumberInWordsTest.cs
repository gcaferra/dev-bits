using System.Collections.Generic;
using System.Linq;
using Xunit;
using static NumbersInWords.NumToWord; 

namespace NumbersInWords
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
  }

  public static class NumToWord
  {
    static readonly Dictionary<int,string> NumberMap = new Dictionary<int, string>()
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
      {90, "ninety"}
    };
    
    public static string ToWord(int number)
    {
      if(NumberMap.TryGetValue(number, out _))
        return NumberMap[number];
      return Destruct(number);
    }

    private static string Destruct(int number)
    {
      var numberString = number.ToString().ToArray(); 

      if (numberString.Length == 1)
      {
        return NumberMap[int.Parse(numberString[0].ToString())];
      }

      if (numberString.Length == 2)
      {
        var unit = int.Parse(numberString[1].ToString());
        return NumberMap[number - unit]  +  " " +
               NumberMap[unit];
      }
      
      if (numberString.Length == 3)
      {
        var unit = int.Parse(numberString[2].ToString());
        var dec = int.Parse(numberString[1]+"0");
        var cent = int.Parse(numberString[0].ToString());

        return NumberMap[cent] + " hundred " + NumberMap[dec]  +  " " +
               NumberMap[unit];
      }

      throw new System.NotImplementedException();
    }
  }
}