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