using System;

namespace ikea.Token
{
    class CALLToken : Token {
        
        public CALLToken() : base("CALL"){}

        protected override bool ParseLine(string[] _parts, int _lineNumber)
        {
            // System.Console.WriteLine("Call");

            // Only instruction and name
            if(_parts.Length != 2)
                throw new Exception($"Invalid argument length on line {_lineNumber}");

            // string[] args = _parts[1].Split(',');

            // if(args.Length != 2)
                // throw new Exception($"Invalid argument length on line {_lineNumber}");

            IKEA.SetNextLine(IKEA.GetFunctionLocation(_parts[1]) + 1);
            // TODO: Add to a call stack
            IKEA.SetCallFromLine(_lineNumber + 1);

            return true;
        }
    } 
}
