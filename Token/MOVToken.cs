using System;

using ikea.Memory;

namespace ikea.Token
{
    class MOVToken : Token {
        
        public MOVToken() : base("MOV"){}

        protected override bool ParseLine(string[] _parts, int _lineNumber)
        {
            // Only instruction and name
            if(_parts.Length != 2)
                throw new Exception($"Invalid argument length on line {_lineNumber}");

            string[] args = _parts[1].Split(',');

            if(args.Length != 2)
                throw new Exception($"Invalid argument length on line {_lineNumber}");

            ValueType vtRegister = Helper.ParseValueType(args[0], out int reg);
            ValueType vtValue = Helper.ParseValueType(args[1], out int val);

            // if(vtRegister == ValueType.Var)
                // throw new Exception("Illegal move, cannot MOV into vars, use VAR insted");

            Register.SetMemoryAt(reg, val);

            return true;
        }
    } 
}
