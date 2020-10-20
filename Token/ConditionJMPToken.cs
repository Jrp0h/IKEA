using System;

namespace ikea.Token
{
    class ConditionJMPToken : Token {

        int jumpValue = 0;
        
        public ConditionJMPToken(string _instruction, int _jumpValue) : base(_instruction)
        {
            jumpValue = _jumpValue;
        }

        protected override bool ParseLine(string[] _parts, int _lineNumber)
        {
            // Only instruction and name
            if(_parts.Length != 2)
                throw new Exception($"Invalid argument length on line {_lineNumber}");

            if(_parts.Length != 2)
                throw new Exception($"Invalid argument length on line {_lineNumber}");

            string[] args = _parts[1].Split(',');

            if(args.Length != 2)
                throw new Exception($"Invalid argument length on line {_lineNumber}");

            ValueType vtValue = Helper.ParseValueType(args[0], out int v);

            if(v == jumpValue)
                IKEA.SetNextLine(IKEA.GetSectionLocation(args[1]) + 1);

            return true;
        }
    } 
}
