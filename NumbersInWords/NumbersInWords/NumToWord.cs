using System.Collections.Generic;
using System.Linq;

namespace NumbersInWords
{
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

      if (number < 10)
      {
        return Digit(numberString[0].ToString());
      }

      if (number < 100)
      {
        return Dozens(number.ToString());
      }
      
      if (number < 1000)
      {
        return Centuries(number.ToString());
      }

      throw new System.NotImplementedException();
    }

    private static string Dozens(string number)
    {
      var unit = number[1].ToString();
      return NumberMap[int.Parse(number)- int.Parse(unit)] + " " + Digit(unit);
    }

    private static string Centuries(string number)
    {
      var cent = int.Parse(number[0].ToString());
      var dozens = int.Parse(number.Substring(1, number.Length -1));
      return NumberMap[cent] + " hundred " + Dozens(dozens.ToString());
    }
    
    private static string Digit(string number)
    {
      return NumberMap[int.Parse(number)];
    }
  }
}