using System;

using ikea.Memory;

namespace ikea.Token
{
    class VARToken : Token {
        
        public VARToken() : base("VAR"){}

        protected override bool ParseLine(string[] _parts, int _lineNumber)
        {
            // Only instruction and name
            if(_parts.Length != 2)
                throw new Exception($"Invalid argument length on line {_lineNumber}");

            string[] args = _parts[1].Split(',');

            if(args.Length != 2)
                throw new Exception($"Invalid argument length on line {_lineNumber}");

            ValueType vtValue = Helper.ParseValueType(args[1], out int val);

            Register.SetVar(args[0], val);

            return true;
        }
    } 
}
