using System;

namespace ikea.Token
{
    class JMPToken : Token {
        
        public JMPToken() : base("JMP"){}

        protected override bool ParseLine(string[] _parts, int _lineNumber)
        {
            // Only instruction and name
            if(_parts.Length != 2)
                throw new Exception($"Invalid argument length on line {_lineNumber}");

            IKEA.SetNextLine(IKEA.GetSectionLocation(_parts[1]) + 1);

            return true;
        }
    } 
}
