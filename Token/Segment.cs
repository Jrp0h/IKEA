using System;
using System.Collections.Generic;

namespace ikea.Token
{
    class ProgramSegment : Token
    {
      Dictionary<string, int> registeredTokens;

      string segmentType;

      public ProgramSegment(string _instruction, string _segmentType) : base(_instruction) {
          registeredTokens = new Dictionary<string, int>();
          segmentType = _segmentType;
      }

      protected override bool ParseLine(string[] _parts, int _lineNumber)
      {
        // Only instruction and name
        if(_parts.Length != 2)
            throw new Exception($"Invalid argument length on line {_lineNumber}");

        // Name ends with :, then remove it
        if(_parts[1].EndsWith(':'))
            _parts[1] = _parts[1].Remove(_parts[1].Length - 1);

        registeredTokens.Add(_parts[1], _lineNumber);

        return true;
      }

      public void Print()
      {
          foreach(KeyValuePair<string, int> entry in registeredTokens)
          {
              System.Console.WriteLine($"{entry.Key}:{entry.Value}");
          }
      }

      public int GetLocation(string _name)
      {
          if(!registeredTokens.ContainsKey(_name))
              throw new Exception($"Undefined {segmentType} {_name}");

          return registeredTokens[_name];
      }
    } 
}
